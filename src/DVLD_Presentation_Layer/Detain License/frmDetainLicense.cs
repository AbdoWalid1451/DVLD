using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Applications;
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
    public partial class frmDetainLicense : Form
    {
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        clsDetainedLicense DetainedLicense;

        private void FillInfoForDetainingLicense(clsDetainedLicense DetainedLicense)
        {
            DetainedLicense.LicenseID = ctrlDriverLicenseInfoWithFilter1.license.LicenseID;
            DetainedLicense.DetainDate = DateTime.Now;
            DetainedLicense.FineFees = decimal.Parse(ctrlDetainInfo1.txtFine.Text);
            DetainedLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            DetainedLicense.IsReleased = false;
            DetainedLicense.ReleaseDate = null;
            DetainedLicense.ReleasedByUserID = -1;
            DetainedLicense.ReleaseApplicationID = -1;
        }

        private bool Validation()
        {
            if (ctrlDriverLicenseInfoWithFilter1.license == null)
            {
                MessageBox.Show("You should select a license first", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(ctrlDetainInfo1.txtFine.Text))
            {
                MessageBox.Show("Enter Fine Fees", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (clsDetainedLicense.IsLicenseDetained(ctrlDriverLicenseInfoWithFilter1.license.LicenseID))
            {
                MessageBox.Show("This license is Already Detained", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!ctrlDriverLicenseInfoWithFilter1.license.IsActive)
            {
                MessageBox.Show("This license is not Active", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }
        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (!Validation())
                return;


            DetainedLicense = new clsDetainedLicense();

            FillInfoForDetainingLicense(DetainedLicense);

            if (DetainedLicense.Save())
            {

                clsLicense.Activation(ctrlDriverLicenseInfoWithFilter1.license.LicenseID, false);

                MessageBox.Show("Detain License issued successfully", "Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ctrlDetainInfo1._LoadDetainInfo(DetainedLicense.LicenseID);
              
                ilblShowLiceneseInfo.Enabled = true;
                ctrlDetainInfo1.txtFine.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.Filter.Enabled = false; 
                btnDetain.Enabled = false;

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
                ctrlDetainInfo1.LoadBasicOldLicense(ctrlDriverLicenseInfoWithFilter1.license.LicenseID);
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
