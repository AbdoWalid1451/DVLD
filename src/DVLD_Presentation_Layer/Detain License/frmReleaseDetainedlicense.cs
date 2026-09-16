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

namespace DVLD_Presentation_Layer.Detain_License
{
    public partial class frmReleaseDetainedlicense : Form
    {
        public frmReleaseDetainedlicense()
        {
            InitializeComponent();
        }
        public frmReleaseDetainedlicense(int LicenseID)
        {
            InitializeComponent();
            ctrlDriverLicenseInfoWithFilter1.Search(LicenseID);


        }
        clsDetainedLicense DetainedLicense;

        private int CreateApplicationForReleaseDetainedLicense()
        {
            clsApplicationType applicationType = clsApplicationType.Find("Release Detained Driving Licsense");

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


        private void FillInfoForReleasingLicense(clsDetainedLicense DetainedLicense)
        {
            DetainedLicense.IsReleased = true;
            DetainedLicense.ReleaseDate = DateTime.Now;
            DetainedLicense.ReleasedByUserID = clsGlobal.CurrentUser.UserID;
            DetainedLicense.ReleaseApplicationID = CreateApplicationForReleaseDetainedLicense();
        }

        private bool Validation()
        {
            if (ctrlDriverLicenseInfoWithFilter1.license == null)
            {
                MessageBox.Show("You should select a license first", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!clsDetainedLicense.IsLicenseDetained(ctrlDriverLicenseInfoWithFilter1.license.LicenseID))
            {
                MessageBox.Show("This license is not Detained", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



            return true;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (!Validation())
                return;


            DetainedLicense = clsDetainedLicense.findDetainedLicenseByLicenseID(ctrlDriverLicenseInfoWithFilter1.license.LicenseID);

            FillInfoForReleasingLicense(DetainedLicense);

            if (DetainedLicense.Release())
            {

                clsLicense.Activation(ctrlDriverLicenseInfoWithFilter1.license.LicenseID, true);
                clsApplication.ChangeStatus(DetainedLicense.ReleaseApplicationID, clsApplication.enApplicationStatus.Completed);

                MessageBox.Show("Release Detained License  successfully", "Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ctrlReleaseLicenseInfo1._LoadReleaseInfo(DetainedLicense.LicenseID);

                ilblShowLiceneseInfo.Enabled = true;
                ctrlDriverLicenseInfoWithFilter1.Filter.Enabled = false;
                btnRelease.Enabled = false;

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
                ctrlReleaseLicenseInfo1.LoadBasicByLicenseID(ctrlDriverLicenseInfoWithFilter1.license.LicenseID);
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
            frmDriverLicenseInfo info = new frmDriverLicenseInfo(DetainedLicense.LicenseID);
            info.ShowDialog();
        }

    }
}
