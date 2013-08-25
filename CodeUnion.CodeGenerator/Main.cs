using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using CodeUnion.CodeGenerator.Data;

namespace CodeUnion.CodeGenerator
{
    public partial class Main : Form
    {
        public Main()
        {
            this.InitializeComponent();
            this.Refresh("BASE TABLE");
            if (this.Version.Items.Count > 0)
            {
                this.Version.SelectedItem = this.Version.Items[0];
            }
        }
        public Main(string tableName)
        {
            this.InitializeComponent();
            IGeneratorService generatorService = new GeneratorService();
            generatorService.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            this.Tables.DataSource = generatorService.GetColumns(tableName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.Tables.SelectedRows)
            {
                row.DataBoundItem.ToString();
            }
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            if (Tables.SelectedRows.Count>0)
            {
                Generate.Enabled = false;
                IDictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("database", ConfigurationManager.ConnectionStrings["connectionString"].ProviderName);
                parameters.Add("namespace", this.Namespace.Text);
                parameters.Add("nullableType", this.NullableType.Checked ? "?" : "");
                IList<Table> tables = new List<Table>();
                foreach (DataGridViewRow row in this.Tables.SelectedRows)
                {
                    tables.Add((Table)row.DataBoundItem);
                }
                IGeneratorService generatorService = new GeneratorService();
                generatorService.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                generatorService.TemplatePath = Path.Combine(Application.StartupPath, string.Format(@"Templates\{0}", this.Version.SelectedItem));
                generatorService.OutputPath = Path.Combine(Application.StartupPath, "Outputs");
                //生成之前清空outputs文件夹
                DeleteFolder(generatorService.OutputPath);

                generatorService.Generate(tables, parameters);
                MessageBox.Show("生成成功");
                Generate.Enabled = true;
            }
            else
            {
                MessageBox.Show("请选择数据表");
            }
        }

        /// <summary>
        /// 删除指定路径下的文件及文件夹
        /// </summary>
        /// <param name="path">指定路径</param>
        /// <returns>成功返回真，否则返回假</returns>
        public static bool DeleteFolder(string path)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);

                FileSystemInfo[] fsi = di.GetFileSystemInfos();

                foreach (FileSystemInfo tempFsi in fsi)
                {
                    if (tempFsi is DirectoryInfo)
                    {   // 删除文件夹
                        Directory.Delete(tempFsi.FullName, true);
                    }
                    else if (tempFsi is FileInfo)
                    {    // 删除文件
                        tempFsi.Delete();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Refresh(string schemaType)
        {
            IGeneratorService generatorService = new GeneratorService();
            generatorService.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            this.Tables.DataSource = generatorService.GetTables(schemaType);
        }

        private void Table_CheckedChanged(object sender, EventArgs e)
        {
            if (this.TableType.Checked)
            {
                this.Refresh("BASE TABLE");
            }
        }

        private void Tables_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.Tables.Columns["TableOwner"].DisplayIndex = 0;
            this.Tables.Columns["TableName"].DisplayIndex = 1;
            this.Tables.Columns["TableAlias"].DisplayIndex = 2;
            this.Tables.Columns["TableDescription"].DisplayIndex = 3;
            this.Tables.Columns["TableCreationTime"].DisplayIndex = 4;
            this.Tables.Columns["TableModificationTime"].DisplayIndex = 5;
            this.Tables.Columns["TableColumns"].DisplayIndex = 6;
        }

        private void View_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ViewType.Checked)
            {
                this.Refresh("View");
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
