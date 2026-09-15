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
    public partial class frmInternationalLicenseInfo : Form
    {
        private int InternationalLicenseID;
        public frmInternationalLicenseInfo(int internationalLicenseID)
        {
            InitializeComponent();
            InternationalLicenseID = internationalLicenseID;

        }

        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlInterLicenseInfo1.LoadInternationalLicenseInfo(InternationalLicenseID);
        }
    }
}
