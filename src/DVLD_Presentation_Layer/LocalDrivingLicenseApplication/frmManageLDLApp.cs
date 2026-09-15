using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Licenses;
using DVLD_Presentation_Layer.LocalDrivingLicenseApplication;
using DVLD_Presentation_Layer.TestAppointments;
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

namespace DVLD_Presentation_Layer.Applications
{
    public partial class frmManageLDLApp : Form
    {
        public frmManageLDLApp()
        {
            InitializeComponent();
        }

        private void frmManageLDLApp_Load(object sender, EventArgs e)
        {
            _RefreshGridView();
            cbFilterBy.SelectedIndex = 0;
        }

        private void _RefreshGridView()
        {
            dgvAllLDLApp.DataSource = clsLDLApplication.GetAll();
            dgvAllLDLApp.Columns["DrivingClass"].Width = 250;
            dgvAllLDLApp.Columns["FullName"].Width = 300;
            dgvAllLDLApp.Columns["ApplicationDate"].Width = 150;
            lblRecords.Text = dgvAllLDLApp.Rows.Count.ToString();
            
        }

        private void btnAddLDLApp_Click(object sender, EventArgs e)
        {
            frmAddNewLDLApp addNewLDLApp = new frmAddNewLDLApp(-1);
            addNewLDLApp.ShowDialog();
            _RefreshGridView();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "LDLAppID")
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

        }

        private void FilterGridView(string Filter, string Search)
        {
            int ID = 0; DataView dv = clsLDLApplication.GetAll().DefaultView;

            if (Filter == "None" || string.IsNullOrEmpty(Search))
            {
                dgvAllLDLApp.DataSource = dv;
            }

            else if (int.TryParse(Search, out ID))
            {

                dv.RowFilter = $"{Filter} = {Search}";
                dgvAllLDLApp.DataSource = dv;
            }

            else
            {
                dv.RowFilter = $"{Filter} LIKE '{Search}%'";
                dgvAllLDLApp.DataSource = dv;
            }

            lblRecords.Text = dv.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            if (cbFilterBy.Text == "None")
            {
                cbStatus.Visible = false;
                txtFilter.Visible = false;
            }
            else if (cbFilterBy.Text == "Status")
            {
                txtFilter.Visible = false;
                cbStatus.Visible = true;
                cbStatus.SelectedIndex = 0;
            }
            else
            {
                cbStatus.Visible = false;
                txtFilter.Visible = true;
            }
            _RefreshGridView();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            FilterGridView(cbFilterBy.Text.Replace(" ", ""), txtFilter.Text);
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = clsLDLApplication.GetAll().DefaultView;
            if (cbStatus.Visible)
            {
                switch (cbStatus.SelectedIndex)
                {
                    case 1:
                        dv.RowFilter = $"Status = 'New'";
                        dgvAllLDLApp.DataSource = dv;
                        break;
                    case 2:
                        dv.RowFilter = $"Status = 'Canceled'";
                        dgvAllLDLApp.DataSource = dv;
                        break;
                    case 3:
                        dv.RowFilter = $"Status = 'Completed'";
                        dgvAllLDLApp.DataSource = dv;
                        break;
                    default:
                        _RefreshGridView();
                        break;

                }
            }
            else
                _RefreshGridView();

            lblRecords.Text = dgvAllLDLApp.RowCount.ToString();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllLDLApp.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvAllLDLApp.CurrentRow.Cells[0].Value;
                frmAddNewLDLApp frm = new frmAddNewLDLApp(id);
                frm.ShowDialog();
                _RefreshGridView();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllLDLApp.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvAllLDLApp.CurrentRow.Cells[0].Value;
                string name = dgvAllLDLApp.CurrentRow.Cells[2].Value.ToString() + " "
                    + dgvAllLDLApp.CurrentRow.Cells[3].Value.ToString();

                if (MessageBox.Show("Are You sure to delete " + name, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (clsLDLApplication.Delete(id))
                    {
                        MessageBox.Show("Deleted Successfully");
                        _RefreshGridView();

                    }
                }
            }
        }

        private void cancelApplicationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgvAllLDLApp.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvAllLDLApp.CurrentRow.Cells[0].Value;

                string name =dgvAllLDLApp.CurrentRow.Cells[3].Value.ToString();

                if (MessageBox.Show("Are You sure to Cancel " + name, "Canceled", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (clsApplication.ChangeStatus(clsLDLApplication.Find(id).ApplicationID,clsApplication.enApplicationStatus.Canceled))
                    {
                        MessageBox.Show("Canceled Successfully");
                        _RefreshGridView();

                    }
                }
            }

        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllLDLApp.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvAllLDLApp.CurrentRow.Cells[0].Value;
                frmLDLAppInfo frm = new frmLDLAppInfo(id);
                frm.ShowDialog();
                _RefreshGridView();
            }
        }


        private void ScheduleTest(int TestType)
        { 
            if (dgvAllLDLApp.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvAllLDLApp.CurrentRow.Cells[0].Value;
                frmScheduleTest frm = new frmScheduleTest(id, TestType);//1-->VisionTest
                frm.ShowDialog();
                _RefreshGridView();
            }

        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScheduleTest(1);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScheduleTest(2);
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScheduleTest(3);
        }

        private void EditEnableInTests(bool enVision , bool enWritten , bool enDriving)
        {
            scheduleVisionTestToolStripMenuItem.Enabled = enVision;
            scheduleWrittenTestToolStripMenuItem.Enabled = enWritten;
            scheduleStreetTestToolStripMenuItem.Enabled = enDriving;
        }
    
        private void TestsLogic()
        {
            if (dgvAllLDLApp.CurrentRow.Cells.Count > 0)
            {
                int TestPassed = (int)dgvAllLDLApp.CurrentRow.Cells[5].Value;

                switch (TestPassed)
                {
                    case 0:
                        EditEnableInTests(true, false, false); break;
                    case 1:
                        EditEnableInTests(false, true, false); break;
                    case 2:
                        EditEnableInTests(false, false, true); break;
                    case 3:
                        EditEnableInTests(false, false, false);
                        ScehduleToolStripMenuItem.Enabled = false;
                        issueDrivingLisenceToolStripMenuItem.Enabled = true;
                        break;


                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            TestsLogic();

            string status = (string)dgvAllLDLApp.CurrentRow.Cells[6].Value;

            switch (status)
            {
                case "New":
                    issueDrivingLisenceToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = false;

                    editToolStripMenuItem.Enabled = true;
                    deleteToolStripMenuItem.Enabled = true;
                    cancelApplicationToolStripMenuItem.Enabled = true;
                    ScehduleToolStripMenuItem.Enabled = true;
                
                    TestsLogic();
                    break;
                case "Canceled":
                    editToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = true;
                    cancelApplicationToolStripMenuItem.Enabled = false;
                    ScehduleToolStripMenuItem.Enabled = false;
                    EditEnableInTests(false, false, false);
                    issueDrivingLisenceToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = false;
                    break;
                case "Completed":
                    editToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = false;
                    cancelApplicationToolStripMenuItem.Enabled = false;
                    ScehduleToolStripMenuItem.Enabled = false;
                    EditEnableInTests(false, false, false);
                    issueDrivingLisenceToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = true;
                    break;
              

            }

            

        }


        private void issueDrivingLisenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllLDLApp.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvAllLDLApp.CurrentRow.Cells[0].Value;
                frmIssueDriverLicenseForTheFirstTime frm = new frmIssueDriverLicenseForTheFirstTime(id);
                frm.ShowDialog();
                _RefreshGridView();
            }
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllLDLApp.CurrentRow.Cells.Count > 0)
            {
                int id = (int)dgvAllLDLApp.CurrentRow.Cells[0].Value;
                frmDriverLicenseInfo frm = new frmDriverLicenseInfo(id);
                frm.ShowDialog();
                _RefreshGridView();
            }
        }

        private void sHowPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllLDLApp.CurrentRow.Cells.Count > 0)
            {
                string NationalNo = (string)dgvAllLDLApp.CurrentRow.Cells[2].Value;
                frmLicenseHistory frm = new frmLicenseHistory(clsPerson.Find(NationalNo).PersonID);
                frm.ShowDialog();
                _RefreshGridView();
            }
        }
    }
}
