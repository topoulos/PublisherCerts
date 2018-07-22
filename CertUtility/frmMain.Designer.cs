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
            this.dgCerts = new System.Windows.Forms.DataGridView();
            this.btnSetSelectedIncomplete = new System.Windows.Forms.Button();
            this.btnSetSeletedComplete = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCerts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCompleteCerts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCerts)).BeginInit();
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
            this.lblMarkCompleteStatus.Location = new System.Drawing.Point(364, 71);
            this.lblMarkCompleteStatus.Name = "lblMarkCompleteStatus";
            this.lblMarkCompleteStatus.Size = new System.Drawing.Size(95, 13);
            this.lblMarkCompleteStatus.TabIndex = 7;
            this.lblMarkCompleteStatus.Text = "complete message";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mark Complete Last";
            // 
            // numCompleteCerts
            // 
            this.numCompleteCerts.Location = new System.Drawing.Point(143, 67);
            this.numCompleteCerts.Name = "numCompleteCerts";
            this.numCompleteCerts.Size = new System.Drawing.Size(69, 20);
            this.numCompleteCerts.TabIndex = 5;
            // 
            // btnGoComplete
            // 
            this.btnGoComplete.Location = new System.Drawing.Point(237, 66);
            this.btnGoComplete.Name = "btnGoComplete";
            this.btnGoComplete.Size = new System.Drawing.Size(75, 23);
            this.btnGoComplete.TabIndex = 4;
            this.btnGoComplete.Text = "GO";
            this.btnGoComplete.UseVisualStyleBackColor = true;
            this.btnGoComplete.Click += new System.EventHandler(this.btnGoComplete_Click);
            // 
            // dgCerts
            // 
            this.dgCerts.AllowUserToAddRows = false;
            this.dgCerts.AllowUserToDeleteRows = false;
            this.dgCerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCerts.Location = new System.Drawing.Point(19, 114);
            this.dgCerts.Name = "dgCerts";
            this.dgCerts.ReadOnly = true;
            this.dgCerts.Size = new System.Drawing.Size(1400, 438);
            this.dgCerts.TabIndex = 8;
            // 
            // btnSetSelectedIncomplete
            // 
            this.btnSetSelectedIncomplete.Location = new System.Drawing.Point(19, 573);
            this.btnSetSelectedIncomplete.Name = "btnSetSelectedIncomplete";
            this.btnSetSelectedIncomplete.Size = new System.Drawing.Size(176, 23);
            this.btnSetSelectedIncomplete.TabIndex = 9;
            this.btnSetSelectedIncomplete.Text = "Set Selected Incomplete";
            this.btnSetSelectedIncomplete.UseVisualStyleBackColor = true;
            this.btnSetSelectedIncomplete.Click += new System.EventHandler(this.btnSetSelectedIncomplete_Click);
            // 
            // btnSetSeletedComplete
            // 
            this.btnSetSeletedComplete.Location = new System.Drawing.Point(237, 573);
            this.btnSetSeletedComplete.Name = "btnSetSeletedComplete";
            this.btnSetSeletedComplete.Size = new System.Drawing.Size(176, 23);
            this.btnSetSeletedComplete.TabIndex = 10;
            this.btnSetSeletedComplete.Text = "Set Selected Complete";
            this.btnSetSeletedComplete.UseVisualStyleBackColor = true;
            this.btnSetSeletedComplete.Click += new System.EventHandler(this.btnSetSeletedComplete_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(768, 67);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(254, 20);
            this.txtSearch.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(650, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Search";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1045, 66);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1431, 608);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSetSeletedComplete);
            this.Controls.Add(this.btnSetSelectedIncomplete);
            this.Controls.Add(this.dgCerts);
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
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCerts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCompleteCerts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCerts)).EndInit();
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
        private System.Windows.Forms.DataGridView dgCerts;
        private System.Windows.Forms.Button btnSetSelectedIncomplete;
        private System.Windows.Forms.Button btnSetSeletedComplete;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
    }
}

