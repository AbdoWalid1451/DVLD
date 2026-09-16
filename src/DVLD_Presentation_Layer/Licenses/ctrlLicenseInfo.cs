using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Properties;
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
    public partial class ctrlLicenseInfo : UserControl
    {
        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }

         
       public clsLicense license { get { return _license; } }

        private clsLicense _license;

        public void LoadLicenseInfoByLDLAppID(int LDLAppID)
        {
            clsLDLApplication LDLApp = clsLDLApplication.Find(LDLAppID);
            if (LDLApp == null)
            {
                LoadLicenseInfoByLicenseID(LDLAppID);
                return;
            }

            lblLicenseClass.Text = clsLicenseClass.Find( LDLApp.LicenseClassID).ClassName;
            
            clsPerson person = clsPerson.Find(LDLApp.ApplicationInfo.ApplicantPersonID);

            lblName.Text = person.FirstName + " " + person.SecondName + " " + person.ThirdName + " " + person.LastName;
            lblNationalNo.Text = person.NationalNo.ToString();

            if(person.Gendor == 0)
            lblGendor.Text = "Male";
            else lblGendor.Text = "Female";

            lblDateOfBirth.Text = person.DateOfBirth.ToShortDateString();
            pbPersonImage.ImageLocation = person.ImagePath;

            _license = clsLicense.findByAppID(LDLApp.ApplicationID);

            lblLicenseID.Text = license.LicenseID.ToString();
            lblIssueDate.Text = license.IssueDate.ToShortDateString();
            lblIssueReason.Text = license.IssueReason.ToString();

            if (string.IsNullOrEmpty(license.Notes))
                lblNotes.Text = "No Notes";
            else lblNotes.Text = license.Notes.ToString();

            lblExperationDate.Text = license.ExpirationDate.ToShortDateString();
            lblDriverID.Text = license.DriverID.ToString();

            if (license.IsActive)
                lblIsActive.Text = "Yes";
            else lblIsActive.Text = "NO";

            if (clsDetainedLicense.IsLicenseDetained(license.LicenseID))
                lblIsDetained.Text = "Yes";
            else lblIsDetained.Text = "No";


        }

        public void LoadLicenseInfoByLicenseID(int LicenseID)
        {
            _license = clsLicense.FindByID(LicenseID);
            if (_license == null)
            {
                _Reset();
                return;
            }



            lblLicenseClass.Text = clsLicenseClass.Find(_license.LicenseClass).ClassName;

            clsPerson person = clsPerson.Find(clsApplication.Find(license.ApplicationID).ApplicantPersonID);

            lblName.Text = person.FirstName + " " + person.SecondName + " " + person.ThirdName + " " + person.LastName;
            lblNationalNo.Text = person.NationalNo.ToString();

            if (person.Gendor == 0)
                lblGendor.Text = "Male";
            else lblGendor.Text = "Female";

            lblDateOfBirth.Text = person.DateOfBirth.ToShortDateString();
            pbPersonImage.ImageLocation = person.ImagePath;



            lblLicenseID.Text = license.LicenseID.ToString();
            lblIssueDate.Text = license.IssueDate.ToShortDateString();
            lblIssueReason.Text = license.IssueReason.ToString();

            if (string.IsNullOrEmpty(license.Notes))
                lblNotes.Text = "No Notes";
            else lblNotes.Text = license.Notes.ToString();

            lblExperationDate.Text = license.ExpirationDate.ToShortDateString();
            lblDriverID.Text = license.DriverID.ToString();

            if (license.IsActive)
                lblIsActive.Text = "Yes";
            else lblIsActive.Text = "NO";

            if (clsDetainedLicense.IsLicenseDetained(license.LicenseID))
                lblIsDetained.Text = "Yes";
            else lblIsDetained.Text = "No";


        }

        private void _Reset()
        {

            lblLicenseClass.Text = "???";
            lblName.Text = "???";
            lblNationalNo.Text = "???";
            lblGendor.Text = "???";
            lblDateOfBirth.Text = "???";
            pbPersonImage.ImageLocation = "???";
            lblLicenseID.Text = "???";
            lblIssueDate.Text = "???";
            lblIssueReason.Text = "???";
            lblNotes.Text = "???";
            lblExperationDate.Text = "???";
            lblDriverID.Text = "???";
            lblIsActive.Text = "???";
             lblIsDetained.Text = "???";
            pbPersonImage.Image = Resources.Male_512;
        }

        private void ctrlLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
