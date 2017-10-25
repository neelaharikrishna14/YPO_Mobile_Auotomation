namespace Selenium.Automation.TestSuiteExecutor
{
    partial class form_TestSuiteRunner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_Form = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tableLayout_Filter = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lnklbl_OverallExeStatResult = new System.Windows.Forms.LinkLabel();
            this.lstbox_Criteria = new System.Windows.Forms.ListBox();
            this.lstbox_SubModule = new System.Windows.Forms.ListBox();
            this.lstbox_Module = new System.Windows.Forms.ListBox();
            this.lbl_FilterByCategory = new System.Windows.Forms.Label();
            this.lbl_FilterBySubModule = new System.Windows.Forms.Label();
            this.lbl_FilterByModule = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.btn_ExecuteTests = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.selectBrowser_Combobox = new System.Windows.Forms.ComboBox();
            this.chkbox_SelectAll = new System.Windows.Forms.CheckBox();
            this.lbl_selectBrowser = new System.Windows.Forms.Label();
            this.chklBrowsers = new System.Windows.Forms.CheckedListBox();
            this.tableLayout_ExecSummary = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_TotalTCsPassPerResult = new System.Windows.Forms.Label();
            this.lbl_TotalTCsFailedResult = new System.Windows.Forms.Label();
            this.lbl_TotalTCsPassedResult = new System.Windows.Forms.Label();
            this.lbl_TotalTCsPassPercentage = new System.Windows.Forms.Label();
            this.lbl_TotalTCsFailed = new System.Windows.Forms.Label();
            this.lbl_TotalTCsPassed = new System.Windows.Forms.Label();
            this.lbl_TotalTCsExecuted = new System.Windows.Forms.Label();
            this.lbl_ExecutionSummary = new System.Windows.Forms.Label();
            this.lbl_TotalTCs = new System.Windows.Forms.Label();
            this.lbl_TotalTCsResult = new System.Windows.Forms.Label();
            this.lbl_TotalTCsExecutedResult = new System.Windows.Forms.Label();
            this.tableLayout_Panel = new System.Windows.Forms.TableLayoutPanel();
            this.pic_ClientLogo = new System.Windows.Forms.PictureBox();
            this.pic_CompanyLogo = new System.Windows.Forms.PictureBox();
            this.lbl_Header = new System.Windows.Forms.Label();
            this.bgWrkTestExecutor = new System.ComponentModel.BackgroundWorker();
            this.panel_Form.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayout_Filter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayout_ExecSummary.SuspendLayout();
            this.tableLayout_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ClientLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CompanyLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Form
            // 
            this.panel_Form.AutoSize = true;
            this.panel_Form.BackColor = System.Drawing.Color.White;
            this.panel_Form.Controls.Add(this.tableLayoutPanel1);
            this.panel_Form.Controls.Add(this.tableLayout_Filter);
            this.panel_Form.Controls.Add(this.tableLayout_ExecSummary);
            this.panel_Form.Controls.Add(this.tableLayout_Panel);
            this.panel_Form.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Form.Location = new System.Drawing.Point(0, 0);
            this.panel_Form.Name = "panel_Form";
            this.panel_Form.Size = new System.Drawing.Size(1051, 538);
            this.panel_Form.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 302);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.38323F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.616771F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1051, 236);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(1045, 219);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(3, 228);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1045, 5);
            this.progressBar1.TabIndex = 4;
            // 
            // tableLayout_Filter
            // 
            this.tableLayout_Filter.AllowDrop = true;
            this.tableLayout_Filter.ColumnCount = 4;
            this.tableLayout_Filter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayout_Filter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayout_Filter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayout_Filter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayout_Filter.Controls.Add(this.label1, 3, 0);
            this.tableLayout_Filter.Controls.Add(this.lnklbl_OverallExeStatResult, 3, 2);
            this.tableLayout_Filter.Controls.Add(this.lstbox_Criteria, 2, 1);
            this.tableLayout_Filter.Controls.Add(this.lstbox_SubModule, 1, 1);
            this.tableLayout_Filter.Controls.Add(this.lstbox_Module, 0, 1);
            this.tableLayout_Filter.Controls.Add(this.lbl_FilterByCategory, 0, 0);
            this.tableLayout_Filter.Controls.Add(this.lbl_FilterBySubModule, 0, 0);
            this.tableLayout_Filter.Controls.Add(this.lbl_FilterByModule, 0, 0);
            this.tableLayout_Filter.Controls.Add(this.panel1, 1, 2);
            this.tableLayout_Filter.Controls.Add(this.panel2, 0, 2);
            this.tableLayout_Filter.Controls.Add(this.chklBrowsers, 3, 1);
            this.tableLayout_Filter.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayout_Filter.Location = new System.Drawing.Point(0, 132);
            this.tableLayout_Filter.Name = "tableLayout_Filter";
            this.tableLayout_Filter.RowCount = 3;
            this.tableLayout_Filter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.61882F));
            this.tableLayout_Filter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.05631F));
            this.tableLayout_Filter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.32487F));
            this.tableLayout_Filter.Size = new System.Drawing.Size(1051, 170);
            this.tableLayout_Filter.TabIndex = 2;
            this.tableLayout_Filter.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayout_Filter_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(789, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "Execute On - Devices";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnklbl_OverallExeStatResult
            // 
            this.lnklbl_OverallExeStatResult.AutoSize = true;
            this.lnklbl_OverallExeStatResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lnklbl_OverallExeStatResult.Location = new System.Drawing.Point(789, 139);
            this.lnklbl_OverallExeStatResult.Name = "lnklbl_OverallExeStatResult";
            this.lnklbl_OverallExeStatResult.Size = new System.Drawing.Size(259, 31);
            this.lnklbl_OverallExeStatResult.TabIndex = 15;
            this.lnklbl_OverallExeStatResult.TabStop = true;
            this.lnklbl_OverallExeStatResult.Text = "Not started";
            this.lnklbl_OverallExeStatResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnklbl_OverallExeStatResult.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbl_OverallExeStatResult_LinkClicked);
            // 
            // lstbox_Criteria
            // 
            this.lstbox_Criteria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstbox_Criteria.FormattingEnabled = true;
            this.lstbox_Criteria.Location = new System.Drawing.Point(527, 22);
            this.lstbox_Criteria.Name = "lstbox_Criteria";
            this.lstbox_Criteria.Size = new System.Drawing.Size(256, 114);
            this.lstbox_Criteria.TabIndex = 14;
            this.lstbox_Criteria.SelectedIndexChanged += new System.EventHandler(this.lstbox_Criteria_SelectedIndexChanged);
            // 
            // lstbox_SubModule
            // 
            this.lstbox_SubModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstbox_SubModule.FormattingEnabled = true;
            this.lstbox_SubModule.Location = new System.Drawing.Point(265, 22);
            this.lstbox_SubModule.Name = "lstbox_SubModule";
            this.lstbox_SubModule.Size = new System.Drawing.Size(256, 114);
            this.lstbox_SubModule.TabIndex = 13;
            this.lstbox_SubModule.SelectedIndexChanged += new System.EventHandler(this.lstbox_SubModule_SelectedIndexChanged);
            // 
            // lstbox_Module
            // 
            this.lstbox_Module.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstbox_Module.FormattingEnabled = true;
            this.lstbox_Module.Location = new System.Drawing.Point(3, 22);
            this.lstbox_Module.Name = "lstbox_Module";
            this.lstbox_Module.Size = new System.Drawing.Size(256, 114);
            this.lstbox_Module.TabIndex = 8;
            this.lstbox_Module.SelectedIndexChanged += new System.EventHandler(this.lstbox_Module_SelectedIndexChanged);
            // 
            // lbl_FilterByCategory
            // 
            this.lbl_FilterByCategory.AutoSize = true;
            this.lbl_FilterByCategory.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lbl_FilterByCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_FilterByCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FilterByCategory.Location = new System.Drawing.Point(527, 0);
            this.lbl_FilterByCategory.Name = "lbl_FilterByCategory";
            this.lbl_FilterByCategory.Size = new System.Drawing.Size(256, 19);
            this.lbl_FilterByCategory.TabIndex = 6;
            this.lbl_FilterByCategory.Text = "Filter by - Category";
            this.lbl_FilterByCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_FilterBySubModule
            // 
            this.lbl_FilterBySubModule.AutoSize = true;
            this.lbl_FilterBySubModule.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lbl_FilterBySubModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_FilterBySubModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FilterBySubModule.Location = new System.Drawing.Point(3, 0);
            this.lbl_FilterBySubModule.Name = "lbl_FilterBySubModule";
            this.lbl_FilterBySubModule.Size = new System.Drawing.Size(256, 19);
            this.lbl_FilterBySubModule.TabIndex = 5;
            this.lbl_FilterBySubModule.Text = "Filter by - Module";
            this.lbl_FilterBySubModule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_FilterByModule
            // 
            this.lbl_FilterByModule.AutoSize = true;
            this.lbl_FilterByModule.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lbl_FilterByModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_FilterByModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FilterByModule.Location = new System.Drawing.Point(265, 0);
            this.lbl_FilterByModule.Name = "lbl_FilterByModule";
            this.lbl_FilterByModule.Size = new System.Drawing.Size(256, 19);
            this.lbl_FilterByModule.TabIndex = 4;
            this.lbl_FilterByModule.Text = "Filter by -SubModule";
            this.lbl_FilterByModule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClearFilters);
            this.panel1.Controls.Add(this.btn_ExecuteTests);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(265, 142);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 25);
            this.panel1.TabIndex = 16;
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.BackColor = System.Drawing.Color.LightGray;
            this.btnClearFilters.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClearFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFilters.Location = new System.Drawing.Point(-60, 0);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(158, 25);
            this.btnClearFilters.TabIndex = 6;
            this.btnClearFilters.Text = "Reset";
            this.btnClearFilters.UseVisualStyleBackColor = false;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // btn_ExecuteTests
            // 
            this.btn_ExecuteTests.BackColor = System.Drawing.Color.LightGray;
            this.btn_ExecuteTests.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_ExecuteTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ExecuteTests.Location = new System.Drawing.Point(98, 0);
            this.btn_ExecuteTests.Name = "btn_ExecuteTests";
            this.btn_ExecuteTests.Size = new System.Drawing.Size(158, 25);
            this.btn_ExecuteTests.TabIndex = 16;
            this.btn_ExecuteTests.Text = "Execute Tests";
            this.btn_ExecuteTests.UseVisualStyleBackColor = false;
            this.btn_ExecuteTests.Click += new System.EventHandler(this.btn_ExecuteTests_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.selectBrowser_Combobox);
            this.panel2.Controls.Add(this.chkbox_SelectAll);
            this.panel2.Controls.Add(this.lbl_selectBrowser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(256, 25);
            this.panel2.TabIndex = 17;
            // 
            // selectBrowser_Combobox
            // 
            this.selectBrowser_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectBrowser_Combobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectBrowser_Combobox.FormattingEnabled = true;
            this.selectBrowser_Combobox.Items.AddRange(new object[] {
            "-- Select --",
            "iPhone6",
            "iPhone5",
            "iPhone7Plus"});
            this.selectBrowser_Combobox.Location = new System.Drawing.Point(209, 1);
            this.selectBrowser_Combobox.Name = "selectBrowser_Combobox";
            this.selectBrowser_Combobox.Size = new System.Drawing.Size(122, 21);
            this.selectBrowser_Combobox.TabIndex = 4;
            this.selectBrowser_Combobox.Visible = false;
            this.selectBrowser_Combobox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // chkbox_SelectAll
            // 
            this.chkbox_SelectAll.AllowDrop = true;
            this.chkbox_SelectAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkbox_SelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbox_SelectAll.Location = new System.Drawing.Point(0, 0);
            this.chkbox_SelectAll.Name = "chkbox_SelectAll";
            this.chkbox_SelectAll.Size = new System.Drawing.Size(90, 25);
            this.chkbox_SelectAll.TabIndex = 17;
            this.chkbox_SelectAll.Text = "Select All";
            this.chkbox_SelectAll.UseVisualStyleBackColor = true;
            this.chkbox_SelectAll.CheckedChanged += new System.EventHandler(this.chkbox_SelectAll_CheckedChanged);
            // 
            // lbl_selectBrowser
            // 
            this.lbl_selectBrowser.AutoSize = true;
            this.lbl_selectBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_selectBrowser.Location = new System.Drawing.Point(111, 5);
            this.lbl_selectBrowser.Name = "lbl_selectBrowser";
            this.lbl_selectBrowser.Size = new System.Drawing.Size(92, 13);
            this.lbl_selectBrowser.TabIndex = 5;
            this.lbl_selectBrowser.Text = "Select Browser";
            this.lbl_selectBrowser.Visible = false;
            // 
            // chklBrowsers
            // 
            this.chklBrowsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chklBrowsers.FormattingEnabled = true;
            this.chklBrowsers.Items.AddRange(new object[] {
            "iPhone6",
            "iPhone5",
            "iPhone7Plus"});
            this.chklBrowsers.Location = new System.Drawing.Point(789, 22);
            this.chklBrowsers.Name = "chklBrowsers";
            this.chklBrowsers.Size = new System.Drawing.Size(259, 114);
            this.chklBrowsers.TabIndex = 18;
            // 
            // tableLayout_ExecSummary
            // 
            this.tableLayout_ExecSummary.ColumnCount = 5;
            this.tableLayout_ExecSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.4F));
            this.tableLayout_ExecSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.52F));
            this.tableLayout_ExecSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayout_ExecSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayout_ExecSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayout_ExecSummary.Controls.Add(this.lbl_TotalTCsPassPerResult, 4, 2);
            this.tableLayout_ExecSummary.Controls.Add(this.lbl_TotalTCsFailedResult, 3, 2);
            this.tableLayout_ExecSummary.Controls.Add(this.lbl_TotalTCsPassedResult, 2, 2);
            this.tableLayout_ExecSummary.Controls.Add(this.lbl_TotalTCsPassPercentage, 4, 1);
            this.tableLayout_ExecSummary.Controls.Add(this.lbl_TotalTCsFailed, 3, 1);
            this.tableLayout_ExecSummary.Controls.Add(this.lbl_TotalTCsPassed, 2, 1);
            this.tableLayout_ExecSummary.Controls.Add(this.lbl_TotalTCsExecuted, 1, 1);
            this.tableLayout_ExecSummary.Controls.Add(this.lbl_ExecutionSummary, 0, 0);
            this.tableLayout_ExecSummary.Controls.Add(this.lbl_TotalTCs, 0, 1);
            this.tableLayout_ExecSummary.Controls.Add(this.lbl_TotalTCsResult, 0, 2);
            this.tableLayout_ExecSummary.Controls.Add(this.lbl_TotalTCsExecutedResult, 1, 2);
            this.tableLayout_ExecSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayout_ExecSummary.Location = new System.Drawing.Point(0, 73);
            this.tableLayout_ExecSummary.Name = "tableLayout_ExecSummary";
            this.tableLayout_ExecSummary.RowCount = 3;
            this.tableLayout_ExecSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.8983F));
            this.tableLayout_ExecSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.8983F));
            this.tableLayout_ExecSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.37255F));
            this.tableLayout_ExecSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout_ExecSummary.Size = new System.Drawing.Size(1051, 59);
            this.tableLayout_ExecSummary.TabIndex = 1;
            // 
            // lbl_TotalTCsPassPerResult
            // 
            this.lbl_TotalTCsPassPerResult.AutoSize = true;
            this.lbl_TotalTCsPassPerResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_TotalTCsPassPerResult.Location = new System.Drawing.Point(842, 40);
            this.lbl_TotalTCsPassPerResult.Name = "lbl_TotalTCsPassPerResult";
            this.lbl_TotalTCsPassPerResult.Size = new System.Drawing.Size(206, 19);
            this.lbl_TotalTCsPassPerResult.TabIndex = 10;
            this.lbl_TotalTCsPassPerResult.Text = "0";
            this.lbl_TotalTCsPassPerResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_TotalTCsFailedResult
            // 
            this.lbl_TotalTCsFailedResult.AutoSize = true;
            this.lbl_TotalTCsFailedResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_TotalTCsFailedResult.Location = new System.Drawing.Point(632, 40);
            this.lbl_TotalTCsFailedResult.Name = "lbl_TotalTCsFailedResult";
            this.lbl_TotalTCsFailedResult.Size = new System.Drawing.Size(204, 19);
            this.lbl_TotalTCsFailedResult.TabIndex = 9;
            this.lbl_TotalTCsFailedResult.Text = "0";
            this.lbl_TotalTCsFailedResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_TotalTCsPassedResult
            // 
            this.lbl_TotalTCsPassedResult.AutoSize = true;
            this.lbl_TotalTCsPassedResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_TotalTCsPassedResult.Location = new System.Drawing.Point(422, 40);
            this.lbl_TotalTCsPassedResult.Name = "lbl_TotalTCsPassedResult";
            this.lbl_TotalTCsPassedResult.Size = new System.Drawing.Size(204, 19);
            this.lbl_TotalTCsPassedResult.TabIndex = 8;
            this.lbl_TotalTCsPassedResult.Text = "0";
            this.lbl_TotalTCsPassedResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_TotalTCsPassPercentage
            // 
            this.lbl_TotalTCsPassPercentage.AutoSize = true;
            this.lbl_TotalTCsPassPercentage.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lbl_TotalTCsPassPercentage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_TotalTCsPassPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalTCsPassPercentage.Location = new System.Drawing.Point(842, 20);
            this.lbl_TotalTCsPassPercentage.Name = "lbl_TotalTCsPassPercentage";
            this.lbl_TotalTCsPassPercentage.Size = new System.Drawing.Size(206, 20);
            this.lbl_TotalTCsPassPercentage.TabIndex = 5;
            this.lbl_TotalTCsPassPercentage.Text = "Pass %";
            this.lbl_TotalTCsPassPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_TotalTCsFailed
            // 
            this.lbl_TotalTCsFailed.AutoSize = true;
            this.lbl_TotalTCsFailed.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lbl_TotalTCsFailed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_TotalTCsFailed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalTCsFailed.Location = new System.Drawing.Point(632, 20);
            this.lbl_TotalTCsFailed.Name = "lbl_TotalTCsFailed";
            this.lbl_TotalTCsFailed.Size = new System.Drawing.Size(204, 20);
            this.lbl_TotalTCsFailed.TabIndex = 4;
            this.lbl_TotalTCsFailed.Text = "Failed";
            this.lbl_TotalTCsFailed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_TotalTCsPassed
            // 
            this.lbl_TotalTCsPassed.AutoSize = true;
            this.lbl_TotalTCsPassed.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lbl_TotalTCsPassed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_TotalTCsPassed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalTCsPassed.Location = new System.Drawing.Point(422, 20);
            this.lbl_TotalTCsPassed.Name = "lbl_TotalTCsPassed";
            this.lbl_TotalTCsPassed.Size = new System.Drawing.Size(204, 20);
            this.lbl_TotalTCsPassed.TabIndex = 3;
            this.lbl_TotalTCsPassed.Text = "Passed";
            this.lbl_TotalTCsPassed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_TotalTCsExecuted
            // 
            this.lbl_TotalTCsExecuted.AutoSize = true;
            this.lbl_TotalTCsExecuted.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lbl_TotalTCsExecuted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_TotalTCsExecuted.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalTCsExecuted.Location = new System.Drawing.Point(217, 20);
            this.lbl_TotalTCsExecuted.Name = "lbl_TotalTCsExecuted";
            this.lbl_TotalTCsExecuted.Size = new System.Drawing.Size(199, 20);
            this.lbl_TotalTCsExecuted.TabIndex = 2;
            this.lbl_TotalTCsExecuted.Text = "Executed";
            this.lbl_TotalTCsExecuted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ExecutionSummary
            // 
            this.lbl_ExecutionSummary.AutoSize = true;
            this.lbl_ExecutionSummary.BackColor = System.Drawing.Color.LightBlue;
            this.tableLayout_ExecSummary.SetColumnSpan(this.lbl_ExecutionSummary, 5);
            this.lbl_ExecutionSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ExecutionSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ExecutionSummary.Location = new System.Drawing.Point(3, 0);
            this.lbl_ExecutionSummary.Name = "lbl_ExecutionSummary";
            this.lbl_ExecutionSummary.Size = new System.Drawing.Size(1045, 20);
            this.lbl_ExecutionSummary.TabIndex = 0;
            this.lbl_ExecutionSummary.Text = "Execution Summary";
            this.lbl_ExecutionSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_TotalTCs
            // 
            this.lbl_TotalTCs.AutoSize = true;
            this.lbl_TotalTCs.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lbl_TotalTCs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_TotalTCs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalTCs.Location = new System.Drawing.Point(3, 20);
            this.lbl_TotalTCs.Name = "lbl_TotalTCs";
            this.lbl_TotalTCs.Size = new System.Drawing.Size(208, 20);
            this.lbl_TotalTCs.TabIndex = 1;
            this.lbl_TotalTCs.Text = "Total Test Cases";
            this.lbl_TotalTCs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_TotalTCsResult
            // 
            this.lbl_TotalTCsResult.AutoSize = true;
            this.lbl_TotalTCsResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_TotalTCsResult.Location = new System.Drawing.Point(3, 40);
            this.lbl_TotalTCsResult.Name = "lbl_TotalTCsResult";
            this.lbl_TotalTCsResult.Size = new System.Drawing.Size(208, 19);
            this.lbl_TotalTCsResult.TabIndex = 6;
            this.lbl_TotalTCsResult.Text = "0";
            this.lbl_TotalTCsResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_TotalTCsExecutedResult
            // 
            this.lbl_TotalTCsExecutedResult.AutoSize = true;
            this.lbl_TotalTCsExecutedResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_TotalTCsExecutedResult.Location = new System.Drawing.Point(217, 40);
            this.lbl_TotalTCsExecutedResult.Name = "lbl_TotalTCsExecutedResult";
            this.lbl_TotalTCsExecutedResult.Size = new System.Drawing.Size(199, 19);
            this.lbl_TotalTCsExecutedResult.TabIndex = 11;
            this.lbl_TotalTCsExecutedResult.Text = "0";
            this.lbl_TotalTCsExecutedResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayout_Panel
            // 
            this.tableLayout_Panel.ColumnCount = 3;
            this.tableLayout_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayout_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayout_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayout_Panel.Controls.Add(this.pic_ClientLogo, 0, 0);
            this.tableLayout_Panel.Controls.Add(this.pic_CompanyLogo, 2, 0);
            this.tableLayout_Panel.Controls.Add(this.lbl_Header, 1, 0);
            this.tableLayout_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayout_Panel.Location = new System.Drawing.Point(0, 0);
            this.tableLayout_Panel.Name = "tableLayout_Panel";
            this.tableLayout_Panel.RowCount = 1;
            this.tableLayout_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout_Panel.Size = new System.Drawing.Size(1051, 73);
            this.tableLayout_Panel.TabIndex = 0;
            // 
            // pic_ClientLogo
            // 
            this.pic_ClientLogo.Dock = System.Windows.Forms.DockStyle.Fill;           
            this.pic_ClientLogo.Location = new System.Drawing.Point(3, 3);
            this.pic_ClientLogo.Name = "pic_ClientLogo";
            this.pic_ClientLogo.Size = new System.Drawing.Size(309, 67);
            this.pic_ClientLogo.TabIndex = 0;
            this.pic_ClientLogo.TabStop = false;
            // 
            // pic_CompanyLogo
            // 
            this.pic_CompanyLogo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pic_CompanyLogo.Location = new System.Drawing.Point(903, 3);
            this.pic_CompanyLogo.Name = "pic_CompanyLogo";
            this.pic_CompanyLogo.Size = new System.Drawing.Size(145, 67);
            this.pic_CompanyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pic_CompanyLogo.TabIndex = 1;
            this.pic_CompanyLogo.TabStop = false;
            // 
            // lbl_Header
            // 
            this.lbl_Header.AutoSize = true;
            this.lbl_Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Header.Location = new System.Drawing.Point(318, 0);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(414, 73);
            this.lbl_Header.TabIndex = 2;
            this.lbl_Header.Text = "Test Suite Executor";
            this.lbl_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bgWrkTestExecutor
            // 
            this.bgWrkTestExecutor.WorkerReportsProgress = true;
            this.bgWrkTestExecutor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWrkTestExecutor_DoWork);
            this.bgWrkTestExecutor.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWrkTestExecutor_ProgressChanged);
            this.bgWrkTestExecutor.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWrkTestExecutor_RunWorkerCompleted);
            // 
            // form_TestSuiteRunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1051, 538);
            this.Controls.Add(this.panel_Form);
            this.Name = "form_TestSuiteRunner";
            this.Text = "TestSuiteRunner";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.form_TestSuiteRunner_Load);
            this.panel_Form.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayout_Filter.ResumeLayout(false);
            this.tableLayout_Filter.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayout_ExecSummary.ResumeLayout(false);
            this.tableLayout_ExecSummary.PerformLayout();
            this.tableLayout_Panel.ResumeLayout(false);
            this.tableLayout_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ClientLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_CompanyLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Form;
        private System.Windows.Forms.TableLayoutPanel tableLayout_Panel;
        private System.Windows.Forms.PictureBox pic_ClientLogo;
        private System.Windows.Forms.PictureBox pic_CompanyLogo;
        private System.Windows.Forms.Label lbl_Header;
        private System.Windows.Forms.TableLayoutPanel tableLayout_ExecSummary;
        private System.Windows.Forms.Label lbl_ExecutionSummary;
        private System.Windows.Forms.Label lbl_TotalTCsPassPerResult;
        private System.Windows.Forms.Label lbl_TotalTCsFailedResult;
        private System.Windows.Forms.Label lbl_TotalTCsPassedResult;
        private System.Windows.Forms.Label lbl_TotalTCsResult;
        private System.Windows.Forms.Label lbl_TotalTCsPassPercentage;
        private System.Windows.Forms.Label lbl_TotalTCsFailed;
        private System.Windows.Forms.Label lbl_TotalTCsPassed;
        private System.Windows.Forms.Label lbl_TotalTCsExecuted;
        private System.Windows.Forms.Label lbl_TotalTCs;
        private System.Windows.Forms.TableLayoutPanel tableLayout_Filter;
        private System.Windows.Forms.ListBox lstbox_SubModule;
        private System.Windows.Forms.ListBox lstbox_Criteria;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox lstbox_Module;
        private System.Windows.Forms.Label lbl_FilterByCategory;
        private System.Windows.Forms.Label lbl_FilterBySubModule;
        private System.Windows.Forms.Label lbl_FilterByModule;
        private System.Windows.Forms.Button btn_ExecuteTests;
        private System.Windows.Forms.LinkLabel lnklbl_OverallExeStatResult;
        private System.Windows.Forms.Label lbl_TotalTCsExecutedResult;
        private System.Windows.Forms.ComboBox selectBrowser_Combobox;
        private System.Windows.Forms.Label lbl_selectBrowser;
        private System.ComponentModel.BackgroundWorker bgWrkTestExecutor;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkbox_SelectAll;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckedListBox chklBrowsers;
        private System.Windows.Forms.Label label1;
    }
}