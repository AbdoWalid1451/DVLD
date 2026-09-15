using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Properties;
using DVLD_Presentation_Layer.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.TestAppointments
{
    public partial class frmScheduleTest : Form
    {
        int _DlDAppID;
        int _TestTypeID;

        public frmScheduleTest(int DlDAppID, int TestTypeID)
        {
            InitializeComponent();
            _DlDAppID = DlDAppID;
            _TestTypeID = TestTypeID;
        }

        private void frmVisionTestAppointment_Load(object sender, EventArgs e)
        {
            ctrlLDLAppInfo1.LoadLDLAppInfo(_DlDAppID);
            _RefreshGridView();
            IntialForm();

        }

        private void IntialForm()
        {
            switch (_TestTypeID)
            {
                case 1:
                    pbTestApp.Image = Resources.Vision_512;
                    lblTestApp.Text = "Vision Test Appointments";
                    break;
                case 2:
                    pbTestApp.Image = Resources.Written_Test_512;
                    lblTestApp.Text = "Written Test Appointments";
                    break;
                case 3:
                    pbTestApp.Image = Resources.driving_test_512;
                    lblTestApp.Text = "Driving Test Appointments";
                    break;

            }

        }

        private void _RefreshGridView()
        {
            dgvAllTestApp.DataSource =
                clsScheduleTest.GetAllTestAppointmentByLDLAppIDAndTestType(_DlDAppID, _TestTypeID);
            if (dgvAllTestApp.Rows.Count > 0)
            {
                dgvAllTestApp.Columns["AppointmentDate"].Width = 200;
            }
            lblRecords.Text = dgvAllTestApp.Rows.Count.ToString();
        }

        private void btnAddLDLApp_Click(object sender, EventArgs e)
        {
            if(clsScheduleTest.IsThereAppointment(_DlDAppID,_TestTypeID,false))
            {
                MessageBox.Show("There is already an active Test Appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(clsTest.IsThatTestPassed(_DlDAppID, _TestTypeID))
            {
                MessageBox.Show("That Test Already Passed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmAddTestAppointment frm = new frmAddTestAppointment(_DlDAppID, _TestTypeID, -1);
           frm.ShowDialog();
           _RefreshGridView();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllTestApp.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvAllTestApp.CurrentRow.Cells[0].Value;
                frmAddTestAppointment frm = new frmAddTestAppointment(_DlDAppID, _TestTypeID,id);
                frm.ShowDialog();
                _RefreshGridView();
            }
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllTestApp.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvAllTestApp.CurrentRow.Cells[0].Value;
                frmTest frm = new frmTest(id);
                frm.ShowDialog();
                _RefreshGridView();
            }
        }

        private void AfterTestTook()
        { 
            bool IsLooked = true;
            if (dgvAllTestApp.RowCount > 0)
            {
                IsLooked = (bool)dgvAllTestApp.CurrentRow.Cells[3].Value;
 
            }
            if(IsLooked)
            {
               takeTestToolStripMenuItem.Enabled = false;
                editToolStripMenuItem.Enabled = false;
            }
            else
            {
                takeTestToolStripMenuItem.Enabled = true;
                editToolStripMenuItem.Enabled = true;
            }


        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            AfterTestTook();
        }
    }
}
