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
    public partial class frmDriverLicenseInfo : Form
    {
        int _LDLAppID;
        public frmDriverLicenseInfo(int LDLAppID)
        {
            InitializeComponent();
            _LDLAppID = LDLAppID;
        }

        private void frmDriverLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlLicenseInfo1.LoadLicenseInfoByLDLAppID(_LDLAppID);
        }
    }
}
