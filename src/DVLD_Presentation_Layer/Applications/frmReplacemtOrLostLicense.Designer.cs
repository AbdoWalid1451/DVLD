namespace DVLD_Presentation_Layer.Applications
{
    partial class frmReplacemtOrLostLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReplacemtOrLostLicense));
            this.ilblShowLiceneseInfo = new System.Windows.Forms.LinkLabel();
            this.ilblShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.ctrlDriverLicenseInfoWithFilter1 = new DVLD_Presentation_Layer.Licenses.ctrlDriverLicenseInfoWithFilter();
            this.ctrlDamageOrReplacementLicenseApp1 = new DVLD_Presentation_Layer.Applications.ctrlDamageOrReplacementLicenseApp();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rbDamagedLic = new System.Windows.Forms.RadioButton();
            this.rbLostLic = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ilblShowLiceneseInfo
            // 
            this.ilblShowLiceneseInfo.AutoSize = true;
            this.ilblShowLiceneseInfo.Enabled = false;
            this.ilblShowLiceneseInfo.Location = new System.Drawing.Point(206, 717);
            this.ilblShowLiceneseInfo.Name = "ilblShowLiceneseInfo";
            this.ilblShowLiceneseInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ilblShowLiceneseInfo.Size = new System.Drawing.Size(144, 16);
            this.ilblShowLiceneseInfo.TabIndex = 65;
            this.ilblShowLiceneseInfo.TabStop = true;
            this.ilblShowLiceneseInfo.Text = "Show New License Info";
            this.ilblShowLiceneseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ilblShowLiceneseInfo_LinkClicked);
            // 
            // ilblShowLicenseHistory
            // 
            this.ilblShowLicenseHistory.AutoSize = true;
            this.ilblShowLicenseHistory.Enabled = false;
            this.ilblShowLicenseHistory.Location = new System.Drawing.Point(41, 717);
            this.ilblShowLicenseHistory.Name = "ilblShowLicenseHistory";
            this.ilblShowLicenseHistory.Size = new System.Drawing.Size(135, 16);
            this.ilblShowLicenseHistory.TabIndex = 64;
            this.ilblShowLicenseHistory.TabStop = true;
            this.ilblShowLicenseHistory.Text = "Show License History";
            this.ilblShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ilblShowLicenseHistory_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(592, 720);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 39);
            this.btnClose.TabIndex = 63;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssue.Image = ((System.Drawing.Image)(resources.GetObject("btnIssue.Image")));
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(738, 720);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(241, 39);
            this.btnIssue.TabIndex = 62;
            this.btnIssue.Text = "Issue Replacement";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(12, 12);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(956, 526);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 60;
            this.ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected);
            this.ctrlDriverLicenseInfoWithFilter1.Load += new System.EventHandler(this.ctrlDriverLicenseInfoWithFilter1_Load);
            // 
            // ctrlDamageOrReplacementLicenseApp1
            // 
            this.ctrlDamageOrReplacementLicenseApp1.Location = new System.Drawing.Point(33, 527);
            this.ctrlDamageOrReplacementLicenseApp1.Name = "ctrlDamageOrReplacementLicenseApp1";
            this.ctrlDamageOrReplacementLicenseApp1.Size = new System.Drawing.Size(775, 187);
            this.ctrlDamageOrReplacementLicenseApp1.TabIndex = 66;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTitle.Location = new System.Drawing.Point(221, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(281, 32);
            this.lblTitle.TabIndex = 67;
            this.lblTitle.Text = "License Application";
            // 
            // rbDamagedLic
            // 
            this.rbDamagedLic.AutoSize = true;
            this.rbDamagedLic.Checked = true;
            this.rbDamagedLic.Location = new System.Drawing.Point(12, 26);
            this.rbDamagedLic.Name = "rbDamagedLic";
            this.rbDamagedLic.Size = new System.Drawing.Size(139, 20);
            this.rbDamagedLic.TabIndex = 68;
            this.rbDamagedLic.TabStop = true;
            this.rbDamagedLic.Text = "Damaged License";
            this.rbDamagedLic.UseVisualStyleBackColor = true;
            this.rbDamagedLic.CheckedChanged += new System.EventHandler(this.rbDamagedLic_CheckedChanged);
            // 
            // rbLostLic
            // 
            this.rbLostLic.AutoSize = true;
            this.rbLostLic.Location = new System.Drawing.Point(12, 52);
            this.rbLostLic.Name = "rbLostLic";
            this.rbLostLic.Size = new System.Drawing.Size(103, 20);
            this.rbLostLic.TabIndex = 69;
            this.rbLostLic.Text = "Lost License";
            this.rbLostLic.UseVisualStyleBackColor = true;
            this.rbLostLic.CheckedChanged += new System.EventHandler(this.rbDamagedLic_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbLostLic);
            this.groupBox1.Controls.Add(this.rbDamagedLic);
            this.groupBox1.Location = new System.Drawing.Point(596, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 78);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Replacement For";
            // 
            // frmReplacemtOrLostLicense
            // 
            this.AcceptButton = this.btnIssue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(998, 783);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ilblShowLiceneseInfo);
            this.Controls.Add(this.ilblShowLicenseHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.Controls.Add(this.ctrlDamageOrReplacementLicenseApp1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReplacemtOrLostLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReplacemtOrLostLicense";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel ilblShowLiceneseInfo;
        private System.Windows.Forms.LinkLabel ilblShowLicenseHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssue;
        private Licenses.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
        private ctrlDamageOrReplacementLicenseApp ctrlDamageOrReplacementLicenseApp1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton rbDamagedLic;
        private System.Windows.Forms.RadioButton rbLostLic;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}