using DVLD_Business_Layer;
using DVLD_Presentation_Layer.lnternationalLicenseApplication;
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
    public partial class ctrlDriverLicenses : UserControl
    {
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }


     
        public void LoadLicensesHistory(int personID)
        {
            dgvLocalLicenseHistory.DataSource = clsLicense.GetPersonLicenseHistory(personID);
            lblLocalRecords.Text =dgvLocalLicenseHistory.Rows.Count.ToString();
        
            dgvInterLicensesHistory.DataSource = clsInternationalLicense.GetPersonLicenseHistory(personID);
            lblInterRecords.Text = dgvInterLicensesHistory.Rows.Count.ToString();
        }

        private void ctrlDriverLicenses_Load(object sender, EventArgs e)
        {

        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLocalLicenseHistory.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvLocalLicenseHistory.CurrentRow.Cells[0].Value;
                frmDriverLicenseInfo frm = new frmDriverLicenseInfo(id);
                frm.ShowDialog();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvInterLicensesHistory.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvInterLicensesHistory.CurrentRow.Cells[0].Value;
                frmInternationalLicenseInfo  frm = new frmInternationalLicenseInfo(id);
                frm.ShowDialog();
            }

        }
    }
}
