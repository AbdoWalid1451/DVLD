using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Licenses;
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

namespace DVLD_Presentation_Layer.Detain_License
{
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshGridView();
            cbFilterBy.SelectedIndex = 0;
        }

        private void _RefreshGridView()
        {
            dgvManageDetainedLicenses.DataSource = clsDetainedLicense.GetAll();
            lblRecords.Text = dgvManageDetainedLicenses.Rows.Count.ToString();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void FilterGridView(string Filter, string Search)
        {
            DataView dv = clsDetainedLicense.GetAll().DefaultView;

            if (Filter == "None" || string.IsNullOrEmpty(Search))
            {
                dgvManageDetainedLicenses.DataSource = dv;
            }

            else 
            {

                dv.RowFilter = $"{Filter} = {Search}";
                dgvManageDetainedLicenses.DataSource = dv;
            }


            lblRecords.Text = dv.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            if (cbFilterBy.Text == "None")
            {
                cbIsActive.Visible = false;
                txtFilter.Visible = false;
            }
            else if (cbFilterBy.Text == "Is Released")
            {
                txtFilter.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.SelectedIndex = 0;
            }
            else
            {
                cbIsActive.Visible = false;
                txtFilter.Visible = true;
            }
            dgvManageDetainedLicenses.DataSource = clsDetainedLicense.GetAll();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            FilterGridView(cbFilterBy.Text.Replace(" ", ""), txtFilter.Text);
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = clsDetainedLicense.GetAll().DefaultView;
            if (cbIsActive.Visible)
            {
                switch (cbIsActive.SelectedIndex)
                {
                    case 1:
                        dv.RowFilter = $"IsReleased = 1";
                        dgvManageDetainedLicenses.DataSource = dv;
                        break;
                    case 2:
                        dv.RowFilter = $"IsReleased = 0";
                        dgvManageDetainedLicenses.DataSource = dv;
                        break;
                    default:
                        dgvManageDetainedLicenses.DataSource = clsDetainedLicense.GetAll();
                        break;

                }
            }
            else
                dgvManageDetainedLicenses.DataSource = clsDetainedLicense.GetAll();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            _RefreshGridView();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedlicense frm = new frmReleaseDetainedlicense();
            frm.ShowDialog();
            _RefreshGridView();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageDetainedLicenses.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvManageDetainedLicenses.CurrentRow.Cells[6].Value;
                frmPersonDetails frm = new frmPersonDetails(clsApplication.Find(id).ApplicantPersonID);
                frm.ShowDialog();
            }
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageDetainedLicenses.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvManageDetainedLicenses.CurrentRow.Cells[1].Value;
                frmDriverLicenseInfo frm = new frmDriverLicenseInfo(id);
                frm.ShowDialog();
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageDetainedLicenses.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvManageDetainedLicenses.CurrentRow.Cells[6].Value;
                frmLicenseHistory frm = new frmLicenseHistory(clsApplication.Find(id).ApplicantPersonID);
                frm.ShowDialog();
            }
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageDetainedLicenses.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvManageDetainedLicenses.CurrentRow.Cells[1].Value;
                frmReleaseDetainedlicense frm = new frmReleaseDetainedlicense(id);
                frm.ShowDialog();
                _RefreshGridView();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if((bool)dgvManageDetainedLicenses.CurrentRow.Cells[4].Value)
                releaseDetainedLicenseToolStripMenuItem.Enabled = false;
            else
                releaseDetainedLicenseToolStripMenuItem.Enabled=true;

        }
    }
}
