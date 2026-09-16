namespace DVLD_Presentation_Layer.Detain_License
{
    partial class frmReleaseDetainedlicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReleaseDetainedlicense));
            this.ilblShowLiceneseInfo = new System.Windows.Forms.LinkLabel();
            this.ilblShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.lblAddEditPerson = new System.Windows.Forms.Label();
            this.ctrlDriverLicenseInfoWithFilter1 = new DVLD_Presentation_Layer.Licenses.ctrlDriverLicenseInfoWithFilter();
            this.ctrlReleaseLicenseInfo1 = new DVLD_Presentation_Layer.Detain_License.ctrlReleaseLicenseInfo();
            this.SuspendLayout();
            // 
            // ilblShowLiceneseInfo
            // 
            this.ilblShowLiceneseInfo.AutoSize = true;
            this.ilblShowLiceneseInfo.Enabled = false;
            this.ilblShowLiceneseInfo.Location = new System.Drawing.Point(175, 731);
            this.ilblShowLiceneseInfo.Name = "ilblShowLiceneseInfo";
            this.ilblShowLiceneseInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ilblShowLiceneseInfo.Size = new System.Drawing.Size(144, 16);
            this.ilblShowLiceneseInfo.TabIndex = 70;
            this.ilblShowLiceneseInfo.TabStop = true;
            this.ilblShowLiceneseInfo.Text = "Show New License Info";
            this.ilblShowLiceneseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ilblShowLiceneseInfo_LinkClicked);
            // 
            // ilblShowLicenseHistory
            // 
            this.ilblShowLicenseHistory.AutoSize = true;
            this.ilblShowLicenseHistory.Enabled = false;
            this.ilblShowLicenseHistory.Location = new System.Drawing.Point(34, 731);
            this.ilblShowLicenseHistory.Name = "ilblShowLicenseHistory";
            this.ilblShowLicenseHistory.Size = new System.Drawing.Size(135, 16);
            this.ilblShowLicenseHistory.TabIndex = 69;
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
            this.btnClose.Location = new System.Drawing.Point(624, 720);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 39);
            this.btnClose.TabIndex = 68;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelease.Image = ((System.Drawing.Image)(resources.GetObject("btnRelease.Image")));
            this.btnRelease.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelease.Location = new System.Drawing.Point(797, 720);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(159, 39);
            this.btnRelease.TabIndex = 67;
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // lblAddEditPerson
            // 
            this.lblAddEditPerson.AutoSize = true;
            this.lblAddEditPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddEditPerson.ForeColor = System.Drawing.Color.Firebrick;
            this.lblAddEditPerson.Location = new System.Drawing.Point(325, 1);
            this.lblAddEditPerson.Name = "lblAddEditPerson";
            this.lblAddEditPerson.Size = new System.Drawing.Size(371, 32);
            this.lblAddEditPerson.TabIndex = 65;
            this.lblAddEditPerson.Text = "Release Detained License";
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(0, 1);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(976, 520);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 64;
            this.ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected);
            // 
            // ctrlReleaseLicenseInfo1
            // 
            this.ctrlReleaseLicenseInfo1.Location = new System.Drawing.Point(27, 523);
            this.ctrlReleaseLicenseInfo1.Name = "ctrlReleaseLicenseInfo1";
            this.ctrlReleaseLicenseInfo1.Size = new System.Drawing.Size(600, 205);
            this.ctrlReleaseLicenseInfo1.TabIndex = 71;
            // 
            // frmReleaseDetainedlicense
            // 
            this.AcceptButton = this.btnRelease;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(978, 768);
            this.Controls.Add(this.ilblShowLiceneseInfo);
            this.Controls.Add(this.ilblShowLicenseHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.lblAddEditPerson);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.Controls.Add(this.ctrlReleaseLicenseInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReleaseDetainedlicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReleaseDetainedlicense";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel ilblShowLiceneseInfo;
        private System.Windows.Forms.LinkLabel ilblShowLicenseHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Label lblAddEditPerson;
        private Licenses.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
        private ctrlReleaseLicenseInfo ctrlReleaseLicenseInfo1;
    }
}