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

namespace DVLD_Presentation_Layer.Drivers
{
    public partial class frmManageDrivers : Form
    {
        public frmManageDrivers()
        {
            InitializeComponent();
        }

        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _RefreshGridView();
            cbFilterBy.SelectedIndex = 0;
        }
        private void _RefreshGridView()
        {
            dgvManageUsers.DataSource = clsDriver.GetAll();
            dgvManageUsers.Columns["FullName"].Width = 250;
            lblRecords.Text = dgvManageUsers.Rows.Count.ToString();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "Driver ID")
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

        }

        private void FilterGridView(string Filter, string Search)
        {
            int ID = 0; DataView dv = clsDriver.GetAll().DefaultView;

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

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            FilterGridView(cbFilterBy.Text.Replace(" ", ""), txtFilter.Text);
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            if (cbFilterBy.Text == "None")
            {
                txtFilter.Visible = false;
            }
            else
            {
                txtFilter.Visible = true;
            }
            dgvManageUsers.DataSource = clsDriver.GetAll();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
