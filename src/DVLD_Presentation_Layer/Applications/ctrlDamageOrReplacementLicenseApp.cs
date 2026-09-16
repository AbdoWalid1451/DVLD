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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_Presentation_Layer.Applications
{
    public partial class ctrlDamageOrReplacementLicenseApp : UserControl
    {
        public ctrlDamageOrReplacementLicenseApp()
        {
            InitializeComponent();
        }
        public void _LoadApplicationnewLicenseCard(int NewLicenseID)
        {
            clsLicense newLicense = clsLicense.FindByID(NewLicenseID);
            if (newLicense == null)
            {
                _ResetApplicationCard();
                return;
            }

            lblRLApplicationID.Text = newLicense.ApplicationID.ToString();


            lblRenewLicID.Text = newLicense.LicenseID.ToString();

        }

        public void LoadBasicOldLicense(int OldLicenseID)
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();

            lbllApplicationFees.Text = clsApplicationType.Find("Renew Driving License Service").ApplicationFees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblOldLicID.Text = OldLicenseID.ToString();


        }

        private void _ResetApplicationCard()
        {
            lblRLApplicationID.Text = "???";

            lblRenewLicID.Text = "???";

            lblOldLicID.Text = "???";

        }


        private void ctrlDamageOrReplacementLicenseApp_Load(object sender, EventArgs e)
        {

        }
    }
}
