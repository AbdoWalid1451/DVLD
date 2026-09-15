namespace DVLD_Presentation_Layer.lnternationalLicenseApplication
{
    partial class frmAddInternationLicenseApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddInternationLicenseApp));
            this.lblAddEditPerson = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ilblShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.ilblShowLiceneseInfo = new System.Windows.Forms.LinkLabel();
            this.ctrlInterAppInfo1 = new DVLD_Presentation_Layer.lnternationalLicenseApplication.ctrlInterAppInfo();
            this.ctrlDriverLicenseInfoWithFilter1 = new DVLD_Presentation_Layer.Licenses.ctrlDriverLicenseInfoWithFilter();
            this.SuspendLayout();
            // 
            // lblAddEditPerson
            // 
            this.lblAddEditPerson.AutoSize = true;
            this.lblAddEditPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddEditPerson.ForeColor = System.Drawing.Color.Firebrick;
            this.lblAddEditPerson.Location = new System.Drawing.Point(193, 9);
            this.lblAddEditPerson.Name = "lblAddEditPerson";
            this.lblAddEditPerson.Size = new System.Drawing.Size(460, 32);
            this.lblAddEditPerson.TabIndex = 1;
            this.lblAddEditPerson.Text = "International License Application";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(653, 769);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 34);
            this.btnClose.TabIndex = 51;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(812, 769);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(138, 34);
            this.btnSave.TabIndex = 50;
            this.btnSave.Text = "Issue";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ilblShowLicenseHistory
            // 
            this.ilblShowLicenseHistory.AutoSize = true;
            this.ilblShowLicenseHistory.Enabled = false;
            this.ilblShowLicenseHistory.Location = new System.Drawing.Point(12, 766);
            this.ilblShowLicenseHistory.Name = "ilblShowLicenseHistory";
            this.ilblShowLicenseHistory.Size = new System.Drawing.Size(135, 16);
            this.ilblShowLicenseHistory.TabIndex = 54;
            this.ilblShowLicenseHistory.TabStop = true;
            this.ilblShowLicenseHistory.Text = "Show License History";
            this.ilblShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ilblShowLicenseHistory_LinkClicked);
            // 
            // ilblShowLiceneseInfo
            // 
            this.ilblShowLiceneseInfo.AutoSize = true;
            this.ilblShowLiceneseInfo.Enabled = false;
            this.ilblShowLiceneseInfo.Location = new System.Drawing.Point(177, 766);
            this.ilblShowLiceneseInfo.Name = "ilblShowLiceneseInfo";
            this.ilblShowLiceneseInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ilblShowLiceneseInfo.Size = new System.Drawing.Size(114, 16);
            this.ilblShowLiceneseInfo.TabIndex = 55;
            this.ilblShowLiceneseInfo.TabStop = true;
            this.ilblShowLiceneseInfo.Text = "Show License Info";
            this.ilblShowLiceneseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ilblShowLiceneseInfo_LinkClicked);
            // 
            // ctrlInterAppInfo1
            // 
            this.ctrlInterAppInfo1.Location = new System.Drawing.Point(12, 551);
            this.ctrlInterAppInfo1.Name = "ctrlInterAppInfo1";
            this.ctrlInterAppInfo1.Size = new System.Drawing.Size(762, 212);
            this.ctrlInterAppInfo1.TabIndex = 53;
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(-13, 26);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(979, 519);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 52;
            this.ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected);
            // 
            // frmAddInternationLicenseApp
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(977, 825);
            this.Controls.Add(this.ilblShowLiceneseInfo);
            this.Controls.Add(this.ilblShowLicenseHistory);
            this.Controls.Add(this.ctrlInterAppInfo1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblAddEditPerson);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddInternationLicenseApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddInternationLicenseApp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddEditPerson;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private Licenses.ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
        private ctrlInterAppInfo ctrlInterAppInfo1;
        private System.Windows.Forms.LinkLabel ilblShowLicenseHistory;
        private System.Windows.Forms.LinkLabel ilblShowLiceneseInfo;
    }
}