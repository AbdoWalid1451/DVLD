using DVLD_Business_Layer;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_Presentation_Layer
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
            cbFilterBy.SelectedIndex = 0;
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {

            _RefreshGridView();
        }

        private void _RefreshGridView()
        {
            dgvAllPeople.DataSource = clsPerson.GetAll();
            lblRecords.Text = clsPerson.GetAll().Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmSavePerson frm = new frmSavePerson(-1);
            frm.ShowDialog();
            _RefreshGridView();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllPeople.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvAllPeople.CurrentRow.Cells[0].Value;
                string name = dgvAllPeople.CurrentRow.Cells[1].Value.ToString() + " "
                    + dgvAllPeople.CurrentRow.Cells[2].Value.ToString();

                if (MessageBox.Show("Are You sure to delete " + name, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string ImagePath =clsPerson.Find(id).ImagePath;
                    if ( clsPerson.Delete(id))
                    {
                        File.Delete(ImagePath);
                        MessageBox.Show("Deleted Successfully");
                        _RefreshGridView();

                    }
                }
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllPeople.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvAllPeople.CurrentRow.Cells[0].Value;
                frmSavePerson frm = new frmSavePerson(id);
                frm.ShowDialog();
                _RefreshGridView();
            }
        }

     
        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddPerson_Click(sender, e);
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feather is not implemented yet","Not Ready!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feather is not implemented yet", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllPeople.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvAllPeople.CurrentRow.Cells[0].Value;
                frmPersonDetails frm = new frmPersonDetails(id);
                frm.ShowDialog();
                _RefreshGridView();
            }
        }

        private void FilterGridView(string Filter,string Search)
        {
            int ID = 0; DataView dv = clsPerson.GetAll().DefaultView;

            if(Filter == "None" || string.IsNullOrEmpty(Search))
            {
                dgvAllPeople.DataSource = dv;
            }

            else if (int.TryParse(Search, out ID))
            {
                dv.RowFilter = $"{Filter} = {Search}";
                dgvAllPeople.DataSource = dv;
            }

            else
            {
                dv.RowFilter = $"{Filter} LIKE '{Search}%'";
                dgvAllPeople.DataSource= dv;
            }

            lblRecords.Text = dv.Count.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = "";
          if(cbFilterBy.SelectedIndex == 0)
                txtFilter.Visible = false;
          else
                txtFilter.Visible = true;

        }

        private void mtxtFilter_TextChanged(object sender, EventArgs e)
        {
            FilterGridView(cbFilterBy.Text.Replace(" ", ""), txtFilter.Text);
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID" )
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
        }
    }
}
