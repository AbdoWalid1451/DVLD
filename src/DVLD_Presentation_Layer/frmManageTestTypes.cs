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
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void _RefreshGridView()
        {
            dgvTestTypes.DataSource = clsTestType.GetAll();
            dgvTestTypes.Columns["Title"].Width = 120;
            dgvTestTypes.Columns["Description"].Width = 250;
            lblRecords.Text = dgvTestTypes.Rows.Count.ToString();
        }
        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshGridView();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            if (dgvTestTypes.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvTestTypes.CurrentRow.Cells[0].Value;
                frmUpdateTestType frm = new frmUpdateTestType(id);
                frm.ShowDialog();
                _RefreshGridView();
            }

        }
    }
}
