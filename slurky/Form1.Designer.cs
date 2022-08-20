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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlurkyTrainer));
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            this.labelTitle = new System.Windows.Forms.Label();
            this.processStatuslabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbar_scale = new System.Windows.Forms.TrackBar();
            this.actScale = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_infjmp = new System.Windows.Forms.CheckBox();
            this.cb_ignore = new System.Windows.Forms.CheckBox();
            this.cb_god = new System.Windows.Forms.CheckBox();
            this.actCharTab = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_0act = new System.Windows.Forms.Button();
            this.btn_freezeAct = new System.Windows.Forms.Button();
            this.actCoordZ = new System.Windows.Forms.Label();
            this.actCoordY = new System.Windows.Forms.Label();
            this.actCoordX = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.actEntName = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_base = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_reload = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_warp = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbar_camspeed = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.tbar_rendDist = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_scale)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.actCharTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_camspeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_rendDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
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
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl1.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(5, 29);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(607, 384);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.actCharTab);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(599, 351);
            this.tabPage1.TabIndex = 12;
            this.tabPage1.Text = "Active Character";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbar_scale);
            this.groupBox3.Controls.Add(this.actScale);
            this.groupBox3.Location = new System.Drawing.Point(0, 149);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(266, 71);
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
            this.tbar_scale.Size = new System.Drawing.Size(179, 45);
            this.tbar_scale.SmallChange = 5;
            this.tbar_scale.TabIndex = 4;
            this.tbar_scale.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
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
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.cb_infjmp);
            this.groupBox2.Controls.Add(this.cb_ignore);
            this.groupBox2.Controls.Add(this.cb_god);
            this.groupBox2.Location = new System.Drawing.Point(284, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 143);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Flags";
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
            this.cb_god.UseVisualStyleBackColor = true;
            this.cb_god.CheckedChanged += new System.EventHandler(this.cb_god_CheckedChanged);
            // 
            // actCharTab
            // 
            this.actCharTab.BackColor = System.Drawing.SystemColors.Control;
            this.actCharTab.Controls.Add(this.groupBox3);
            this.actCharTab.Controls.Add(this.groupBox1);
            this.actCharTab.Controls.Add(this.actEntName);
            this.actCharTab.Location = new System.Drawing.Point(6, 6);
            this.actCharTab.Name = "actCharTab";
            this.actCharTab.Size = new System.Drawing.Size(272, 335);
            this.actCharTab.TabIndex = 0;
            this.actCharTab.TabStop = false;
            this.actCharTab.Text = "Info";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_0act);
            this.groupBox1.Controls.Add(this.btn_freezeAct);
            this.groupBox1.Controls.Add(this.actCoordZ);
            this.groupBox1.Controls.Add(this.actCoordY);
            this.groupBox1.Controls.Add(this.actCoordX);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 104);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Coordinates";
            // 
            // btn_0act
            // 
            this.btn_0act.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_0act.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_0act.Location = new System.Drawing.Point(102, 75);
            this.btn_0act.Name = "btn_0act";
            this.btn_0act.Size = new System.Drawing.Size(158, 23);
            this.btn_0act.TabIndex = 7;
            this.btn_0act.Text = "Go to 0,0,0";
            this.btn_0act.UseVisualStyleBackColor = true;
            this.btn_0act.Click += new System.EventHandler(this.btn_0act_Click);
            // 
            // btn_freezeAct
            // 
            this.btn_freezeAct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_freezeAct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_freezeAct.Location = new System.Drawing.Point(9, 75);
            this.btn_freezeAct.Name = "btn_freezeAct";
            this.btn_freezeAct.Size = new System.Drawing.Size(87, 23);
            this.btn_freezeAct.TabIndex = 6;
            this.btn_freezeAct.Text = "Freeze";
            this.btn_freezeAct.UseVisualStyleBackColor = true;
            this.btn_freezeAct.Click += new System.EventHandler(this.btn_freezeAct_Click);
            // 
            // actCoordZ
            // 
            this.actCoordZ.AutoSize = true;
            this.actCoordZ.Cursor = System.Windows.Forms.Cursors.Default;
            this.actCoordZ.Location = new System.Drawing.Point(30, 56);
            this.actCoordZ.Name = "actCoordZ";
            this.actCoordZ.Size = new System.Drawing.Size(66, 17);
            this.actCoordZ.TabIndex = 5;
            this.actCoordZ.Text = "0.00000";
            // 
            // actCoordY
            // 
            this.actCoordY.AutoSize = true;
            this.actCoordY.Cursor = System.Windows.Forms.Cursors.Default;
            this.actCoordY.Location = new System.Drawing.Point(30, 39);
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
            this.label3.Location = new System.Drawing.Point(9, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Z:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 39);
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
            // actEntName
            // 
            this.actEntName.AutoSize = true;
            this.actEntName.ForeColor = System.Drawing.Color.Red;
            this.actEntName.Location = new System.Drawing.Point(6, 18);
            this.actEntName.Name = "actEntName";
            this.actEntName.Size = new System.Drawing.Size(148, 17);
            this.actEntName.TabIndex = 0;
            this.actEntName.Text = "ActiveCharacterName";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(599, 351);
            this.tabPage2.TabIndex = 13;
            this.tabPage2.Text = "Map";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BackgroundImage = global::slurky.Properties.Resources.slurk;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 28);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
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
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.btn_warp);
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.btn_reload);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(210, 335);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Current";
            // 
            // btn_reload
            // 
            this.btn_reload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_reload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_reload.Location = new System.Drawing.Point(6, 98);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(195, 23);
            this.btn_reload.TabIndex = 1;
            this.btn_reload.Text = "Reload";
            this.btn_reload.UseVisualStyleBackColor = true;
            this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(195, 25);
            this.comboBox1.TabIndex = 2;
            // 
            // btn_warp
            // 
            this.btn_warp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_warp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_warp.Location = new System.Drawing.Point(6, 69);
            this.btn_warp.Name = "btn_warp";
            this.btn_warp.Size = new System.Drawing.Size(195, 23);
            this.btn_warp.TabIndex = 3;
            this.btn_warp.Text = "Warp";
            this.btn_warp.UseVisualStyleBackColor = true;
            this.btn_warp.Click += new System.EventHandler(this.btn_warp_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Set Warp Location";
            // 
            // tabPage3
            // 
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(599, 351);
            this.tabPage3.TabIndex = 14;
            this.tabPage3.Text = "Engine";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(6, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Reset Orbit";
            this.button1.UseVisualStyleBackColor = true;
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
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 22);
            this.label6.TabIndex = 3;
            this.label6.Text = "Render Distance";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 22);
            this.label7.TabIndex = 5;
            this.label7.Text = "Field of View";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(6, 307);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "Reset Camera Settings";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.trackBar2);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox6.Location = new System.Drawing.Point(399, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(196, 347);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Other";
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
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(9, 43);
            this.trackBar2.Maximum = 50;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(181, 45);
            this.trackBar2.TabIndex = 8;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar2.Value = 10;
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_scale)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.actCharTab.ResumeLayout(false);
            this.actCharTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_camspeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_rendDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
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
        private System.Windows.Forms.ComboBox comboBox1;
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
    }
}

