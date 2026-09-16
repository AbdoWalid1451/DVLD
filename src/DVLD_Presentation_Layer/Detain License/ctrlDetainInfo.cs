using System;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Detain_License
{
    public partial class ctrlDetainInfo : UserControl
    {
        public ctrlDetainInfo()
        {
            InitializeComponent();
        }

        public TextBox txtFine { get { return txtFineFees; } set { txtFineFees = txtFine; } }

        public void _LoadDetainInfo(int DetainID)
        {
            lblDetainID.Text = DetainID.ToString();
        }

        public void LoadBasicOldLicense(int LicenseID)
        {
            lblLicenseID.Text = LicenseID.ToString();
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;

        }

        private void _ResetApplicationCard()
        {
            lblDetainID.Text = "???";

            lblDetainDate.Text = "???";

            txtFineFees.Text = "";

            lblLicenseID.Text = "???";

            lblCreatedBy.Text = "???";
        }


        private void ctrlDetainInfo_Load(object sender, EventArgs e)
        {

        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
