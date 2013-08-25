using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.IO;
using System.Linq;
using CodeUnion.CodeGenerator.Utility;
using MySql.Data.MySqlClient;

//using System.Data.OleDb;


namespace CodeUnion.CodeGenerator.Data
{
    public class GeneratorService : IGeneratorService
    {
        /// <summary>
        /// 根据模板生成文件
        /// </summary>
        /// <param name="tables"></param>
        /// <param name="parameters"></param>
        public void Generate(IList<Table> tables, IDictionary<string, object> parameters)
        {
            foreach (Table table in tables)
            {
                IDictionary<string, object> args = new Dictionary<string, object>(parameters);
                args.Add("table", table);
                args.Add("allColumns", table.AllColumns);
                args.Add("keys", table.Keys);
                args.Add("columns", table.Columns);
                args.Add("key", table.Keys.FirstOrDefault<Column>());
                string[] templateFiles = Directory.GetFiles(this.TemplatePath, "*.vm", System.IO.SearchOption.TopDirectoryOnly);
                foreach (string templateFile in templateFiles)
                {
                    string templateFileName = Path.GetFileName(templateFile);
                    string path = this.OutputPath;
                    switch (templateFileName)
                    {
                        case "IModelService.cs.vm":
                            path = Path.Combine(this.OutputPath, "Contract");
                            break;
                        case "Model.cs.vm":
                            path = Path.Combine(this.OutputPath, "Model");
                            break;
                        case "ModelDao.cs.vm":
                            path = Path.Combine(this.OutputPath, "Dao");
                            break;
                        case "ModelDao.xml.vm":
                            path = Path.Combine(this.OutputPath, "Dao");
                            break;
                        case "ModelService.cs.vm":
                            path = Path.Combine(this.OutputPath, "Service");
                            break;
                        case "PaginationBase.cs.vm":
                            path = Path.Combine(this.OutputPath, "Model");
                            break;
                        case "QPBase.cs.vm":
                            path = Path.Combine(this.OutputPath, "Model");
                            break;
                        default:
                            break;
                    }
                    TextWriteOverride(Path.Combine(path, templateFileName.Replace("Model", table.Alias)).Replace(".vm", ""), TemplateUtility.ParseVelocity(this.TemplatePath, templateFileName, args));
                }
            }
        }

        /// <summary>
        /// 将一个字符串写入指定的文本[覆盖原有数据]（如果文本|路径存在则创建文本|路径）
        /// </summary>
        /// <param name="path">指定路径</param>
        /// <param name="row">字符串</param>
        /// <returns>成功返回true</returns>
        public static bool TextWriteOverride(string path, string row)
        {
            try
            {
                string path1 = path.Substring(0, path.LastIndexOf("\\"));
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(path1);
                }
                path1 = null;

                FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
                streamWriter.WriteLine(row);
                streamWriter.Close();
                fileStream.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取所有的数据列
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public IList<Column> GetColumns(string tableName)
        {
            IList<Column> result = new List<Column>();
            IList<string> primaryKeys = this.GetPrimaryKeys(tableName);
            string[] strings = new string[3];
            strings[1] = this.Database;
            strings[2] = tableName;
            DataTable columns = this.GetSchema("Columns", strings);

            foreach (DataRow row in columns.Rows)
            {
                Column column = new Column
                    {
                        Name = row.Field<string>("Column_Name"),
                        Type = this.GetDataType(row.Field<string>("Data_Type"))
                    };


                column.Description = column.Name;

                //column.Description = row.Field<string>("Description");

                column.Length = row.Field<ulong?>("Character_Maximum_Length");
                column.Nullable = row.Field<string>("Is_Nullable").Equals("YES");
                column.DefaultValue = row.Field<string>("Column_Default");
                column.Sequence = row.Field<ulong>("Ordinal_Position");
                column.Type = this.GetCSharpType(column);
                column.Primary = primaryKeys.Contains(column.Name);
                result.Add(column);
            }
            if (result.Count > 0)
            {
                result = new List<Column>(result.OrderBy<Column, string>(c => c.Name));
            }
            return result;
        }

        /// <summary>
        /// 获取对应的C#类型
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        private string GetCSharpType(Column column)
        {
            switch (column.Type)
            {
                case "System.Boolean":
                    return "bool";

                case "System.Byte":
                    return "byte";

                case "System.DateTime":
                    return "DateTime";

                case "System.Decimal":
                    return "decimal";

                case "System.Int32":
                    return "int";

                case "System.String":
                    return "string";
            }
            return column.Type;
        }

        /// <summary>
        /// 获取数据列类型
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        private string GetDataType(string dataType)
        {
            string result = "";
            DataTable dataTypes = this.GetSchema("DataTypes", null);
            if (dataTypes.Rows.Count > 0)
            {
                DataRow[] types = dataTypes.Select(string.Format("TypeName = '{0}'", dataType.ToUpper()));
                if (types.Length > 0)
                {
                    result = types[0].Field<string>("DataType");
                }
            }
            return result;
        }

        /// <summary>
        /// 获取主键
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public IList<string> GetPrimaryKeys(string tableName)
        {
            IList<string> result = new List<string>();
            string[] tableNames = new string[4];
            tableNames[1] = this.Database;
            tableNames[2] = tableName;
            DataTable indexes = this.GetSchema("IndexColumns", tableNames);
            if (indexes.Rows.Count > 0)
            {
                // DataRow[] keys = indexes.Select("Primary = true");
                foreach (DataRow key in indexes.Rows)
                {
                    result.Add(key.Field<string>("Column_Name"));
                }
            }
            return result;
        }

        /// <summary>
        /// 获取指定的数据库架构信息
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="restrictionValues"></param>
        /// <returns></returns>
        public DataTable GetSchema(string collectionName, string[] restrictionValues)
        {
            DataTable result = null;
            using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                result = connection.GetSchema(collectionName, restrictionValues);
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// 根据查询条件获取DataTable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public DataTable RunExecute_Sql(string sql)
        {
            DataTable Result = null;
            using (MySqlConnection Conn = new MySqlConnection(this.ConnectionString))
            {
                Conn.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter(sql, Conn);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                Result = ds.Tables[0];
                Conn.Close();
            }
            return Result;
        }

        /// <summary>
        /// 获取所有的用户表
        /// </summary>
        /// <param name="schemaType"></param>
        /// <returns></returns>
        public IList<Table> GetTables(string schemaType)
        {
            IList<Table> result = new List<Table>();
            string[] strings = new string[4];
            strings[1] = this.Database;
            strings[3] = schemaType;
            DataTable tables = this.GetSchema("Tables", strings);
            foreach (DataRow row in tables.Rows)
            {
                Table table = new Table
                    {
                        Name = row.Field<string>("Table_Name"),
                        Description = row.Field<string>("Table_Comment"),
                        Owner = row.Field<string>("Table_Schema"),
                        CreationTime = row.Field<DateTime>("Create_Time"),
                        ModificationTime = row.Field<DateTime?>("Update_Time")
                    };

                table.AllColumns = this.GetColumns(table.Name);
                IEnumerable<Column> keys = table.AllColumns.Where<Column>(c => c.Primary);
                table.Keys = new List<Column>(keys);
                IEnumerable<Column> columns = table.AllColumns.Where<Column>(c => !c.Primary);
                table.Columns = new List<Column>(columns);
                result.Add(table);
            }
            return result;
        }

        public string ConnectionString
        {
            get;
            set;
        }

        public string OutputPath
        {
            get;
            set;
        }

        public string TemplatePath
        {
            get;
            set;
        }
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string Database
        {
            get
            {
                string databaseName = null;
                string[] temp = this.ConnectionString.Split(';');
                foreach (var s in temp)
                {
                    string[] keywordAndValue = s.Split('=');
                    if (keywordAndValue[0].ToUpper().Equals("DATABASE"))
                    {
                        databaseName = keywordAndValue[1];
                        break;
                    }
                }
                return databaseName;
            }
        }
    }
}
