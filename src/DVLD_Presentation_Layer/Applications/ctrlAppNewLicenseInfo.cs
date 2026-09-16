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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Presentation_Layer.Applications
{
    public partial class ctrlAppNewLicenseInfo : UserControl
    {
        public ctrlAppNewLicenseInfo()
        {
            InitializeComponent();
        }

        public TextBox txtNotes { get {  return textBox1; } set{ txtNotes = textBox1; } }

        public void _LoadApplicationRenewLicenseCard(int NewLicenseID)
        {
            clsLicense newLicense = clsLicense.FindByID(NewLicenseID);
            if (newLicense == null)
            {
                _ResetApplicationCard();
                return;
            }

            lblRLApplicationID.Text = newLicense.ApplicationID.ToString();

            
            textBox1.Text = newLicense.Notes.ToString();

            lblRenewLicID.Text = newLicense.LicenseID.ToString();
      

            lblExpirationDate.Text = newLicense.ExpirationDate.ToShortDateString();
        }

        public void LoadBasicOldLicense( int OldLicenseID)
        { 
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();

            lblIssueDate.Text = DateTime.Now.ToShortDateString();

            lbllApplicationFees.Text = clsApplicationType.Find("Renew Driving License Service").ApplicationFees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblOldLicID.Text = OldLicenseID.ToString();
            lblLicenseFees.Text =  clsLicenseClass.Find(clsLicense.FindByID(OldLicenseID).LicenseClass).ClassFees.ToString();

            lblTotalFees.Text = (decimal.Parse(lblLicenseFees.Text) +decimal.Parse(lbllApplicationFees.Text)).ToString();


        }

        private void _ResetApplicationCard()
        {
            lblRLApplicationID.Text = "???";

            lblLicenseFees.Text = "???";

            textBox1.Text = "???";

            lblRenewLicID.Text = "???";

            lblOldLicID.Text = "???";

            lblExpirationDate.Text = "???";
        }


        private void ctrlAppNewLicenseInfo_Load(object sender, EventArgs e)
        {
        
        }
    }
}
