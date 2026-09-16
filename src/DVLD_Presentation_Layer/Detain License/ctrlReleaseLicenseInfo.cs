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

namespace DVLD_Presentation_Layer.Detain_License
{
    public partial class ctrlReleaseLicenseInfo : UserControl
    {
        public ctrlReleaseLicenseInfo()
        {
            InitializeComponent();
        }

        public void _LoadReleaseInfo(int ApplicationID)
        {
           lblApplicationID.Text = ApplicationID.ToString();
        }

        public void LoadBasicByLicenseID(int LicenseID)
        {
            clsDetainedLicense detainedLicense = clsDetainedLicense.findDetainedLicenseByLicenseID(LicenseID); 

            if(detainedLicense == null)
            {
                _ResetApplicationCard();
                return;
            }

            lblDetainID.Text = detainedLicense.DetainID.ToString();
            lblDetainDate.Text = detainedLicense.DetainDate.ToShortDateString();

            lblApplicationFees.Text = clsApplicationType.Find("Release Detained Driving Licsense").ApplicationFees.ToString();

            lblLicenseID.Text = detainedLicense.LicenseID.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblFineFees.Text = detainedLicense.FineFees.ToString();

            lblTotalFees.Text = (double.Parse(lblFineFees.Text)+double.Parse(lblApplicationFees.Text)).ToString();
        }

        private void _ResetApplicationCard()
        {
            lblDetainID.Text = "???";

            lblDetainDate.Text = "???";

            lblApplicationFees.Text = "???";
            lblTotalFees.Text = "???";
            lblLicenseID.Text = "???";

            lblCreatedBy.Text = "???";
            lblFineFees.Text = "???";

            lblApplicationID.Text = "???";
        }

        private void ctrlReleaseLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
