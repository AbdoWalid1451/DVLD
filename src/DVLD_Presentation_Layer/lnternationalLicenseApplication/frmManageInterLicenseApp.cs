using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Licenses;
using DVLD_Presentation_Layer.Users;
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
    public partial class frmManageInterLicenseApp : Form
    {
        public frmManageInterLicenseApp()
        {
            InitializeComponent();
        }

        private void frmManageInterLicenseApp_Load(object sender, EventArgs e)
        {
            _RefreshGridView();
        }

        private void _RefreshGridView()
        {
            dgvAllInterApp.DataSource = clsInternationalLicense.GetAll();
            lblRecords.Text = dgvAllInterApp.Rows.Count.ToString();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

        }

        private void txtFilter_TextChanged_1(object sender, EventArgs e)
        {
            if(txtFilter.Text == "")
                _RefreshGridView();

            else
            {
                DataView dv = clsInternationalLicense.GetAll().DefaultView;
                dv.RowFilter = $"InternationalLicenseID = {txtFilter.Text}";
                dgvAllInterApp.DataSource = dv;
                lblRecords.Text = dv.Count.ToString();
            }
                

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddLDLApp_Click(object sender, EventArgs e)
        {
            frmAddInternationLicenseApp frmAdd = new frmAddInternationLicenseApp();
            frmAdd.ShowDialog();
            _RefreshGridView();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllInterApp.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvAllInterApp.CurrentRow.Cells[1].Value;
                frmPersonDetails frm = new frmPersonDetails(clsApplication.Find(id).ApplicantPersonID);
                frm.ShowDialog();
            }
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllInterApp.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvAllInterApp.CurrentRow.Cells[0].Value;
                frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(id);
                frm.ShowDialog();
            }
        }

        private void showPersonLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllInterApp.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvAllInterApp.CurrentRow.Cells[1].Value;
                frmLicenseHistory frm = new frmLicenseHistory(clsApplication.Find(id).ApplicantPersonID);
                frm.ShowDialog();
            }
        }

    }
}
