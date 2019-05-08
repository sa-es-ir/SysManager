namespace GetBaseEventFromETW
{
    partial class UserRules
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PTSFileSuspend_rbtn = new System.Windows.Forms.RadioButton();
            this.PTSFileNoaction_rbtn = new System.Windows.Forms.RadioButton();
            this.PTSFileKill_rbtn = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.PTSFileRemove_btn = new System.Windows.Forms.Button();
            this.PTSFileAdd_btn = new System.Windows.Forms.Button();
            this.PTSFile_Listbox = new System.Windows.Forms.ListBox();
            this.PTSFileProcessName_txt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.FileCount_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SavePathFile_btn = new System.Windows.Forms.Button();
            this.PathList = new System.Windows.Forms.ListBox();
            this.RemoveSelectedPath_btn = new System.Windows.Forms.Button();
            this.AddPath_btn = new System.Windows.Forms.Button();
            this.BrowsePath_btn = new System.Windows.Forms.Button();
            this.Pathtxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PTKRegSuspend_rbtn = new System.Windows.Forms.RadioButton();
            this.PTKRegNoAction_rbtn = new System.Windows.Forms.RadioButton();
            this.PTKRegKill_rbtn = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.PTKRegRemove_btn = new System.Windows.Forms.Button();
            this.PTKRegAdd_btn = new System.Windows.Forms.Button();
            this.PTKReg_ListBox = new System.Windows.Forms.ListBox();
            this.PTKRegProcessName_txt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.SaveRegSetting_btn = new System.Windows.Forms.Button();
            this.KeyPath_ListBox = new System.Windows.Forms.ListBox();
            this.RemoveKePath_btn = new System.Windows.Forms.Button();
            this.AddKeyPath_btn = new System.Windows.Forms.Button();
            this.KeyPath_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.PTSNetSuspend_rbtn = new System.Windows.Forms.RadioButton();
            this.PTSNetNoAction_rbtn = new System.Windows.Forms.RadioButton();
            this.PTSNetKill_rbtn = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.PTSNetRemove_btn = new System.Windows.Forms.Button();
            this.PTSNetAdd_btn = new System.Windows.Forms.Button();
            this.PTSNet_ListBox = new System.Windows.Forms.ListBox();
            this.PTSNetProcessName_txt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SaveNetSetting_btn = new System.Windows.Forms.Button();
            this.Port_ListBox = new System.Windows.Forms.ListBox();
            this.RemovePort_btn = new System.Windows.Forms.Button();
            this.IPAddr_ListBox = new System.Windows.Forms.ListBox();
            this.AddPort_btn = new System.Windows.Forms.Button();
            this.RemoveIPAddr_btn = new System.Windows.Forms.Button();
            this.Port_txt = new System.Windows.Forms.TextBox();
            this.AddIPAddr_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.IPAdd_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ProcessSkipRemove_btn = new System.Windows.Forms.Button();
            this.ProcessSkip_btn = new System.Windows.Forms.Button();
            this.ProcessSkip_listbox = new System.Windows.Forms.ListBox();
            this.ProcessNameSkip_txt = new System.Windows.Forms.TextBox();
            this.ProcessSkipSuspendRadio_btn = new System.Windows.Forms.RadioButton();
            this.ProcessSkipNoActionRadio_btn = new System.Windows.Forms.RadioButton();
            this.ProcessSkipKillRadio_btn = new System.Windows.Forms.RadioButton();
            this.AddHash_btn = new System.Windows.Forms.Button();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.SaveHashbtn = new System.Windows.Forms.Button();
            this.HashFiletxt = new System.Windows.Forms.TextBox();
            this.HashFilebtn = new System.Windows.Forms.Button();
            this.FilePathbtn = new System.Windows.Forms.Button();
            this.FilePathtxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 394);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Silver;
            this.tabPage1.Controls.Add(this.PTSFileSuspend_rbtn);
            this.tabPage1.Controls.Add(this.PTSFileNoaction_rbtn);
            this.tabPage1.Controls.Add(this.PTSFileKill_rbtn);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.PTSFileRemove_btn);
            this.tabPage1.Controls.Add(this.PTSFileAdd_btn);
            this.tabPage1.Controls.Add(this.PTSFile_Listbox);
            this.tabPage1.Controls.Add(this.PTSFileProcessName_txt);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.FileCount_txt);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.SavePathFile_btn);
            this.tabPage1.Controls.Add(this.PathList);
            this.tabPage1.Controls.Add(this.RemoveSelectedPath_btn);
            this.tabPage1.Controls.Add(this.AddPath_btn);
            this.tabPage1.Controls.Add(this.BrowsePath_btn);
            this.tabPage1.Controls.Add(this.Pathtxt);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(976, 368);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "File Rules";
            // 
            // PTSFileSuspend_rbtn
            // 
            this.PTSFileSuspend_rbtn.AutoSize = true;
            this.PTSFileSuspend_rbtn.Location = new System.Drawing.Point(548, 111);
            this.PTSFileSuspend_rbtn.Name = "PTSFileSuspend_rbtn";
            this.PTSFileSuspend_rbtn.Size = new System.Drawing.Size(108, 17);
            this.PTSFileSuspend_rbtn.TabIndex = 38;
            this.PTSFileSuspend_rbtn.TabStop = true;
            this.PTSFileSuspend_rbtn.Text = "Suspend Process";
            this.PTSFileSuspend_rbtn.UseVisualStyleBackColor = true;
            this.PTSFileSuspend_rbtn.Visible = false;
            // 
            // PTSFileNoaction_rbtn
            // 
            this.PTSFileNoaction_rbtn.AutoSize = true;
            this.PTSFileNoaction_rbtn.Location = new System.Drawing.Point(548, 71);
            this.PTSFileNoaction_rbtn.Name = "PTSFileNoaction_rbtn";
            this.PTSFileNoaction_rbtn.Size = new System.Drawing.Size(72, 17);
            this.PTSFileNoaction_rbtn.TabIndex = 39;
            this.PTSFileNoaction_rbtn.TabStop = true;
            this.PTSFileNoaction_rbtn.Text = "No Action";
            this.PTSFileNoaction_rbtn.UseVisualStyleBackColor = true;
            // 
            // PTSFileKill_rbtn
            // 
            this.PTSFileKill_rbtn.AutoSize = true;
            this.PTSFileKill_rbtn.Location = new System.Drawing.Point(548, 94);
            this.PTSFileKill_rbtn.Name = "PTSFileKill_rbtn";
            this.PTSFileKill_rbtn.Size = new System.Drawing.Size(79, 17);
            this.PTSFileKill_rbtn.TabIndex = 40;
            this.PTSFileKill_rbtn.TabStop = true;
            this.PTSFileKill_rbtn.Text = "Kill Process";
            this.PTSFileKill_rbtn.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label14.Location = new System.Drawing.Point(545, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "processes if run:";
            // 
            // PTSFileRemove_btn
            // 
            this.PTSFileRemove_btn.Location = new System.Drawing.Point(746, 268);
            this.PTSFileRemove_btn.Name = "PTSFileRemove_btn";
            this.PTSFileRemove_btn.Size = new System.Drawing.Size(116, 23);
            this.PTSFileRemove_btn.TabIndex = 36;
            this.PTSFileRemove_btn.Text = "Remove item";
            this.PTSFileRemove_btn.UseVisualStyleBackColor = true;
            this.PTSFileRemove_btn.Click += new System.EventHandler(this.PTSFileRemove_btn_Click);
            // 
            // PTSFileAdd_btn
            // 
            this.PTSFileAdd_btn.Location = new System.Drawing.Point(802, 158);
            this.PTSFileAdd_btn.Name = "PTSFileAdd_btn";
            this.PTSFileAdd_btn.Size = new System.Drawing.Size(75, 23);
            this.PTSFileAdd_btn.TabIndex = 35;
            this.PTSFileAdd_btn.Text = "Add";
            this.PTSFileAdd_btn.UseVisualStyleBackColor = true;
            this.PTSFileAdd_btn.Click += new System.EventHandler(this.PTSFileAdd_btn_Click);
            // 
            // PTSFile_Listbox
            // 
            this.PTSFile_Listbox.FormattingEnabled = true;
            this.PTSFile_Listbox.Location = new System.Drawing.Point(548, 196);
            this.PTSFile_Listbox.Name = "PTSFile_Listbox";
            this.PTSFile_Listbox.Size = new System.Drawing.Size(192, 95);
            this.PTSFile_Listbox.TabIndex = 34;
            // 
            // PTSFileProcessName_txt
            // 
            this.PTSFileProcessName_txt.Location = new System.Drawing.Point(548, 158);
            this.PTSFileProcessName_txt.Name = "PTSFileProcessName_txt";
            this.PTSFileProcessName_txt.Size = new System.Drawing.Size(248, 20);
            this.PTSFileProcessName_txt.TabIndex = 33;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label15.Location = new System.Drawing.Point(545, 142);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(128, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Process name to skip";
            // 
            // FileCount_txt
            // 
            this.FileCount_txt.Location = new System.Drawing.Point(216, 252);
            this.FileCount_txt.Name = "FileCount_txt";
            this.FileCount_txt.Size = new System.Drawing.Size(100, 20);
            this.FileCount_txt.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(6, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Max File Count For Process Access";
            // 
            // SavePathFile_btn
            // 
            this.SavePathFile_btn.Location = new System.Drawing.Point(9, 329);
            this.SavePathFile_btn.Name = "SavePathFile_btn";
            this.SavePathFile_btn.Size = new System.Drawing.Size(102, 23);
            this.SavePathFile_btn.TabIndex = 4;
            this.SavePathFile_btn.Text = "Save Setting";
            this.SavePathFile_btn.UseVisualStyleBackColor = true;
            this.SavePathFile_btn.Click += new System.EventHandler(this.SavePathFile_btn_Click);
            // 
            // PathList
            // 
            this.PathList.FormattingEnabled = true;
            this.PathList.Location = new System.Drawing.Point(9, 99);
            this.PathList.Name = "PathList";
            this.PathList.ScrollAlwaysVisible = true;
            this.PathList.Size = new System.Drawing.Size(300, 108);
            this.PathList.TabIndex = 3;
            this.PathList.SelectedIndexChanged += new System.EventHandler(this.PathList_SelectedIndexChanged);
            // 
            // RemoveSelectedPath_btn
            // 
            this.RemoveSelectedPath_btn.Location = new System.Drawing.Point(315, 184);
            this.RemoveSelectedPath_btn.Name = "RemoveSelectedPath_btn";
            this.RemoveSelectedPath_btn.Size = new System.Drawing.Size(137, 23);
            this.RemoveSelectedPath_btn.TabIndex = 2;
            this.RemoveSelectedPath_btn.Text = "Remove Selected Path";
            this.RemoveSelectedPath_btn.UseVisualStyleBackColor = true;
            this.RemoveSelectedPath_btn.Click += new System.EventHandler(this.RemoveSelectedPath_btn_Click);
            // 
            // AddPath_btn
            // 
            this.AddPath_btn.Location = new System.Drawing.Point(353, 41);
            this.AddPath_btn.Name = "AddPath_btn";
            this.AddPath_btn.Size = new System.Drawing.Size(66, 23);
            this.AddPath_btn.TabIndex = 2;
            this.AddPath_btn.Text = "Add Path";
            this.AddPath_btn.UseVisualStyleBackColor = true;
            this.AddPath_btn.Click += new System.EventHandler(this.AddPath_btn_Click);
            // 
            // BrowsePath_btn
            // 
            this.BrowsePath_btn.Location = new System.Drawing.Point(315, 41);
            this.BrowsePath_btn.Name = "BrowsePath_btn";
            this.BrowsePath_btn.Size = new System.Drawing.Size(32, 23);
            this.BrowsePath_btn.TabIndex = 2;
            this.BrowsePath_btn.Text = "...";
            this.BrowsePath_btn.UseVisualStyleBackColor = true;
            this.BrowsePath_btn.Click += new System.EventHandler(this.BrowsePath_btn_Click);
            // 
            // Pathtxt
            // 
            this.Pathtxt.Location = new System.Drawing.Point(9, 41);
            this.Pathtxt.Name = "Pathtxt";
            this.Pathtxt.Size = new System.Drawing.Size(300, 20);
            this.Pathtxt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Insert Path To Restrict File Events";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Silver;
            this.tabPage2.Controls.Add(this.PTKRegSuspend_rbtn);
            this.tabPage2.Controls.Add(this.PTKRegNoAction_rbtn);
            this.tabPage2.Controls.Add(this.PTKRegKill_rbtn);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.PTKRegRemove_btn);
            this.tabPage2.Controls.Add(this.PTKRegAdd_btn);
            this.tabPage2.Controls.Add(this.PTKReg_ListBox);
            this.tabPage2.Controls.Add(this.PTKRegProcessName_txt);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.SaveRegSetting_btn);
            this.tabPage2.Controls.Add(this.KeyPath_ListBox);
            this.tabPage2.Controls.Add(this.RemoveKePath_btn);
            this.tabPage2.Controls.Add(this.AddKeyPath_btn);
            this.tabPage2.Controls.Add(this.KeyPath_txt);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(976, 368);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Registry Rules";
            // 
            // PTKRegSuspend_rbtn
            // 
            this.PTKRegSuspend_rbtn.AutoSize = true;
            this.PTKRegSuspend_rbtn.Location = new System.Drawing.Point(563, 100);
            this.PTKRegSuspend_rbtn.Name = "PTKRegSuspend_rbtn";
            this.PTKRegSuspend_rbtn.Size = new System.Drawing.Size(108, 17);
            this.PTKRegSuspend_rbtn.TabIndex = 38;
            this.PTKRegSuspend_rbtn.TabStop = true;
            this.PTKRegSuspend_rbtn.Text = "Suspend Process";
            this.PTKRegSuspend_rbtn.UseVisualStyleBackColor = true;
            this.PTKRegSuspend_rbtn.Visible = false;
            // 
            // PTKRegNoAction_rbtn
            // 
            this.PTKRegNoAction_rbtn.AutoSize = true;
            this.PTKRegNoAction_rbtn.Location = new System.Drawing.Point(563, 60);
            this.PTKRegNoAction_rbtn.Name = "PTKRegNoAction_rbtn";
            this.PTKRegNoAction_rbtn.Size = new System.Drawing.Size(72, 17);
            this.PTKRegNoAction_rbtn.TabIndex = 39;
            this.PTKRegNoAction_rbtn.TabStop = true;
            this.PTKRegNoAction_rbtn.Text = "No Action";
            this.PTKRegNoAction_rbtn.UseVisualStyleBackColor = true;
            // 
            // PTKRegKill_rbtn
            // 
            this.PTKRegKill_rbtn.AutoSize = true;
            this.PTKRegKill_rbtn.Location = new System.Drawing.Point(563, 83);
            this.PTKRegKill_rbtn.Name = "PTKRegKill_rbtn";
            this.PTKRegKill_rbtn.Size = new System.Drawing.Size(79, 17);
            this.PTKRegKill_rbtn.TabIndex = 40;
            this.PTKRegKill_rbtn.TabStop = true;
            this.PTKRegKill_rbtn.Text = "Kill Process";
            this.PTKRegKill_rbtn.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label12.Location = new System.Drawing.Point(560, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(136, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Other processes if run:";
            // 
            // PTKRegRemove_btn
            // 
            this.PTKRegRemove_btn.Location = new System.Drawing.Point(761, 257);
            this.PTKRegRemove_btn.Name = "PTKRegRemove_btn";
            this.PTKRegRemove_btn.Size = new System.Drawing.Size(116, 23);
            this.PTKRegRemove_btn.TabIndex = 36;
            this.PTKRegRemove_btn.Text = "Remove item";
            this.PTKRegRemove_btn.UseVisualStyleBackColor = true;
            this.PTKRegRemove_btn.Click += new System.EventHandler(this.PTKRegRemove_btn_Click);
            // 
            // PTKRegAdd_btn
            // 
            this.PTKRegAdd_btn.Location = new System.Drawing.Point(817, 147);
            this.PTKRegAdd_btn.Name = "PTKRegAdd_btn";
            this.PTKRegAdd_btn.Size = new System.Drawing.Size(75, 23);
            this.PTKRegAdd_btn.TabIndex = 35;
            this.PTKRegAdd_btn.Text = "Add";
            this.PTKRegAdd_btn.UseVisualStyleBackColor = true;
            this.PTKRegAdd_btn.Click += new System.EventHandler(this.PTKRegAdd_btn_Click);
            // 
            // PTKReg_ListBox
            // 
            this.PTKReg_ListBox.FormattingEnabled = true;
            this.PTKReg_ListBox.Location = new System.Drawing.Point(563, 185);
            this.PTKReg_ListBox.Name = "PTKReg_ListBox";
            this.PTKReg_ListBox.Size = new System.Drawing.Size(192, 95);
            this.PTKReg_ListBox.TabIndex = 34;
            // 
            // PTKRegProcessName_txt
            // 
            this.PTKRegProcessName_txt.Location = new System.Drawing.Point(563, 147);
            this.PTKRegProcessName_txt.Name = "PTKRegProcessName_txt";
            this.PTKRegProcessName_txt.Size = new System.Drawing.Size(248, 20);
            this.PTKRegProcessName_txt.TabIndex = 33;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label13.Location = new System.Drawing.Point(560, 131);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Process name to skip";
            // 
            // SaveRegSetting_btn
            // 
            this.SaveRegSetting_btn.Location = new System.Drawing.Point(13, 232);
            this.SaveRegSetting_btn.Name = "SaveRegSetting_btn";
            this.SaveRegSetting_btn.Size = new System.Drawing.Size(102, 23);
            this.SaveRegSetting_btn.TabIndex = 13;
            this.SaveRegSetting_btn.Text = "Save Setting";
            this.SaveRegSetting_btn.UseVisualStyleBackColor = true;
            this.SaveRegSetting_btn.Click += new System.EventHandler(this.SaveRegSetting_btn_Click);
            // 
            // KeyPath_ListBox
            // 
            this.KeyPath_ListBox.FormattingEnabled = true;
            this.KeyPath_ListBox.Location = new System.Drawing.Point(13, 74);
            this.KeyPath_ListBox.Name = "KeyPath_ListBox";
            this.KeyPath_ListBox.Size = new System.Drawing.Size(300, 108);
            this.KeyPath_ListBox.TabIndex = 12;
            // 
            // RemoveKePath_btn
            // 
            this.RemoveKePath_btn.Location = new System.Drawing.Point(319, 159);
            this.RemoveKePath_btn.Name = "RemoveKePath_btn";
            this.RemoveKePath_btn.Size = new System.Drawing.Size(149, 23);
            this.RemoveKePath_btn.TabIndex = 9;
            this.RemoveKePath_btn.Text = "Remove Selected Key Path";
            this.RemoveKePath_btn.UseVisualStyleBackColor = true;
            this.RemoveKePath_btn.Click += new System.EventHandler(this.RemoveKePath_btn_Click);
            // 
            // AddKeyPath_btn
            // 
            this.AddKeyPath_btn.Location = new System.Drawing.Point(319, 35);
            this.AddKeyPath_btn.Name = "AddKeyPath_btn";
            this.AddKeyPath_btn.Size = new System.Drawing.Size(84, 23);
            this.AddKeyPath_btn.TabIndex = 10;
            this.AddKeyPath_btn.Text = "Add Key Path";
            this.AddKeyPath_btn.UseVisualStyleBackColor = true;
            this.AddKeyPath_btn.Click += new System.EventHandler(this.AddKeyPath_btn_Click);
            // 
            // KeyPath_txt
            // 
            this.KeyPath_txt.Location = new System.Drawing.Point(13, 37);
            this.KeyPath_txt.Name = "KeyPath_txt";
            this.KeyPath_txt.Size = new System.Drawing.Size(300, 20);
            this.KeyPath_txt.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(10, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(254, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Insert Key Path To Restrict Registry Events";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Silver;
            this.tabPage3.Controls.Add(this.PTSNetSuspend_rbtn);
            this.tabPage3.Controls.Add(this.PTSNetNoAction_rbtn);
            this.tabPage3.Controls.Add(this.PTSNetKill_rbtn);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.PTSNetRemove_btn);
            this.tabPage3.Controls.Add(this.PTSNetAdd_btn);
            this.tabPage3.Controls.Add(this.PTSNet_ListBox);
            this.tabPage3.Controls.Add(this.PTSNetProcessName_txt);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.SaveNetSetting_btn);
            this.tabPage3.Controls.Add(this.Port_ListBox);
            this.tabPage3.Controls.Add(this.RemovePort_btn);
            this.tabPage3.Controls.Add(this.IPAddr_ListBox);
            this.tabPage3.Controls.Add(this.AddPort_btn);
            this.tabPage3.Controls.Add(this.RemoveIPAddr_btn);
            this.tabPage3.Controls.Add(this.Port_txt);
            this.tabPage3.Controls.Add(this.AddIPAddr_btn);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.IPAdd_txt);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(976, 368);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Network Rules";
            // 
            // PTSNetSuspend_rbtn
            // 
            this.PTSNetSuspend_rbtn.AutoSize = true;
            this.PTSNetSuspend_rbtn.Location = new System.Drawing.Point(533, 117);
            this.PTSNetSuspend_rbtn.Name = "PTSNetSuspend_rbtn";
            this.PTSNetSuspend_rbtn.Size = new System.Drawing.Size(108, 17);
            this.PTSNetSuspend_rbtn.TabIndex = 29;
            this.PTSNetSuspend_rbtn.TabStop = true;
            this.PTSNetSuspend_rbtn.Text = "Suspend Process";
            this.PTSNetSuspend_rbtn.UseVisualStyleBackColor = true;
            this.PTSNetSuspend_rbtn.Visible = false;
            // 
            // PTSNetNoAction_rbtn
            // 
            this.PTSNetNoAction_rbtn.AutoSize = true;
            this.PTSNetNoAction_rbtn.Location = new System.Drawing.Point(533, 77);
            this.PTSNetNoAction_rbtn.Name = "PTSNetNoAction_rbtn";
            this.PTSNetNoAction_rbtn.Size = new System.Drawing.Size(72, 17);
            this.PTSNetNoAction_rbtn.TabIndex = 30;
            this.PTSNetNoAction_rbtn.TabStop = true;
            this.PTSNetNoAction_rbtn.Text = "No Action";
            this.PTSNetNoAction_rbtn.UseVisualStyleBackColor = true;
            // 
            // PTSNetKill_rbtn
            // 
            this.PTSNetKill_rbtn.AutoSize = true;
            this.PTSNetKill_rbtn.Location = new System.Drawing.Point(533, 100);
            this.PTSNetKill_rbtn.Name = "PTSNetKill_rbtn";
            this.PTSNetKill_rbtn.Size = new System.Drawing.Size(79, 17);
            this.PTSNetKill_rbtn.TabIndex = 31;
            this.PTSNetKill_rbtn.TabStop = true;
            this.PTSNetKill_rbtn.Text = "Kill Process";
            this.PTSNetKill_rbtn.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.Location = new System.Drawing.Point(530, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Other processes if run:";
            // 
            // PTSNetRemove_btn
            // 
            this.PTSNetRemove_btn.Location = new System.Drawing.Point(731, 274);
            this.PTSNetRemove_btn.Name = "PTSNetRemove_btn";
            this.PTSNetRemove_btn.Size = new System.Drawing.Size(116, 23);
            this.PTSNetRemove_btn.TabIndex = 27;
            this.PTSNetRemove_btn.Text = "Remove item";
            this.PTSNetRemove_btn.UseVisualStyleBackColor = true;
            this.PTSNetRemove_btn.Click += new System.EventHandler(this.PTSNetRemove_btn_Click);
            // 
            // PTSNetAdd_btn
            // 
            this.PTSNetAdd_btn.Location = new System.Drawing.Point(787, 164);
            this.PTSNetAdd_btn.Name = "PTSNetAdd_btn";
            this.PTSNetAdd_btn.Size = new System.Drawing.Size(75, 23);
            this.PTSNetAdd_btn.TabIndex = 26;
            this.PTSNetAdd_btn.Text = "Add";
            this.PTSNetAdd_btn.UseVisualStyleBackColor = true;
            this.PTSNetAdd_btn.Click += new System.EventHandler(this.PTSNetAdd_btn_Click);
            // 
            // PTSNet_ListBox
            // 
            this.PTSNet_ListBox.FormattingEnabled = true;
            this.PTSNet_ListBox.Location = new System.Drawing.Point(533, 202);
            this.PTSNet_ListBox.Name = "PTSNet_ListBox";
            this.PTSNet_ListBox.Size = new System.Drawing.Size(192, 95);
            this.PTSNet_ListBox.TabIndex = 25;
            // 
            // PTSNetProcessName_txt
            // 
            this.PTSNetProcessName_txt.Location = new System.Drawing.Point(533, 164);
            this.PTSNetProcessName_txt.Name = "PTSNetProcessName_txt";
            this.PTSNetProcessName_txt.Size = new System.Drawing.Size(248, 20);
            this.PTSNetProcessName_txt.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label11.Location = new System.Drawing.Point(530, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Process name to skip";
            // 
            // SaveNetSetting_btn
            // 
            this.SaveNetSetting_btn.Location = new System.Drawing.Point(18, 339);
            this.SaveNetSetting_btn.Name = "SaveNetSetting_btn";
            this.SaveNetSetting_btn.Size = new System.Drawing.Size(102, 23);
            this.SaveNetSetting_btn.TabIndex = 19;
            this.SaveNetSetting_btn.Text = "Save Setting";
            this.SaveNetSetting_btn.UseVisualStyleBackColor = true;
            this.SaveNetSetting_btn.Click += new System.EventHandler(this.SaveNetSetting_btn_Click);
            // 
            // Port_ListBox
            // 
            this.Port_ListBox.FormattingEnabled = true;
            this.Port_ListBox.Location = new System.Drawing.Point(18, 243);
            this.Port_ListBox.Name = "Port_ListBox";
            this.Port_ListBox.Size = new System.Drawing.Size(300, 69);
            this.Port_ListBox.TabIndex = 18;
            // 
            // RemovePort_btn
            // 
            this.RemovePort_btn.Location = new System.Drawing.Point(324, 289);
            this.RemovePort_btn.Name = "RemovePort_btn";
            this.RemovePort_btn.Size = new System.Drawing.Size(149, 23);
            this.RemovePort_btn.TabIndex = 16;
            this.RemovePort_btn.Text = "Remove Selected IP Address";
            this.RemovePort_btn.UseVisualStyleBackColor = true;
            this.RemovePort_btn.Click += new System.EventHandler(this.RemovePort_btn_Click);
            // 
            // IPAddr_ListBox
            // 
            this.IPAddr_ListBox.FormattingEnabled = true;
            this.IPAddr_ListBox.Location = new System.Drawing.Point(18, 82);
            this.IPAddr_ListBox.Name = "IPAddr_ListBox";
            this.IPAddr_ListBox.Size = new System.Drawing.Size(300, 108);
            this.IPAddr_ListBox.TabIndex = 18;
            // 
            // AddPort_btn
            // 
            this.AddPort_btn.Location = new System.Drawing.Point(324, 215);
            this.AddPort_btn.Name = "AddPort_btn";
            this.AddPort_btn.Size = new System.Drawing.Size(99, 23);
            this.AddPort_btn.TabIndex = 17;
            this.AddPort_btn.Text = "Add Port";
            this.AddPort_btn.UseVisualStyleBackColor = true;
            this.AddPort_btn.Click += new System.EventHandler(this.AddPort_btn_Click);
            // 
            // RemoveIPAddr_btn
            // 
            this.RemoveIPAddr_btn.Location = new System.Drawing.Point(324, 167);
            this.RemoveIPAddr_btn.Name = "RemoveIPAddr_btn";
            this.RemoveIPAddr_btn.Size = new System.Drawing.Size(149, 23);
            this.RemoveIPAddr_btn.TabIndex = 16;
            this.RemoveIPAddr_btn.Text = "Remove Selected IP Address";
            this.RemoveIPAddr_btn.UseVisualStyleBackColor = true;
            this.RemoveIPAddr_btn.Click += new System.EventHandler(this.RemoveIPAddr_btn_Click);
            // 
            // Port_txt
            // 
            this.Port_txt.Location = new System.Drawing.Point(18, 217);
            this.Port_txt.Name = "Port_txt";
            this.Port_txt.Size = new System.Drawing.Size(300, 20);
            this.Port_txt.TabIndex = 15;
            // 
            // AddIPAddr_btn
            // 
            this.AddIPAddr_btn.Location = new System.Drawing.Point(324, 43);
            this.AddIPAddr_btn.Name = "AddIPAddr_btn";
            this.AddIPAddr_btn.Size = new System.Drawing.Size(99, 23);
            this.AddIPAddr_btn.TabIndex = 17;
            this.AddIPAddr_btn.Text = "Add IP Address";
            this.AddIPAddr_btn.UseVisualStyleBackColor = true;
            this.AddIPAddr_btn.Click += new System.EventHandler(this.AddIPAddr_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(15, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Add Port To Block";
            // 
            // IPAdd_txt
            // 
            this.IPAdd_txt.Location = new System.Drawing.Point(18, 45);
            this.IPAdd_txt.Name = "IPAdd_txt";
            this.IPAdd_txt.Size = new System.Drawing.Size(300, 20);
            this.IPAdd_txt.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(15, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Add IP Address To Block";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Silver;
            this.tabPage4.Controls.Add(this.ProcessSkipRemove_btn);
            this.tabPage4.Controls.Add(this.ProcessSkip_btn);
            this.tabPage4.Controls.Add(this.ProcessSkip_listbox);
            this.tabPage4.Controls.Add(this.ProcessNameSkip_txt);
            this.tabPage4.Controls.Add(this.ProcessSkipSuspendRadio_btn);
            this.tabPage4.Controls.Add(this.ProcessSkipNoActionRadio_btn);
            this.tabPage4.Controls.Add(this.ProcessSkipKillRadio_btn);
            this.tabPage4.Controls.Add(this.AddHash_btn);
            this.tabPage4.Controls.Add(this.dataGridViewX1);
            this.tabPage4.Controls.Add(this.SaveHashbtn);
            this.tabPage4.Controls.Add(this.HashFiletxt);
            this.tabPage4.Controls.Add(this.HashFilebtn);
            this.tabPage4.Controls.Add(this.FilePathbtn);
            this.tabPage4.Controls.Add(this.FilePathtxt);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(976, 368);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Process Rules";
            // 
            // ProcessSkipRemove_btn
            // 
            this.ProcessSkipRemove_btn.Location = new System.Drawing.Point(880, 301);
            this.ProcessSkipRemove_btn.Name = "ProcessSkipRemove_btn";
            this.ProcessSkipRemove_btn.Size = new System.Drawing.Size(89, 23);
            this.ProcessSkipRemove_btn.TabIndex = 19;
            this.ProcessSkipRemove_btn.Text = "Remove item";
            this.ProcessSkipRemove_btn.UseVisualStyleBackColor = true;
            this.ProcessSkipRemove_btn.Click += new System.EventHandler(this.ProcessSkipRemove_btn_Click);
            // 
            // ProcessSkip_btn
            // 
            this.ProcessSkip_btn.Location = new System.Drawing.Point(682, 208);
            this.ProcessSkip_btn.Name = "ProcessSkip_btn";
            this.ProcessSkip_btn.Size = new System.Drawing.Size(60, 23);
            this.ProcessSkip_btn.TabIndex = 18;
            this.ProcessSkip_btn.Text = "Add";
            this.ProcessSkip_btn.UseVisualStyleBackColor = true;
            this.ProcessSkip_btn.Click += new System.EventHandler(this.ProcessSkip_btn_Click);
            // 
            // ProcessSkip_listbox
            // 
            this.ProcessSkip_listbox.FormattingEnabled = true;
            this.ProcessSkip_listbox.Location = new System.Drawing.Point(682, 237);
            this.ProcessSkip_listbox.Name = "ProcessSkip_listbox";
            this.ProcessSkip_listbox.Size = new System.Drawing.Size(192, 95);
            this.ProcessSkip_listbox.TabIndex = 17;
            this.ProcessSkip_listbox.SelectedIndexChanged += new System.EventHandler(this.ProcessSkip_listbox_SelectedIndexChanged);
            // 
            // ProcessNameSkip_txt
            // 
            this.ProcessNameSkip_txt.Location = new System.Drawing.Point(682, 182);
            this.ProcessNameSkip_txt.Name = "ProcessNameSkip_txt";
            this.ProcessNameSkip_txt.Size = new System.Drawing.Size(248, 20);
            this.ProcessNameSkip_txt.TabIndex = 16;
            // 
            // ProcessSkipSuspendRadio_btn
            // 
            this.ProcessSkipSuspendRadio_btn.AutoSize = true;
            this.ProcessSkipSuspendRadio_btn.Location = new System.Drawing.Point(682, 141);
            this.ProcessSkipSuspendRadio_btn.Name = "ProcessSkipSuspendRadio_btn";
            this.ProcessSkipSuspendRadio_btn.Size = new System.Drawing.Size(108, 17);
            this.ProcessSkipSuspendRadio_btn.TabIndex = 15;
            this.ProcessSkipSuspendRadio_btn.TabStop = true;
            this.ProcessSkipSuspendRadio_btn.Text = "Suspend Process";
            this.ProcessSkipSuspendRadio_btn.UseVisualStyleBackColor = true;
            this.ProcessSkipSuspendRadio_btn.Visible = false;
            // 
            // ProcessSkipNoActionRadio_btn
            // 
            this.ProcessSkipNoActionRadio_btn.AutoSize = true;
            this.ProcessSkipNoActionRadio_btn.Location = new System.Drawing.Point(682, 101);
            this.ProcessSkipNoActionRadio_btn.Name = "ProcessSkipNoActionRadio_btn";
            this.ProcessSkipNoActionRadio_btn.Size = new System.Drawing.Size(72, 17);
            this.ProcessSkipNoActionRadio_btn.TabIndex = 15;
            this.ProcessSkipNoActionRadio_btn.TabStop = true;
            this.ProcessSkipNoActionRadio_btn.Text = "No Action";
            this.ProcessSkipNoActionRadio_btn.UseVisualStyleBackColor = true;
            // 
            // ProcessSkipKillRadio_btn
            // 
            this.ProcessSkipKillRadio_btn.AutoSize = true;
            this.ProcessSkipKillRadio_btn.Location = new System.Drawing.Point(682, 124);
            this.ProcessSkipKillRadio_btn.Name = "ProcessSkipKillRadio_btn";
            this.ProcessSkipKillRadio_btn.Size = new System.Drawing.Size(79, 17);
            this.ProcessSkipKillRadio_btn.TabIndex = 15;
            this.ProcessSkipKillRadio_btn.TabStop = true;
            this.ProcessSkipKillRadio_btn.Text = "Kill Process";
            this.ProcessSkipKillRadio_btn.UseVisualStyleBackColor = true;
            // 
            // AddHash_btn
            // 
            this.AddHash_btn.Location = new System.Drawing.Point(563, 95);
            this.AddHash_btn.Name = "AddHash_btn";
            this.AddHash_btn.Size = new System.Drawing.Size(62, 23);
            this.AddHash_btn.TabIndex = 14;
            this.AddHash_btn.Text = "Add";
            this.AddHash_btn.UseVisualStyleBackColor = true;
            this.AddHash_btn.Click += new System.EventHandler(this.AddHash_btn_Click);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(95, 195);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.Size = new System.Drawing.Size(462, 137);
            this.dataGridViewX1.TabIndex = 13;
            this.dataGridViewX1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Operation";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.Text = "Delete";
            this.Column1.ToolTipText = "Delete";
            this.Column1.UseColumnTextForButtonValue = true;
            // 
            // SaveHashbtn
            // 
            this.SaveHashbtn.Location = new System.Drawing.Point(95, 339);
            this.SaveHashbtn.Name = "SaveHashbtn";
            this.SaveHashbtn.Size = new System.Drawing.Size(97, 23);
            this.SaveHashbtn.TabIndex = 12;
            this.SaveHashbtn.Text = "Save Setting";
            this.SaveHashbtn.UseVisualStyleBackColor = true;
            this.SaveHashbtn.Click += new System.EventHandler(this.SaveHashbtn_Click);
            // 
            // HashFiletxt
            // 
            this.HashFiletxt.Enabled = false;
            this.HashFiletxt.Location = new System.Drawing.Point(95, 97);
            this.HashFiletxt.Multiline = true;
            this.HashFiletxt.Name = "HashFiletxt";
            this.HashFiletxt.Size = new System.Drawing.Size(462, 61);
            this.HashFiletxt.TabIndex = 11;
            // 
            // HashFilebtn
            // 
            this.HashFilebtn.Location = new System.Drawing.Point(95, 71);
            this.HashFilebtn.Name = "HashFilebtn";
            this.HashFilebtn.Size = new System.Drawing.Size(97, 23);
            this.HashFilebtn.TabIndex = 10;
            this.HashFilebtn.Text = "Get Hash File";
            this.HashFilebtn.UseVisualStyleBackColor = true;
            this.HashFilebtn.Click += new System.EventHandler(this.HashFilebtn_Click);
            // 
            // FilePathbtn
            // 
            this.FilePathbtn.Location = new System.Drawing.Point(563, 33);
            this.FilePathbtn.Name = "FilePathbtn";
            this.FilePathbtn.Size = new System.Drawing.Size(39, 23);
            this.FilePathbtn.TabIndex = 9;
            this.FilePathbtn.Text = "...";
            this.FilePathbtn.UseVisualStyleBackColor = true;
            this.FilePathbtn.Click += new System.EventHandler(this.FilePathbtn_Click);
            // 
            // FilePathtxt
            // 
            this.FilePathtxt.Location = new System.Drawing.Point(95, 35);
            this.FilePathtxt.Name = "FilePathtxt";
            this.FilePathtxt.Size = new System.Drawing.Size(462, 20);
            this.FilePathtxt.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(679, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Other processes if run:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(3, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "SHA512 Hash";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(679, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Process name to skip";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.Location = new System.Drawing.Point(6, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "File Path";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // UserRules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 418);
            this.Controls.Add(this.tabControl1);
            this.Name = "UserRules";
            this.Text = "UserRules";
            this.Load += new System.EventHandler(this.UserRules_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListBox PathList;
        private System.Windows.Forms.Button AddPath_btn;
        private System.Windows.Forms.Button BrowsePath_btn;
        private System.Windows.Forms.TextBox Pathtxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RemoveSelectedPath_btn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button SavePathFile_btn;
        private System.Windows.Forms.TextBox FileCount_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveRegSetting_btn;
        private System.Windows.Forms.ListBox KeyPath_ListBox;
        private System.Windows.Forms.Button RemoveKePath_btn;
        private System.Windows.Forms.Button AddKeyPath_btn;
        private System.Windows.Forms.TextBox KeyPath_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SaveNetSetting_btn;
        private System.Windows.Forms.ListBox IPAddr_ListBox;
        private System.Windows.Forms.Button RemoveIPAddr_btn;
        private System.Windows.Forms.Button AddIPAddr_btn;
        private System.Windows.Forms.TextBox IPAdd_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox Port_ListBox;
        private System.Windows.Forms.Button RemovePort_btn;
        private System.Windows.Forms.Button AddPort_btn;
        private System.Windows.Forms.TextBox Port_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SaveHashbtn;
        private System.Windows.Forms.TextBox HashFiletxt;
        private System.Windows.Forms.Button HashFilebtn;
        private System.Windows.Forms.Button FilePathbtn;
        private System.Windows.Forms.TextBox FilePathtxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.Button AddHash_btn;
        private System.Windows.Forms.RadioButton ProcessSkipSuspendRadio_btn;
        private System.Windows.Forms.RadioButton ProcessSkipKillRadio_btn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ProcessNameSkip_txt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button ProcessSkip_btn;
        private System.Windows.Forms.ListBox ProcessSkip_listbox;
        private System.Windows.Forms.Button ProcessSkipRemove_btn;
        private System.Windows.Forms.Button PTSNetRemove_btn;
        private System.Windows.Forms.Button PTSNetAdd_btn;
        private System.Windows.Forms.ListBox PTSNet_ListBox;
        private System.Windows.Forms.TextBox PTSNetProcessName_txt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton ProcessSkipNoActionRadio_btn;
        private System.Windows.Forms.RadioButton PTSFileSuspend_rbtn;
        private System.Windows.Forms.RadioButton PTSFileNoaction_rbtn;
        private System.Windows.Forms.RadioButton PTSFileKill_rbtn;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button PTSFileRemove_btn;
        private System.Windows.Forms.Button PTSFileAdd_btn;
        private System.Windows.Forms.ListBox PTSFile_Listbox;
        private System.Windows.Forms.TextBox PTSFileProcessName_txt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RadioButton PTKRegSuspend_rbtn;
        private System.Windows.Forms.RadioButton PTKRegNoAction_rbtn;
        private System.Windows.Forms.RadioButton PTKRegKill_rbtn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button PTKRegRemove_btn;
        private System.Windows.Forms.Button PTKRegAdd_btn;
        private System.Windows.Forms.ListBox PTKReg_ListBox;
        private System.Windows.Forms.TextBox PTKRegProcessName_txt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton PTSNetSuspend_rbtn;
        private System.Windows.Forms.RadioButton PTSNetNoAction_rbtn;
        private System.Windows.Forms.RadioButton PTSNetKill_rbtn;
        private System.Windows.Forms.Label label10;
    }
}