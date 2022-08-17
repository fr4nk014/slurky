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
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            this.labelTitle = new System.Windows.Forms.Label();
            this.processStatuslabel = new System.Windows.Forms.Label();
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
            // SlurkyTrainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.processStatuslabel);
            this.Controls.Add(this.labelTitle);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SlurkyTrainer";
            this.Text = "slurky";
            this.Load += new System.EventHandler(this.SlurkyTrainer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgworker;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label processStatuslabel;
    }
}

