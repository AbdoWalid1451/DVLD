namespace DVLD_Presentation_Layer.Applications
{
    partial class frmRenewLicenseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRenewLicenseApplication));
            this.lblAddEditPerson = new System.Windows.Forms.Label();
            this.ilblShowLiceneseInfo = new System.Windows.Forms.LinkLabel();
            this.ilblShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlDriverLicenseInfoWithFilter1 = new DVLD_Presentation_Layer.Licenses.ctrlDriverLicenseInfoWithFilter();
            this.ctrlAppNewLicenseInfo1 = new DVLD_Presentation_Layer.Applications.ctrlAppNewLicenseInfo();
            this.SuspendLayout();
            // 
            // lblAddEditPerson
            // 
            this.lblAddEditPerson.AutoSize = true;
            this.lblAddEditPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddEditPerson.ForeColor = System.Drawing.Color.Firebrick;
            this.lblAddEditPerson.Location = new System.Drawing.Point(212, 9);
            this.lblAddEditPerson.Name = "lblAddEditPerson";
            this.lblAddEditPerson.Size = new System.Drawing.Size(478, 40);
            this.lblAddEditPerson.TabIndex = 53;
            this.lblAddEditPerson.Text = "Renew License Application";
            // 
            // ilblShowLiceneseInfo
            // 
            this.ilblShowLiceneseInfo.AutoSize = true;
            this.ilblShowLiceneseInfo.Enabled = false;
            this.ilblShowLiceneseInfo.Location = new System.Drawing.Point(195, 859);
            this.ilblShowLiceneseInfo.Name = "ilblShowLiceneseInfo";
            this.ilblShowLiceneseInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ilblShowLiceneseInfo.Size = new System.Drawing.Size(144, 16);
            this.ilblShowLiceneseInfo.TabIndex = 59;
            this.ilblShowLiceneseInfo.TabStop = true;
            this.ilblShowLiceneseInfo.Text = "Show New License Info";
            this.ilblShowLiceneseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ilblShowLiceneseInfo_LinkClicked);
            // 
            // ilblShowLicenseHistory
            // 
            this.ilblShowLicenseHistory.AutoSize = true;
            this.ilblShowLicenseHistory.Enabled = false;
            this.ilblShowLicenseHistory.Location = new System.Drawing.Point(30, 859);
            this.ilblShowLicenseHistory.Name = "ilblShowLicenseHistory";
            this.ilblShowLicenseHistory.Size = new System.Drawing.Size(135, 16);
            this.ilblShowLicenseHistory.TabIndex = 58;
            this.ilblShowLicenseHistory.TabStop = true;
            this.ilblShowLicenseHistory.Text = "Show License History";
            this.ilblShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ilblShowLicenseHistory_LinkClicked);
            // 
            // btnIssue
            // 
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssue.Image = ((System.Drawing.Image)(resources.GetObject("btnIssue.Image")));
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(830, 862);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(138, 39);
            this.btnIssue.TabIndex = 56;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(671, 862);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 39);
            this.btnClose.TabIndex = 57;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(12, 9);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(956, 495);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 54;
            this.ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected);
            this.ctrlDriverLicenseInfoWithFilter1.Load += new System.EventHandler(this.ctrlDriverLicenseInfoWithFilter1_Load);
            // 
            // ctrlAppNewLicenseInfo1
            // 
            this.ctrlAppNewLicenseInfo1.Location = new System.Drawing.Point(33, 499);
            this.ctrlAppNewLicenseInfo1.Name = "ctrlAppNewLicenseInfo1";
            this.ctrlAppNewLicenseInfo1.Size = new System.Drawing.Size(904, 357);
            this.ctrlAppNewLicenseInfo1.TabIndex = 55;
            // 
            // frmRenewLicenseApplication
            // 
            this.AcceptButton = this.btnIssue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1002, 927);
            this.Controls.Add(this.ilblShowLiceneseInfo);
            this.Controls.Add(this.ilblShowLicenseHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.lblAddEditPerson);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.Controls.Add(this.ctrlAppNewLicenseInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmRenewLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRenewLicenseApplication";
            this.Load += new System.EventHandler(this.frmRenewLicenseApplication_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddEditPerson;
        private Licenses.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
        private ctrlAppNewLicenseInfo ctrlAppNewLicenseInfo1;
        private System.Windows.Forms.LinkLabel ilblShowLiceneseInfo;
        private System.Windows.Forms.LinkLabel ilblShowLicenseHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssue;
    }
}