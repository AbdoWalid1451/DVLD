namespace DVLD_Presentation_Layer.Detain_License
{
    partial class frmDetainLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetainLicense));
            this.ctrlDriverLicenseInfoWithFilter1 = new DVLD_Presentation_Layer.Licenses.ctrlDriverLicenseInfoWithFilter();
            this.lblAddEditPerson = new System.Windows.Forms.Label();
            this.ctrlDetainInfo1 = new DVLD_Presentation_Layer.Detain_License.ctrlDetainInfo();
            this.ilblShowLiceneseInfo = new System.Windows.Forms.LinkLabel();
            this.ilblShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDetain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(2, 12);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(976, 520);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 0;
            this.ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected);
      
            // 
            // lblAddEditPerson
            // 
            this.lblAddEditPerson.AutoSize = true;
            this.lblAddEditPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddEditPerson.ForeColor = System.Drawing.Color.Firebrick;
            this.lblAddEditPerson.Location = new System.Drawing.Point(421, 12);
            this.lblAddEditPerson.Name = "lblAddEditPerson";
            this.lblAddEditPerson.Size = new System.Drawing.Size(217, 32);
            this.lblAddEditPerson.TabIndex = 54;
            this.lblAddEditPerson.Text = "Detain License";
            // 
            // ctrlDetainInfo1
            // 
            this.ctrlDetainInfo1.Location = new System.Drawing.Point(23, 538);
            this.ctrlDetainInfo1.Name = "ctrlDetainInfo1";
            this.ctrlDetainInfo1.Size = new System.Drawing.Size(594, 175);
            this.ctrlDetainInfo1.TabIndex = 55;
            // 
            // ilblShowLiceneseInfo
            // 
            this.ilblShowLiceneseInfo.AutoSize = true;
            this.ilblShowLiceneseInfo.Enabled = false;
            this.ilblShowLiceneseInfo.Location = new System.Drawing.Point(192, 697);
            this.ilblShowLiceneseInfo.Name = "ilblShowLiceneseInfo";
            this.ilblShowLiceneseInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ilblShowLiceneseInfo.Size = new System.Drawing.Size(144, 16);
            this.ilblShowLiceneseInfo.TabIndex = 63;
            this.ilblShowLiceneseInfo.TabStop = true;
            this.ilblShowLiceneseInfo.Text = "Show New License Info";
            this.ilblShowLiceneseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ilblShowLiceneseInfo_LinkClicked);
            // 
            // ilblShowLicenseHistory
            // 
            this.ilblShowLicenseHistory.AutoSize = true;
            this.ilblShowLicenseHistory.Enabled = false;
            this.ilblShowLicenseHistory.Location = new System.Drawing.Point(27, 697);
            this.ilblShowLicenseHistory.Name = "ilblShowLicenseHistory";
            this.ilblShowLicenseHistory.Size = new System.Drawing.Size(135, 16);
            this.ilblShowLicenseHistory.TabIndex = 62;
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
            this.btnClose.Location = new System.Drawing.Point(668, 700);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 39);
            this.btnClose.TabIndex = 61;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDetain
            // 
            this.btnDetain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetain.Image = ((System.Drawing.Image)(resources.GetObject("btnDetain.Image")));
            this.btnDetain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetain.Location = new System.Drawing.Point(827, 700);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(138, 39);
            this.btnDetain.TabIndex = 60;
            this.btnDetain.Text = "Detain";
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // frmDetainLicense
            // 
            this.AcceptButton = this.btnDetain;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1026, 748);
            this.Controls.Add(this.ilblShowLiceneseInfo);
            this.Controls.Add(this.ilblShowLicenseHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.lblAddEditPerson);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.Controls.Add(this.ctrlDetainInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDetainLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDetainLicense";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Licenses.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
        private System.Windows.Forms.Label lblAddEditPerson;
        private ctrlDetainInfo ctrlDetainInfo1;
        private System.Windows.Forms.LinkLabel ilblShowLiceneseInfo;
        private System.Windows.Forms.LinkLabel ilblShowLicenseHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDetain;
    }
}