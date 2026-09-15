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
using System.Xml.Linq;

namespace DVLD_Presentation_Layer.lnternationalLicenseApplication
{
    public partial class ctrlInterLicenseInfo : UserControl
    {
        public ctrlInterLicenseInfo()
        {
            InitializeComponent();
        }

        private clsInternationalLicense internationalLicense;

        public clsInternationalLicense InternationalLicense { get { return internationalLicense; } }


        public void LoadInternationalLicenseInfo(int interantionalLicenseID)
        {
            internationalLicense = clsInternationalLicense.FindByID(interantionalLicenseID);

            if (internationalLicense == null)
            {
                Reset();
                return;
            }

            lblIntLicenseID.Text = interantionalLicenseID.ToString();
            lblLicenseID.Text = internationalLicense.IssuedUsingLocalLicenseID.ToString(); 
            lblIssueDate.Text = internationalLicense.IssueDate.ToShortDateString();
            lblApplicationID.Text = internationalLicense.ApplicationID.ToString();

            if (internationalLicense.IsActive)
                lblIsActive.Text = "Yes";
            else lblIsActive.Text = "No";

            lblDriverID.Text = internationalLicense.DriverID.ToString();
            lblExperationDate.Text = internationalLicense.ExpirationDate.ToShortDateString();


                clsPerson person = clsPerson.Find(clsApplication.Find(internationalLicense.ApplicationID).ApplicantPersonID);

            lblName.Text = person.FirstName + " " + person.SecondName + " " + person.ThirdName + " " + person.LastName;
            lblNationalNo.Text = person.NationalNo.ToString();

            if (person.Gendor == 0)
                lblGendor.Text = "Male";
            else lblGendor.Text = "Female";

            lblDateOfBirth.Text = person.DateOfBirth.ToShortDateString();
            pbPersonImage.ImageLocation = person.ImagePath;


        }

        private void Reset()
        {
            lblIntLicenseID.Text = "???";
            lblLicenseID.Text = "???";
            lblIssueDate.Text = "???";
            lblApplicationID.Text = "???";
            lblIsActive.Text = "???";

            lblDriverID.Text = "???";
            lblExperationDate.Text = "???";

            lblName.Text = "???";
            lblNationalNo.Text = "???";

             lblGendor.Text = "???";

            lblDateOfBirth.Text = "???";
            pbPersonImage.Image = Resources.Male_512;
        }


        private void ctrlInterLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
