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

namespace DVLD_Presentation_Layer.Users
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
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
            dgvManageUsers.DataSource = clsUser.GetAll();
            dgvManageUsers.Columns["FullName"].Width = 200;
            lblRecords.Text = clsUser.GetAll().Rows.Count.ToString();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "Person ID" ||  cbFilterBy.Text == "User ID")
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void FilterGridView(string Filter, string Search)
        {
            int ID = 0; DataView dv = clsUser.GetAll().DefaultView;

            if (Filter == "None" || string.IsNullOrEmpty(Search))
            {
                dgvManageUsers.DataSource = dv;
            }

            else if (int.TryParse(Search, out ID))
            {
                
                dv.RowFilter = $"{Filter} = {Search}";
                dgvManageUsers.DataSource = dv;
            }

            else
            {
                dv.RowFilter = $"{Filter} LIKE '{Search}%'";
                dgvManageUsers.DataSource = dv;
            }

            lblRecords.Text = dv.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            if (cbFilterBy.Text == "None" )
            {
                cbIsActive.Visible = false;
                txtFilter.Visible = false;
            }
            else if(cbFilterBy.Text == "Is Active")
            {
                txtFilter.Visible =false;  
                cbIsActive.Visible = true;
                cbIsActive.SelectedIndex = 0;
            }
            else
            {
                cbIsActive.Visible = false;
                txtFilter.Visible = true;
            }
            dgvManageUsers.DataSource = clsUser.GetAll();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            FilterGridView(cbFilterBy.Text.Replace(" ", ""), txtFilter.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = clsUser.GetAll().DefaultView;
            if (cbIsActive.Visible)
            {
                switch (cbIsActive.SelectedIndex)
                {
                    case 1:
                        dv.RowFilter = $"IsActive = 1";
                        dgvManageUsers.DataSource = dv;
                        break;
                    case 2:
                        dv.RowFilter = $"IsActive = 0";
                        dgvManageUsers.DataSource = dv;
                        break;
                    default:
                        dgvManageUsers.DataSource = clsUser.GetAll();
                        break;

                }
            }
            else
                dgvManageUsers.DataSource = clsUser.GetAll();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frmAdd = new frmAddEditUser(-1);
            frmAdd.ShowDialog();
            _RefreshGridView();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddUser_Click(sender, e);
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageUsers.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvManageUsers.CurrentRow.Cells[0].Value;
                string name = dgvManageUsers.CurrentRow.Cells[2].Value.ToString() + " "
                    + dgvManageUsers.CurrentRow.Cells[3].Value.ToString();

                if (MessageBox.Show("Are You sure to delete " + name, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (clsUser.Delete(id))
                    {
                        MessageBox.Show("Deleted Successfully");
                        _RefreshGridView();

                    }
                }
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageUsers.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvManageUsers.CurrentRow.Cells[0].Value;
                frmAddEditUser frm = new frmAddEditUser(id);
                frm.ShowDialog();
                _RefreshGridView();
            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feather is not implemented yet", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feather is not implemented yet", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageUsers.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvManageUsers.CurrentRow.Cells[0].Value;
                frmUserInfo frm = new frmUserInfo(id);
                frm.ShowDialog();
                _RefreshGridView();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageUsers.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvManageUsers.CurrentRow.Cells[0].Value;
                frmChangePassword frm = new frmChangePassword(id);
                frm.ShowDialog();
                _RefreshGridView();
            }
        }
    }
}
