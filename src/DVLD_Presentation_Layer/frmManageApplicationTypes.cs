using DVLD_Business_Layer;
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

namespace DVLD_Presentation_Layer
{
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void _RefreshGridView()
        {
            dgvApplicationTypes.DataSource = clsApplicationType.GetAll();
            dgvApplicationTypes.Columns["Title"].Width = 250;
            lblRecords.Text = dgvApplicationTypes.Rows.Count.ToString();
        }
        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshGridView();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void udateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplicationTypes.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvApplicationTypes.CurrentRow.Cells[0].Value;
                frmUpdateApplicationType frm = new frmUpdateApplicationType(id);
                frm.ShowDialog();
                _RefreshGridView();
            }
        }
    }
}
