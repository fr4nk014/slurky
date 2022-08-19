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
            this.actCoordZ = new System.Windows.Forms.Label();
            this.actCoordY = new System.Windows.Forms.Label();
            this.actCoordX = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.actEntName = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_scale)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.actCharTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgworker
            // 
            this.bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker_DoWork);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTitle.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(66, 26);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "slurky";
            // 
            // processStatuslabel
            // 
            this.processStatuslabel.AutoSize = true;
            this.processStatuslabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.processStatuslabel.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processStatuslabel.Location = new System.Drawing.Point(492, 0);
            this.processStatuslabel.Name = "processStatuslabel";
            this.processStatuslabel.Size = new System.Drawing.Size(132, 26);
            this.processStatuslabel.TabIndex = 1;
            this.processStatuslabel.Text = "finding pcsx2";
            this.processStatuslabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl1.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(5, 29);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(607, 400);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.actCharTab);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(599, 367);
            this.tabPage1.TabIndex = 12;
            this.tabPage1.Text = "Active Character";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbar_scale);
            this.groupBox3.Controls.Add(this.actScale);
            this.groupBox3.Location = new System.Drawing.Point(6, 155);
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
            this.actCharTab.Controls.Add(this.groupBox1);
            this.actCharTab.Controls.Add(this.actEntName);
            this.actCharTab.Location = new System.Drawing.Point(6, 6);
            this.actCharTab.Name = "actCharTab";
            this.actCharTab.Size = new System.Drawing.Size(272, 353);
            this.actCharTab.TabIndex = 0;
            this.actCharTab.TabStop = false;
            this.actCharTab.Text = "Info";
            // 
            // groupBox1
            // 
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
            // actCoordZ
            // 
            this.actCoordZ.AutoSize = true;
            this.actCoordZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.actCoordZ.Location = new System.Drawing.Point(30, 56);
            this.actCoordZ.Name = "actCoordZ";
            this.actCoordZ.Size = new System.Drawing.Size(66, 17);
            this.actCoordZ.TabIndex = 5;
            this.actCoordZ.Text = "0.00000";
            this.actCoordZ.Click += new System.EventHandler(this.actCoordZ_Click);
            // 
            // actCoordY
            // 
            this.actCoordY.AutoSize = true;
            this.actCoordY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.actCoordY.Location = new System.Drawing.Point(30, 39);
            this.actCoordY.Name = "actCoordY";
            this.actCoordY.Size = new System.Drawing.Size(66, 17);
            this.actCoordY.TabIndex = 4;
            this.actCoordY.Text = "0.00000";
            this.actCoordY.Click += new System.EventHandler(this.actCoordY_Click);
            // 
            // actCoordX
            // 
            this.actCoordX.AutoSize = true;
            this.actCoordX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.actCoordX.Location = new System.Drawing.Point(30, 22);
            this.actCoordX.Name = "actCoordX";
            this.actCoordX.Size = new System.Drawing.Size(66, 17);
            this.actCoordX.TabIndex = 3;
            this.actCoordX.Text = "0.00000";
            this.actCoordX.Click += new System.EventHandler(this.actCoordX_Click);
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
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(599, 367);
            this.tabPage2.TabIndex = 13;
            this.tabPage2.Text = "Map";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // SlurkyTrainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.processStatuslabel);
            this.Controls.Add(this.labelTitle);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SlurkyTrainer";
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
    }
}

