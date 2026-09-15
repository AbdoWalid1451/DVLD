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
    public partial class frmLicenseHistory : Form
    {
        int PersonID;
        public frmLicenseHistory(int personID)
        {
            InitializeComponent();
            PersonID = personID;
                
        }

        private void ctrlDriverLicenses1_Load(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.LoadPersonInfo(PersonID);
            ctrlPersonCardWithFilter1.Filter.Enabled = false;
            ctrlDriverLicenses1.LoadLicensesHistory(PersonID);
        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {

        }
    }
}
