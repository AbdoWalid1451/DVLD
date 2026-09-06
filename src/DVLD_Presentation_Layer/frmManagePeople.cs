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

namespace DVLD_Presentation_Layer
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
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
                    if (clsPerson.Delete(id))
                    {
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
    }
}
