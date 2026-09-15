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

namespace DVLD_Presentation_Layer.lnternationalLicenseApplication
{
    public partial class ctrlInterAppInfo : UserControl
    {
        public ctrlInterAppInfo()
        {
            InitializeComponent();
        }


        public void _LoadInterAppInfo(int InternationalLicenseID)
        {
            clsInternationalLicense InterLicense = clsInternationalLicense.FindByID(InternationalLicenseID);

            if (InterLicense == null)
            {
                Reset();
                return;
            }

            lbllILAppID.Text = InterLicense.ApplicationID.ToString();
            lblILLicenseID.Text= InterLicense.InternationalLicenseID.ToString();
            lblLocalLicenseID.Text = InterLicense.IssuedUsingLocalLicenseID.ToString();

        }

        private void Reset()
        {
            lbllILAppID.Text = "???";
            lblILLicenseID.Text = "???";
            lblLocalLicenseID.Text = "???";
        }

        private void ctrlInterAppInfo_Load(object sender, EventArgs e)
        {
            lblAppDate.Text = DateTime.Now.ToShortDateString(); 
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblFees.Text = clsApplicationType.Find("New Local Driving License Service").ApplicationFees.ToString();
        }

       

    }
}
