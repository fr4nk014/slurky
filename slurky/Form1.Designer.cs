namespace slurky
{
    partial class SlurkyTrainer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlurkyTrainer));
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            this.labelTitle = new System.Windows.Forms.Label();
            this.processStatuslabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_atttarg = new System.Windows.Forms.CheckBox();
            this.cb_infjmp = new System.Windows.Forms.CheckBox();
            this.cb_ignore = new System.Windows.Forms.CheckBox();
            this.cb_god = new System.Windows.Forms.CheckBox();
            this.actCharTab = new System.Windows.Forms.GroupBox();
            this.cb_character = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_0act = new System.Windows.Forms.Button();
            this.btn_freezeAct = new System.Windows.Forms.Button();
            this.actCoordZ = new System.Windows.Forms.Label();
            this.actCoordY = new System.Windows.Forms.Label();
            this.actCoordX = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbar_scale = new System.Windows.Forms.TrackBar();
            this.actScale = new System.Windows.Forms.Label();
            this.actEntName = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gb_loadmap = new System.Windows.Forms.GroupBox();
            this.btn_loadlvl = new System.Windows.Forms.Button();
            this.cb_loadlvl = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label_curlev = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_warp = new System.Windows.Forms.Button();
            this.cb_warps = new System.Windows.Forms.ComboBox();
            this.btn_reload = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.tbar_rendDist = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.tbar_camspeed = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cb_fun_lanky = new System.Windows.Forms.CheckBox();
            this.label_base = new System.Windows.Forms.Label();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btn_allgadgets = new System.Windows.Forms.Button();
            this.btn_decX = new System.Windows.Forms.Button();
            this.btn_incX = new System.Windows.Forms.Button();
            this.btn_incY = new System.Windows.Forms.Button();
            this.btn_decY = new System.Windows.Forms.Button();
            this.btn_incZ = new System.Windows.Forms.Button();
            this.btn_decZ = new System.Windows.Forms.Button();
            this.tbar_coordmag = new System.Windows.Forms.TrackBar();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.actCharTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_scale)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.gb_loadmap.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_rendDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_camspeed)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_coordmag)).BeginInit();
            this.SuspendLayout();
            // 
            // bgworker
            // 
            this.bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker_DoWork);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTitle.AutoSize = true;
            this.labelTitle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelTitle.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(44, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(66, 26);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "slurky";
            // 
            // processStatuslabel
            // 
            this.processStatuslabel.AutoSize = true;
            this.processStatuslabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.processStatuslabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.processStatuslabel.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processStatuslabel.Location = new System.Drawing.Point(490, 0);
            this.processStatuslabel.Name = "processStatuslabel";
            this.processStatuslabel.Size = new System.Drawing.Size(134, 28);
            this.processStatuslabel.TabIndex = 1;
            this.processStatuslabel.Text = "finding pcsx2";
            this.processStatuslabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl1.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(2, 29);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(608, 384);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.actCharTab);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(600, 351);
            this.tabPage1.TabIndex = 12;
            this.tabPage1.Text = "Character";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.cb_atttarg);
            this.groupBox2.Controls.Add(this.cb_infjmp);
            this.groupBox2.Controls.Add(this.cb_ignore);
            this.groupBox2.Controls.Add(this.cb_god);
            this.groupBox2.Location = new System.Drawing.Point(284, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 172);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Flags";
            // 
            // cb_atttarg
            // 
            this.cb_atttarg.AutoSize = true;
            this.cb_atttarg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_atttarg.Location = new System.Drawing.Point(6, 74);
            this.cb_atttarg.Name = "cb_atttarg";
            this.cb_atttarg.Size = new System.Drawing.Size(169, 21);
            this.cb_atttarg.TabIndex = 4;
            this.cb_atttarg.Text = "Disable guard attacks";
            this.toolTips.SetToolTip(this.cb_atttarg, "Guards won\'t attack you.");
            this.cb_atttarg.UseVisualStyleBackColor = true;
            this.cb_atttarg.CheckedChanged += new System.EventHandler(this.cb_atttarg_CheckedChanged);
            // 
            // cb_infjmp
            // 
            this.cb_infjmp.AutoSize = true;
            this.cb_infjmp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_infjmp.Location = new System.Drawing.Point(6, 57);
            this.cb_infjmp.Name = "cb_infjmp";
            this.cb_infjmp.Size = new System.Drawing.Size(118, 21);
            this.cb_infjmp.TabIndex = 3;
            this.cb_infjmp.Text = "Jump override";
            this.toolTips.SetToolTip(this.cb_infjmp, "Override current jump state. Infinite jumps.");
            this.cb_infjmp.UseVisualStyleBackColor = true;
            this.cb_infjmp.CheckedChanged += new System.EventHandler(this.cb_infjmp_CheckedChanged);
            // 
            // cb_ignore
            // 
            this.cb_ignore.AutoSize = true;
            this.cb_ignore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_ignore.Location = new System.Drawing.Point(6, 21);
            this.cb_ignore.Name = "cb_ignore";
            this.cb_ignore.Size = new System.Drawing.Size(113, 21);
            this.cb_ignore.TabIndex = 2;
            this.cb_ignore.Text = "Undetectable";
            this.toolTips.SetToolTip(this.cb_ignore, "Make guards ignore you.");
            this.cb_ignore.UseVisualStyleBackColor = true;
            this.cb_ignore.CheckedChanged += new System.EventHandler(this.cb_ignore_CheckedChanged);
            // 
            // cb_god
            // 
            this.cb_god.AutoSize = true;
            this.cb_god.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_god.Location = new System.Drawing.Point(6, 39);
            this.cb_god.Name = "cb_god";
            this.cb_god.Size = new System.Drawing.Size(118, 21);
            this.cb_god.TabIndex = 1;
            this.cb_god.Text = "Invulnerability";
            this.toolTips.SetToolTip(this.cb_god, "No damage or damage animation.");
            this.cb_god.UseVisualStyleBackColor = true;
            this.cb_god.CheckedChanged += new System.EventHandler(this.cb_god_CheckedChanged);
            // 
            // actCharTab
            // 
            this.actCharTab.BackColor = System.Drawing.SystemColors.Control;
            this.actCharTab.Controls.Add(this.cb_character);
            this.actCharTab.Controls.Add(this.groupBox1);
            this.actCharTab.Controls.Add(this.groupBox3);
            this.actCharTab.Controls.Add(this.actEntName);
            this.actCharTab.Location = new System.Drawing.Point(6, 6);
            this.actCharTab.Name = "actCharTab";
            this.actCharTab.Size = new System.Drawing.Size(272, 335);
            this.actCharTab.TabIndex = 0;
            this.actCharTab.TabStop = false;
            this.actCharTab.Text = "Info";
            // 
            // cb_character
            // 
            this.cb_character.BackColor = System.Drawing.SystemColors.Control;
            this.cb_character.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_character.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_character.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb_character.FormattingEnabled = true;
            this.cb_character.Location = new System.Drawing.Point(170, 21);
            this.cb_character.Name = "cb_character";
            this.cb_character.Size = new System.Drawing.Size(97, 25);
            this.cb_character.TabIndex = 7;
            this.cb_character.SelectedIndexChanged += new System.EventHandler(this.cb_character_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbar_coordmag);
            this.groupBox1.Controls.Add(this.btn_incZ);
            this.groupBox1.Controls.Add(this.btn_decZ);
            this.groupBox1.Controls.Add(this.btn_incY);
            this.groupBox1.Controls.Add(this.btn_decY);
            this.groupBox1.Controls.Add(this.btn_0act);
            this.groupBox1.Controls.Add(this.btn_freezeAct);
            this.groupBox1.Controls.Add(this.btn_incX);
            this.groupBox1.Controls.Add(this.btn_decX);
            this.groupBox1.Controls.Add(this.actCoordZ);
            this.groupBox1.Controls.Add(this.actCoordY);
            this.groupBox1.Controls.Add(this.actCoordX);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 185);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Coordinates";
            // 
            // btn_0act
            // 
            this.btn_0act.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_0act.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_0act.Location = new System.Drawing.Point(173, 49);
            this.btn_0act.Name = "btn_0act";
            this.btn_0act.Size = new System.Drawing.Size(87, 31);
            this.btn_0act.TabIndex = 7;
            this.btn_0act.Text = "0,0,0";
            this.toolTips.SetToolTip(this.btn_0act, "Teleport to 0,0,0");
            this.btn_0act.UseVisualStyleBackColor = true;
            this.btn_0act.Click += new System.EventHandler(this.btn_0act_Click);
            // 
            // btn_freezeAct
            // 
            this.btn_freezeAct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_freezeAct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_freezeAct.Location = new System.Drawing.Point(173, 12);
            this.btn_freezeAct.Name = "btn_freezeAct";
            this.btn_freezeAct.Size = new System.Drawing.Size(87, 31);
            this.btn_freezeAct.TabIndex = 6;
            this.btn_freezeAct.Text = "Freeze";
            this.toolTips.SetToolTip(this.btn_freezeAct, "Freeze current position.");
            this.btn_freezeAct.UseVisualStyleBackColor = true;
            this.btn_freezeAct.Click += new System.EventHandler(this.btn_freezeAct_Click);
            // 
            // actCoordZ
            // 
            this.actCoordZ.AutoSize = true;
            this.actCoordZ.Cursor = System.Windows.Forms.Cursors.Default;
            this.actCoordZ.Location = new System.Drawing.Point(32, 128);
            this.actCoordZ.Name = "actCoordZ";
            this.actCoordZ.Size = new System.Drawing.Size(102, 17);
            this.actCoordZ.TabIndex = 5;
            this.actCoordZ.Text = "99999.99999";
            // 
            // actCoordY
            // 
            this.actCoordY.AutoSize = true;
            this.actCoordY.Cursor = System.Windows.Forms.Cursors.Default;
            this.actCoordY.Location = new System.Drawing.Point(30, 76);
            this.actCoordY.Name = "actCoordY";
            this.actCoordY.Size = new System.Drawing.Size(66, 17);
            this.actCoordY.TabIndex = 4;
            this.actCoordY.Text = "0.00000";
            // 
            // actCoordX
            // 
            this.actCoordX.AutoSize = true;
            this.actCoordX.Cursor = System.Windows.Forms.Cursors.Default;
            this.actCoordX.Location = new System.Drawing.Point(30, 22);
            this.actCoordX.Name = "actCoordX";
            this.actCoordX.Size = new System.Drawing.Size(66, 17);
            this.actCoordX.TabIndex = 3;
            this.actCoordX.Text = "0.00000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Z:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.tbar_scale);
            this.groupBox3.Controls.Add(this.actScale);
            this.groupBox3.Location = new System.Drawing.Point(0, 243);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(266, 86);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Scale";
            // 
            // tbar_scale
            // 
            this.tbar_scale.Location = new System.Drawing.Point(81, 8);
            this.tbar_scale.Maximum = 50;
            this.tbar_scale.Minimum = 5;
            this.tbar_scale.Name = "tbar_scale";
            this.tbar_scale.Size = new System.Drawing.Size(178, 45);
            this.tbar_scale.SmallChange = 5;
            this.tbar_scale.TabIndex = 4;
            this.tbar_scale.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbar_scale.Value = 10;
            this.tbar_scale.ValueChanged += new System.EventHandler(this.tbar_scale_ValueChanged);
            // 
            // actScale
            // 
            this.actScale.AutoSize = true;
            this.actScale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.actScale.Location = new System.Drawing.Point(9, 18);
            this.actScale.Name = "actScale";
            this.actScale.Size = new System.Drawing.Size(66, 17);
            this.actScale.TabIndex = 3;
            this.actScale.Text = "0.00000";
            // 
            // actEntName
            // 
            this.actEntName.BackColor = System.Drawing.SystemColors.Control;
            this.actEntName.ForeColor = System.Drawing.Color.Red;
            this.actEntName.Location = new System.Drawing.Point(6, 21);
            this.actEntName.Name = "actEntName";
            this.actEntName.Size = new System.Drawing.Size(158, 25);
            this.actEntName.TabIndex = 0;
            this.actEntName.Text = "-";
            this.actEntName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.gb_loadmap);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(600, 351);
            this.tabPage2.TabIndex = 13;
            this.tabPage2.Text = "Map";
            // 
            // gb_loadmap
            // 
            this.gb_loadmap.Controls.Add(this.btn_loadlvl);
            this.gb_loadmap.Controls.Add(this.cb_loadlvl);
            this.gb_loadmap.Location = new System.Drawing.Point(222, 6);
            this.gb_loadmap.Name = "gb_loadmap";
            this.gb_loadmap.Size = new System.Drawing.Size(368, 147);
            this.gb_loadmap.TabIndex = 1;
            this.gb_loadmap.TabStop = false;
            this.gb_loadmap.Text = "Load Map";
            // 
            // btn_loadlvl
            // 
            this.btn_loadlvl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_loadlvl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_loadlvl.Location = new System.Drawing.Point(6, 51);
            this.btn_loadlvl.Name = "btn_loadlvl";
            this.btn_loadlvl.Size = new System.Drawing.Size(356, 23);
            this.btn_loadlvl.TabIndex = 1;
            this.btn_loadlvl.Text = "Load";
            this.btn_loadlvl.UseVisualStyleBackColor = true;
            this.btn_loadlvl.Click += new System.EventHandler(this.btn_loadlvl_Click);
            // 
            // cb_loadlvl
            // 
            this.cb_loadlvl.BackColor = System.Drawing.SystemColors.Control;
            this.cb_loadlvl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_loadlvl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_loadlvl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb_loadlvl.FormattingEnabled = true;
            this.cb_loadlvl.Location = new System.Drawing.Point(6, 20);
            this.cb_loadlvl.Name = "cb_loadlvl";
            this.cb_loadlvl.Size = new System.Drawing.Size(356, 25);
            this.cb_loadlvl.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.label_curlev);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.btn_warp);
            this.groupBox4.Controls.Add(this.cb_warps);
            this.groupBox4.Controls.Add(this.btn_reload);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(210, 340);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Current";
            // 
            // label_curlev
            // 
            this.label_curlev.AutoSize = true;
            this.label_curlev.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_curlev.ForeColor = System.Drawing.Color.White;
            this.label_curlev.Location = new System.Drawing.Point(6, 20);
            this.label_curlev.Name = "label_curlev";
            this.label_curlev.Size = new System.Drawing.Size(135, 17);
            this.label_curlev.TabIndex = 5;
            this.label_curlev.Text = "Current Level Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Set Warp Location";
            // 
            // btn_warp
            // 
            this.btn_warp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_warp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_warp.Location = new System.Drawing.Point(6, 88);
            this.btn_warp.Name = "btn_warp";
            this.btn_warp.Size = new System.Drawing.Size(195, 23);
            this.btn_warp.TabIndex = 3;
            this.btn_warp.Text = "Warp";
            this.toolTips.SetToolTip(this.btn_warp, "Warp to selected warp location.");
            this.btn_warp.UseVisualStyleBackColor = true;
            this.btn_warp.Click += new System.EventHandler(this.btn_warp_Click);
            // 
            // cb_warps
            // 
            this.cb_warps.BackColor = System.Drawing.SystemColors.Control;
            this.cb_warps.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_warps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_warps.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb_warps.FormattingEnabled = true;
            this.cb_warps.Location = new System.Drawing.Point(6, 57);
            this.cb_warps.Name = "cb_warps";
            this.cb_warps.Size = new System.Drawing.Size(194, 25);
            this.cb_warps.TabIndex = 2;
            // 
            // btn_reload
            // 
            this.btn_reload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_reload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_reload.Location = new System.Drawing.Point(6, 117);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(195, 23);
            this.btn_reload.TabIndex = 1;
            this.btn_reload.Text = "Reload";
            this.toolTips.SetToolTip(this.btn_reload, "Reload current level.");
            this.btn_reload.UseVisualStyleBackColor = true;
            this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(600, 351);
            this.tabPage3.TabIndex = 14;
            this.tabPage3.Text = "Engine";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.trackBar2);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox6.Location = new System.Drawing.Point(400, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(196, 347);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Other";
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(9, 43);
            this.trackBar2.Maximum = 50;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(182, 45);
            this.trackBar2.TabIndex = 8;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar2.Value = 10;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 22);
            this.label8.TabIndex = 8;
            this.label8.Text = "Clock Speed";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.trackBar1);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.tbar_rendDist);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.tbar_camspeed);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(196, 347);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Camera";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(6, 307);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "Reset Camera Settings";
            this.toolTips.SetToolTip(this.button2, "Reset all camera settings.");
            this.button2.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(6, 218);
            this.trackBar1.Maximum = 50;
            this.trackBar1.Minimum = 5;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(184, 45);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 11;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 22);
            this.label7.TabIndex = 5;
            this.label7.Text = "Field of View";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbar_rendDist
            // 
            this.tbar_rendDist.Location = new System.Drawing.Point(6, 145);
            this.tbar_rendDist.Maximum = 50;
            this.tbar_rendDist.Minimum = 5;
            this.tbar_rendDist.Name = "tbar_rendDist";
            this.tbar_rendDist.Size = new System.Drawing.Size(184, 45);
            this.tbar_rendDist.TabIndex = 4;
            this.tbar_rendDist.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbar_rendDist.Value = 11;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 22);
            this.label6.TabIndex = 3;
            this.label6.Text = "Render Distance";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbar_camspeed
            // 
            this.tbar_camspeed.Location = new System.Drawing.Point(6, 72);
            this.tbar_camspeed.Maximum = 50;
            this.tbar_camspeed.Minimum = 5;
            this.tbar_camspeed.Name = "tbar_camspeed";
            this.tbar_camspeed.Size = new System.Drawing.Size(184, 45);
            this.tbar_camspeed.TabIndex = 2;
            this.tbar_camspeed.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbar_camspeed.Value = 10;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "Camera Speed";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(6, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Reset Orbit";
            this.toolTips.SetToolTip(this.button1, "Resets the camera behind active character.");
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage4.Controls.Add(this.cb_fun_lanky);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(600, 351);
            this.tabPage4.TabIndex = 15;
            this.tabPage4.Text = "Fun";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cb_fun_lanky
            // 
            this.cb_fun_lanky.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_fun_lanky.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_fun_lanky.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_fun_lanky.Location = new System.Drawing.Point(3, 3);
            this.cb_fun_lanky.Name = "cb_fun_lanky";
            this.cb_fun_lanky.Size = new System.Drawing.Size(163, 31);
            this.cb_fun_lanky.TabIndex = 0;
            this.cb_fun_lanky.Text = "Lanky Sly";
            this.cb_fun_lanky.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb_fun_lanky.UseVisualStyleBackColor = true;
            this.cb_fun_lanky.CheckedChanged += new System.EventHandler(this.cb_fun_lanky_CheckedChanged);
            // 
            // label_base
            // 
            this.label_base.AutoSize = true;
            this.label_base.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_base.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_base.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_base.ForeColor = System.Drawing.Color.DimGray;
            this.label_base.Location = new System.Drawing.Point(0, 413);
            this.label_base.Name = "label_base";
            this.label_base.Size = new System.Drawing.Size(210, 28);
            this.label_base.TabIndex = 3;
            this.label_base.Text = "emu base = not found";
            this.label_base.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolTips
            // 
            this.toolTips.AutomaticDelay = 100;
            this.toolTips.AutoPopDelay = 0;
            this.toolTips.InitialDelay = 100;
            this.toolTips.ReshowDelay = 20;
            this.toolTips.UseFading = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::slurky.Properties.Resources.slurk;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(6, 57);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(251, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Reset";
            this.toolTips.SetToolTip(this.button3, "Reset scale.");
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btn_allgadgets);
            this.groupBox8.Location = new System.Drawing.Point(284, 184);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(308, 157);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Extra";
            // 
            // btn_allgadgets
            // 
            this.btn_allgadgets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_allgadgets.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_allgadgets.Location = new System.Drawing.Point(6, 26);
            this.btn_allgadgets.Name = "btn_allgadgets";
            this.btn_allgadgets.Size = new System.Drawing.Size(296, 23);
            this.btn_allgadgets.TabIndex = 11;
            this.btn_allgadgets.Text = "Unlock All Gadgets";
            this.toolTips.SetToolTip(this.btn_allgadgets, "Freeze current position.");
            this.btn_allgadgets.UseVisualStyleBackColor = true;
            this.btn_allgadgets.Click += new System.EventHandler(this.btn_allgadgets_Click);
            // 
            // btn_decX
            // 
            this.btn_decX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_decX.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_decX.Location = new System.Drawing.Point(12, 42);
            this.btn_decX.Name = "btn_decX";
            this.btn_decX.Size = new System.Drawing.Size(24, 31);
            this.btn_decX.TabIndex = 8;
            this.btn_decX.Text = "-";
            this.btn_decX.UseVisualStyleBackColor = true;
            this.btn_decX.Click += new System.EventHandler(this.btn_decX_Click);
            // 
            // btn_incX
            // 
            this.btn_incX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_incX.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_incX.Location = new System.Drawing.Point(39, 42);
            this.btn_incX.Name = "btn_incX";
            this.btn_incX.Size = new System.Drawing.Size(24, 31);
            this.btn_incX.TabIndex = 9;
            this.btn_incX.Text = "+";
            this.btn_incX.UseVisualStyleBackColor = true;
            this.btn_incX.Click += new System.EventHandler(this.btn_incX_Click);
            // 
            // btn_incY
            // 
            this.btn_incY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_incY.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_incY.Location = new System.Drawing.Point(39, 96);
            this.btn_incY.Name = "btn_incY";
            this.btn_incY.Size = new System.Drawing.Size(24, 31);
            this.btn_incY.TabIndex = 11;
            this.btn_incY.Text = "+";
            this.btn_incY.UseVisualStyleBackColor = true;
            this.btn_incY.Click += new System.EventHandler(this.btn_incY_Click);
            // 
            // btn_decY
            // 
            this.btn_decY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_decY.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_decY.Location = new System.Drawing.Point(12, 96);
            this.btn_decY.Name = "btn_decY";
            this.btn_decY.Size = new System.Drawing.Size(24, 31);
            this.btn_decY.TabIndex = 10;
            this.btn_decY.Text = "-";
            this.btn_decY.UseVisualStyleBackColor = true;
            this.btn_decY.Click += new System.EventHandler(this.btn_decY_Click);
            // 
            // btn_incZ
            // 
            this.btn_incZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_incZ.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_incZ.Location = new System.Drawing.Point(39, 146);
            this.btn_incZ.Name = "btn_incZ";
            this.btn_incZ.Size = new System.Drawing.Size(24, 31);
            this.btn_incZ.TabIndex = 13;
            this.btn_incZ.Text = "+";
            this.btn_incZ.UseVisualStyleBackColor = true;
            this.btn_incZ.Click += new System.EventHandler(this.btn_incZ_Click);
            // 
            // btn_decZ
            // 
            this.btn_decZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_decZ.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_decZ.Location = new System.Drawing.Point(12, 146);
            this.btn_decZ.Name = "btn_decZ";
            this.btn_decZ.Size = new System.Drawing.Size(24, 31);
            this.btn_decZ.TabIndex = 12;
            this.btn_decZ.Text = "-";
            this.btn_decZ.UseVisualStyleBackColor = true;
            this.btn_decZ.Click += new System.EventHandler(this.btn_decZ_Click);
            // 
            // tbar_coordmag
            // 
            this.tbar_coordmag.AutoSize = false;
            this.tbar_coordmag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbar_coordmag.Location = new System.Drawing.Point(140, 12);
            this.tbar_coordmag.Maximum = 2000;
            this.tbar_coordmag.Minimum = 20;
            this.tbar_coordmag.Name = "tbar_coordmag";
            this.tbar_coordmag.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbar_coordmag.Size = new System.Drawing.Size(27, 165);
            this.tbar_coordmag.TabIndex = 14;
            this.tbar_coordmag.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.toolTips.SetToolTip(this.tbar_coordmag, "Coordinate adjust magnitude.");
            this.tbar_coordmag.Value = 200;
            this.tbar_coordmag.ValueChanged += new System.EventHandler(this.tbar_coordmag_ValueChanged);
            // 
            // SlurkyTrainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.label_base);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.processStatuslabel);
            this.Controls.Add(this.labelTitle);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SlurkyTrainer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "slurky";
            this.Load += new System.EventHandler(this.SlurkyTrainer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.actCharTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_scale)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.gb_loadmap.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_rendDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_camspeed)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbar_coordmag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgworker;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label processStatuslabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox actCharTab;
        private System.Windows.Forms.Label actEntName;
        private System.Windows.Forms.CheckBox cb_god;
        private System.Windows.Forms.CheckBox cb_ignore;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label actCoordZ;
        private System.Windows.Forms.Label actCoordY;
        private System.Windows.Forms.Label actCoordX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cb_infjmp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label actScale;
        private System.Windows.Forms.TrackBar tbar_scale;
        private System.Windows.Forms.Button btn_freezeAct;
        private System.Windows.Forms.Button btn_0act;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_base;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_reload;
        private System.Windows.Forms.ComboBox cb_warps;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_warp;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TrackBar tbar_rendDist;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar tbar_camspeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cb_atttarg;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.ComboBox cb_character;
        private System.Windows.Forms.Label label_curlev;
        private System.Windows.Forms.GroupBox gb_loadmap;
        private System.Windows.Forms.ComboBox cb_loadlvl;
        private System.Windows.Forms.Button btn_loadlvl;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox cb_fun_lanky;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btn_allgadgets;
        private System.Windows.Forms.Button btn_incZ;
        private System.Windows.Forms.Button btn_decZ;
        private System.Windows.Forms.Button btn_incY;
        private System.Windows.Forms.Button btn_decY;
        private System.Windows.Forms.Button btn_incX;
        private System.Windows.Forms.Button btn_decX;
        private System.Windows.Forms.TrackBar tbar_coordmag;
    }
}

