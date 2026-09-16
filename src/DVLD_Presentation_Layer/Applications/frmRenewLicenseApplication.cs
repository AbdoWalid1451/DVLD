using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Licenses;
using DVLD_Presentation_Layer.lnternationalLicenseApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Applications
{
    public partial class frmRenewLicenseApplication : Form
    {

        clsLicense NewLicense;
       
        public frmRenewLicenseApplication()
        {
            InitializeComponent();
        }
        private int CreateApplicationForInNewLicense()
        {
            clsApplicationType applicationType = clsApplicationType.Find("Renew Driving License Service");

            clsApplication app = new clsApplication();
            app.ApplicantPersonID = clsApplication.Find(ctrlDriverLicenseInfoWithFilter1.license.ApplicationID).ApplicantPersonID;
            app.AppDate = DateTime.Now;
            app.AppTypeID = applicationType.ApplicationTypeID;
            app.ApplicationStatus = clsApplication.enApplicationStatus.New;
            app.LastStatusDate = DateTime.Now;
            app.PaidFees = applicationType.ApplicationFees;
            app.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            app.Save();
            return app.ApplicationID;

        }

        private void FillInfoForInterLicense(clsLicense newLicense)
        {
            clsLicenseClass licenseClass = clsLicenseClass.Find(ctrlDriverLicenseInfoWithFilter1.license.LicenseClass);

            newLicense.ApplicationID = CreateApplicationForInNewLicense();
            newLicense.DriverID = ctrlDriverLicenseInfoWithFilter1.license.DriverID;
            newLicense.LicenseClass = licenseClass.LicenseClassID;
            newLicense.IssueDate = DateTime.Now;
            newLicense.ExpirationDate = DateTime.Now.AddYears(licenseClass.DefaultValidityLength);
            newLicense.Notes = ctrlAppNewLicenseInfo1.txtNotes.Text;
            newLicense.PaidFees = licenseClass.ClassFees;
            newLicense.IsActive = true;
            newLicense.IssueReason = clsLicense.enIssueReason.Renew;
            newLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
        }

        private bool Validation()
        {
            if (ctrlDriverLicenseInfoWithFilter1.license == null)
            {
                MessageBox.Show("You should select a license first", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ctrlDriverLicenseInfoWithFilter1.license.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show("This license still working you can't renew it", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!ctrlDriverLicenseInfoWithFilter1.license.IsActive)
            {
                MessageBox.Show("This license is not Active", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Validation())
                return;


            NewLicense = new clsLicense();

            FillInfoForInterLicense(NewLicense);

            if (NewLicense.Save())
            {
                clsApplication.ChangeStatus(NewLicense.ApplicationID, clsApplication.enApplicationStatus.Completed);

                clsLicense.Activation(ctrlDriverLicenseInfoWithFilter1.license.LicenseID, false);

                MessageBox.Show("renew License issued successfully", "Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ctrlAppNewLicenseInfo1._LoadApplicationRenewLicenseCard(NewLicense.LicenseID);

                ilblShowLiceneseInfo.Enabled = true;
                ctrlDriverLicenseInfoWithFilter1.Filter.Enabled = false;;
                btnIssue.Enabled = false;

            }
            else
            {
                MessageBox.Show("Failed to issue", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ilblShowLiceneseInfo.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.Filter.Enabled = true;
            }



        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            if (ctrlDriverLicenseInfoWithFilter1.license != null)
            {
                ilblShowLicenseHistory.Enabled = true;
                ctrlAppNewLicenseInfo1.LoadBasicOldLicense(ctrlDriverLicenseInfoWithFilter1.license.LicenseID);
            }
            else
                ilblShowLicenseHistory.Enabled = false;


        }

        private void ilblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory
                (clsApplication.Find(ctrlDriverLicenseInfoWithFilter1.license.ApplicationID)
                .ApplicantPersonID);
            frm.ShowDialog();
        }

        private void ilblShowLiceneseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo info = new frmDriverLicenseInfo(NewLicense.LicenseID);
            info.ShowDialog();
        }

        private void frmRenewLicenseApplication_Load(object sender, EventArgs e)
        {

        }

        private void ctrlDriverLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
