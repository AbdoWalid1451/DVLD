using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.lnternationalLicenseApplication
{
    public partial class frmAddInternationLicenseApp : Form
    {
        clsInternationalLicense internationalLicense;

        public frmAddInternationLicenseApp()
        {
            InitializeComponent();
        }

        private int CreateApplicationForInterLicense()
        {
            clsApplicationType applicationType = clsApplicationType.Find("New International License");

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

        private void FillInfoForInterLicense(clsInternationalLicense internationalLicense)
        {
            internationalLicense.ApplicationID = CreateApplicationForInterLicense();
            internationalLicense.DriverID = ctrlDriverLicenseInfoWithFilter1.license.DriverID;
            internationalLicense.IssuedUsingLocalLicenseID = ctrlDriverLicenseInfoWithFilter1.license.LicenseID;
            internationalLicense.IssueDate = DateTime.Now;
            internationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            internationalLicense.IsActive = true;
            internationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
        }

        private bool Validation()
        { 
            if (ctrlDriverLicenseInfoWithFilter1.license == null)
            {
                MessageBox.Show("You should select a license first","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            if(ctrlDriverLicenseInfoWithFilter1.license.LicenseClass != 3)
            {
                MessageBox.Show("The person must have license Class 3 - Ordinary driving license", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if(clsInternationalLicense.IsPersonHaveLicense(clsApplication.Find( ctrlDriverLicenseInfoWithFilter1.license.ApplicationID).ApplicantPersonID,true))
            {
                MessageBox.Show("Person Already have one", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            



            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Validation())
                return;


            internationalLicense = new clsInternationalLicense();

            FillInfoForInterLicense(internationalLicense);

            if (internationalLicense.Save())
            {
                clsApplication.ChangeStatus(internationalLicense.ApplicationID, clsApplication.enApplicationStatus.Completed);

                MessageBox.Show("International License issued successfully", "Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ctrlInterAppInfo1._LoadInterAppInfo(internationalLicense.InternationalLicenseID);

                ilblShowLiceneseInfo.Enabled = true;
                ctrlDriverLicenseInfoWithFilter1.Filter.Enabled = false;

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
            if(ctrlDriverLicenseInfoWithFilter1.license != null)
            ilblShowLicenseHistory.Enabled = true;
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
            frmInternationalLicenseInfo info = new frmInternationalLicenseInfo(internationalLicense.InternationalLicenseID);
                info.ShowDialog();
        }

        private void ctrlDriverLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
