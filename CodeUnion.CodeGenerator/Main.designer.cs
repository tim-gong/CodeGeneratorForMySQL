using System.ComponentModel;
using System.Windows.Forms;

namespace CodeUnion.CodeGenerator
{
    partial class Main : Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private IContainer components = null;
        

        

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Tables = new System.Windows.Forms.DataGridView();
            this.TableOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableCreationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableModificationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableColumns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.Container = new System.Windows.Forms.SplitContainer();
            this.SchemaType = new System.Windows.Forms.GroupBox();
            this.TableType = new System.Windows.Forms.RadioButton();
            this.ViewType = new System.Windows.Forms.RadioButton();
            this.NullableTypeContainer = new System.Windows.Forms.GroupBox();
            this.NullableType = new System.Windows.Forms.CheckBox();
            this.VersionContainer = new System.Windows.Forms.GroupBox();
            this.Version = new System.Windows.Forms.ComboBox();
            this.NamespaceContainer = new System.Windows.Forms.GroupBox();
            this.Namespace = new System.Windows.Forms.TextBox();
            this.Generate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Tables)).BeginInit();
            this.Container.Panel1.SuspendLayout();
            this.Container.Panel2.SuspendLayout();
            this.Container.SuspendLayout();
            this.SchemaType.SuspendLayout();
            this.NullableTypeContainer.SuspendLayout();
            this.VersionContainer.SuspendLayout();
            this.NamespaceContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tables
            // 
            this.Tables.AllowUserToAddRows = false;
            this.Tables.AllowUserToDeleteRows = false;
            this.Tables.AllowUserToOrderColumns = true;
            this.Tables.AllowUserToResizeRows = false;
            this.Tables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Tables.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Tables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TableOwner,
            this.TableName,
            this.TableAlias,
            this.TableDescription,
            this.TableCreationTime,
            this.TableModificationTime,
            this.TableColumns});
            this.Tables.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.Tables.Location = new System.Drawing.Point(3, 39);
            this.Tables.Name = "Tables";
            this.Tables.RowHeadersWidth = 25;
            this.Tables.RowTemplate.Height = 23;
            this.Tables.Size = new System.Drawing.Size(822, 582);
            this.Tables.TabIndex = 4;
            this.Tables.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Tables_DataBindingComplete);
            // 
            // TableOwner
            // 
            this.TableOwner.DataPropertyName = "Owner";
            this.TableOwner.HeaderText = "所有者";
            this.TableOwner.Name = "TableOwner";
            this.TableOwner.ReadOnly = true;
            // 
            // TableName
            // 
            this.TableName.DataPropertyName = "Name";
            this.TableName.HeaderText = "名 称";
            this.TableName.Name = "TableName";
            this.TableName.ReadOnly = true;
            // 
            // TableAlias
            // 
            this.TableAlias.DataPropertyName = "Alias";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            this.TableAlias.DefaultCellStyle = dataGridViewCellStyle2;
            this.TableAlias.HeaderText = "别 名";
            this.TableAlias.Name = "TableAlias";
            // 
            // TableDescription
            // 
            this.TableDescription.DataPropertyName = "Description";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            this.TableDescription.DefaultCellStyle = dataGridViewCellStyle3;
            this.TableDescription.HeaderText = "描 述";
            this.TableDescription.Name = "TableDescription";
            // 
            // TableCreationTime
            // 
            this.TableCreationTime.DataPropertyName = "CreationTime";
            dataGridViewCellStyle4.Format = "yyyy-MM-dd HH:mm";
            dataGridViewCellStyle4.NullValue = null;
            this.TableCreationTime.DefaultCellStyle = dataGridViewCellStyle4;
            this.TableCreationTime.HeaderText = "创建时间";
            this.TableCreationTime.Name = "TableCreationTime";
            this.TableCreationTime.ReadOnly = true;
            // 
            // TableModificationTime
            // 
            this.TableModificationTime.DataPropertyName = "ModificationTime";
            dataGridViewCellStyle5.Format = "yyyy-MM-dd HH:mm";
            dataGridViewCellStyle5.NullValue = null;
            this.TableModificationTime.DefaultCellStyle = dataGridViewCellStyle5;
            this.TableModificationTime.HeaderText = "修改时间";
            this.TableModificationTime.Name = "TableModificationTime";
            this.TableModificationTime.ReadOnly = true;
            // 
            // TableColumns
            // 
            this.TableColumns.DataPropertyName = "Columns";
            this.TableColumns.HeaderText = "列集合";
            this.TableColumns.Name = "TableColumns";
            this.TableColumns.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(463, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Container
            // 
            this.Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Container.Location = new System.Drawing.Point(0, 0);
            this.Container.Name = "Container";
            this.Container.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Container.Panel1
            // 
            this.Container.Panel1.Controls.Add(this.Tables);
            this.Container.Panel1.Controls.Add(this.SchemaType);
            // 
            // Container.Panel2
            // 
            this.Container.Panel2.Controls.Add(this.button1);
            this.Container.Panel2.Controls.Add(this.NullableTypeContainer);
            this.Container.Panel2.Controls.Add(this.VersionContainer);
            this.Container.Panel2.Controls.Add(this.NamespaceContainer);
            this.Container.Panel2.Controls.Add(this.Generate);
            this.Container.Size = new System.Drawing.Size(828, 719);
            this.Container.SplitterDistance = 623;
            this.Container.TabIndex = 1;
            // 
            // SchemaType
            // 
            this.SchemaType.Controls.Add(this.TableType);
            this.SchemaType.Controls.Add(this.ViewType);
            this.SchemaType.Dock = System.Windows.Forms.DockStyle.Top;
            this.SchemaType.Location = new System.Drawing.Point(0, 0);
            this.SchemaType.Name = "SchemaType";
            this.SchemaType.Size = new System.Drawing.Size(828, 39);
            this.SchemaType.TabIndex = 1;
            this.SchemaType.TabStop = false;
            this.SchemaType.Text = "架构类型：";
            // 
            // TableType
            // 
            this.TableType.AutoSize = true;
            this.TableType.Checked = true;
            this.TableType.Location = new System.Drawing.Point(12, 17);
            this.TableType.Name = "TableType";
            this.TableType.Size = new System.Drawing.Size(35, 16);
            this.TableType.TabIndex = 1;
            this.TableType.TabStop = true;
            this.TableType.Text = "表";
            this.TableType.UseVisualStyleBackColor = true;
            this.TableType.CheckedChanged += new System.EventHandler(this.Table_CheckedChanged);
            // 
            // ViewType
            // 
            this.ViewType.AutoSize = true;
            this.ViewType.Location = new System.Drawing.Point(92, 17);
            this.ViewType.Name = "ViewType";
            this.ViewType.Size = new System.Drawing.Size(47, 16);
            this.ViewType.TabIndex = 0;
            this.ViewType.Text = "视图";
            this.ViewType.UseVisualStyleBackColor = true;
            this.ViewType.CheckedChanged += new System.EventHandler(this.View_CheckedChanged);
            // 
            // NullableTypeContainer
            // 
            this.NullableTypeContainer.Controls.Add(this.NullableType);
            this.NullableTypeContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.NullableTypeContainer.Location = new System.Drawing.Point(291, 0);
            this.NullableTypeContainer.Name = "NullableTypeContainer";
            this.NullableTypeContainer.Size = new System.Drawing.Size(103, 92);
            this.NullableTypeContainer.TabIndex = 3;
            this.NullableTypeContainer.TabStop = false;
            this.NullableTypeContainer.Text = "可空数据类型：";
            // 
            // NullableType
            // 
            this.NullableType.AutoSize = true;
            this.NullableType.Location = new System.Drawing.Point(42, 30);
            this.NullableType.Name = "NullableType";
            this.NullableType.Size = new System.Drawing.Size(15, 14);
            this.NullableType.TabIndex = 0;
            this.NullableType.UseVisualStyleBackColor = true;
            // 
            // VersionContainer
            // 
            this.VersionContainer.Controls.Add(this.Version);
            this.VersionContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.VersionContainer.Location = new System.Drawing.Point(194, 0);
            this.VersionContainer.Name = "VersionContainer";
            this.VersionContainer.Size = new System.Drawing.Size(97, 92);
            this.VersionContainer.TabIndex = 2;
            this.VersionContainer.TabStop = false;
            this.VersionContainer.Text = "框架版本：";
            // 
            // Version
            // 
            this.Version.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Version.FormattingEnabled = true;
            this.Version.Items.AddRange(new object[] {
            "2.0",
            "3.5"});
            this.Version.Location = new System.Drawing.Point(6, 26);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(85, 20);
            this.Version.TabIndex = 0;
            // 
            // NamespaceContainer
            // 
            this.NamespaceContainer.Controls.Add(this.Namespace);
            this.NamespaceContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.NamespaceContainer.Location = new System.Drawing.Point(0, 0);
            this.NamespaceContainer.Name = "NamespaceContainer";
            this.NamespaceContainer.Size = new System.Drawing.Size(194, 92);
            this.NamespaceContainer.TabIndex = 1;
            this.NamespaceContainer.TabStop = false;
            this.NamespaceContainer.Text = "命名空间：";
            // 
            // Namespace
            // 
            this.Namespace.Location = new System.Drawing.Point(29, 24);
            this.Namespace.Name = "Namespace";
            this.Namespace.Size = new System.Drawing.Size(159, 21);
            this.Namespace.TabIndex = 0;
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(596, 30);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(75, 23);
            this.Generate.TabIndex = 0;
            this.Generate.Text = "生 成";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(828, 719);
            this.Controls.Add(this.Container);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "代码发电机";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Tables)).EndInit();
            this.Container.Panel1.ResumeLayout(false);
            this.Container.Panel2.ResumeLayout(false);
            this.Container.ResumeLayout(false);
            this.SchemaType.ResumeLayout(false);
            this.SchemaType.PerformLayout();
            this.NullableTypeContainer.ResumeLayout(false);
            this.NullableTypeContainer.PerformLayout();
            this.VersionContainer.ResumeLayout(false);
            this.NamespaceContainer.ResumeLayout(false);
            this.NamespaceContainer.PerformLayout();
            this.ResumeLayout(false);

        }
        private SplitContainer Container;
        private Button Generate;
        private TextBox Namespace;
        private GroupBox NamespaceContainer;
        private CheckBox NullableType;
        private GroupBox NullableTypeContainer;
        private GroupBox SchemaType;
        private DataGridViewTextBoxColumn TableAlias;
        private DataGridViewTextBoxColumn TableColumns;
        private DataGridViewTextBoxColumn TableCreationTime;
        private DataGridViewTextBoxColumn TableDescription;
        private DataGridViewTextBoxColumn TableModificationTime;
        private DataGridViewTextBoxColumn TableName;
        private DataGridViewTextBoxColumn TableOwner;
        private RadioButton TableType;
        private ComboBox Version;
        private GroupBox VersionContainer;
        private RadioButton ViewType;
        private Button button1;
        private DataGridView Tables;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

