using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Licenses
{
    public partial class frmIssueDriverLicenseForTheFirstTime : Form
    {
        clsLDLApplication  _LDLApp;
        public frmIssueDriverLicenseForTheFirstTime(int LDLAppID)
        {
            InitializeComponent();
            _LDLApp = clsLDLApplication.Find(LDLAppID);
            if (_LDLApp == null)
            {
                MessageBox.Show("Didn't Find Local driving Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void frmIssueDriverLicenseForTheFirstTime_Load(object sender, EventArgs e)
        {
            ctrlLDLAppInfo1.LoadLDLAppInfo(_LDLApp.LDLAppID);
        }

        private int CreateDriver()
        {
            clsDriver driver = new clsDriver();
            driver.PersonID = _LDLApp.ApplicationInfo.ApplicantPersonID;
            driver.CreatedDate = DateTime.Now;
            driver.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            driver.AddNew();

            return driver.DriverID;
        }
        
        private void FillLicenseInfo(clsLicense license)
        {
            

            license.ApplicationID = _LDLApp.ApplicationID;
            license.DriverID = CreateDriver();
            license.IssueDate = DateTime.Now;
            license.LicenseClass = _LDLApp.LicenseClassID;
            license.ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.Find(_LDLApp.LicenseClassID).DefaultValidityLength);
            license.Notes = txtNotes.Text;
            license.PaidFees = clsLicenseClass.Find(_LDLApp.LicenseClassID).ClassFees;
            license.IsActive = true;
            license.IssueReason = clsLicense.enIssueReason.FirstTime;
            license.CreatedByUserID = clsGlobal.CurrentUser.UserID;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsLicense license = new clsLicense();
            FillLicenseInfo(license);

            
            
            if(license.Save())
            {

                clsApplication.ChangeStatus(_LDLApp.ApplicationID, clsApplication.enApplicationStatus.Completed);
            
                MessageBox.Show("License Issued Successfully","Issued",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to Issue License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            this.Close();

        }
    }
}
