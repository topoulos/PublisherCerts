namespace CertUtility
{
    partial class frmMain
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
            this.btnReprintLast = new System.Windows.Forms.Button();
            this.numCerts = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblMarkCompleteStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numCompleteCerts = new System.Windows.Forms.NumericUpDown();
            this.btnGoComplete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCerts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCompleteCerts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReprintLast
            // 
            this.btnReprintLast.Location = new System.Drawing.Point(237, 14);
            this.btnReprintLast.Name = "btnReprintLast";
            this.btnReprintLast.Size = new System.Drawing.Size(75, 23);
            this.btnReprintLast.TabIndex = 0;
            this.btnReprintLast.Text = "GO";
            this.btnReprintLast.UseVisualStyleBackColor = true;
            this.btnReprintLast.Click += new System.EventHandler(this.btnReprintLast_Click);
            // 
            // numCerts
            // 
            this.numCerts.Location = new System.Drawing.Point(143, 15);
            this.numCerts.Name = "numCerts";
            this.numCerts.Size = new System.Drawing.Size(69, 20);
            this.numCerts.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Reprint Last";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(364, 19);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(95, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "complete message";
            // 
            // lblMarkCompleteStatus
            // 
            this.lblMarkCompleteStatus.AutoSize = true;
            this.lblMarkCompleteStatus.Location = new System.Drawing.Point(364, 66);
            this.lblMarkCompleteStatus.Name = "lblMarkCompleteStatus";
            this.lblMarkCompleteStatus.Size = new System.Drawing.Size(95, 13);
            this.lblMarkCompleteStatus.TabIndex = 7;
            this.lblMarkCompleteStatus.Text = "complete message";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mark Complete Last";
            // 
            // numCompleteCerts
            // 
            this.numCompleteCerts.Location = new System.Drawing.Point(143, 62);
            this.numCompleteCerts.Name = "numCompleteCerts";
            this.numCompleteCerts.Size = new System.Drawing.Size(69, 20);
            this.numCompleteCerts.TabIndex = 5;
            // 
            // btnGoComplete
            // 
            this.btnGoComplete.Location = new System.Drawing.Point(237, 61);
            this.btnGoComplete.Name = "btnGoComplete";
            this.btnGoComplete.Size = new System.Drawing.Size(75, 23);
            this.btnGoComplete.TabIndex = 4;
            this.btnGoComplete.Text = "GO";
            this.btnGoComplete.UseVisualStyleBackColor = true;
            this.btnGoComplete.Click += new System.EventHandler(this.btnGoComplete_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 308);
            this.Controls.Add(this.lblMarkCompleteStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numCompleteCerts);
            this.Controls.Add(this.btnGoComplete);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numCerts);
            this.Controls.Add(this.btnReprintLast);
            this.Name = "frmMain";
            this.Text = "Certs Utility";
            ((System.ComponentModel.ISupportInitialize)(this.numCerts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCompleteCerts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReprintLast;
        private System.Windows.Forms.NumericUpDown numCerts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblMarkCompleteStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numCompleteCerts;
        private System.Windows.Forms.Button btnGoComplete;
    }
}

