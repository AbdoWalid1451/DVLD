using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.LocalDrivingLicenseApplication
{
    public partial class frmLDLAppInfo : Form
    {
        public int LDLAppID;
        public frmLDLAppInfo(int ID)
        {
            InitializeComponent();
            LDLAppID = ID;
        }

        private void frmLDLAppInfo_Load(object sender, EventArgs e)
        { 
            ctrlLDLAppInfo1.LoadLDLAppInfo(LDLAppID);

        }
    }
}
