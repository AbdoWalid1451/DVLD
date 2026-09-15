using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Tests
{
    public partial class frmTest : Form
    {

        int TestAppID;
        clsTest Test;


        public frmTest(int TestAppID)
        {
            InitializeComponent();

            this.TestAppID = TestAppID;
            
            Test = clsTest.FindByTestAppointmentID(TestAppID);
            if (Test == null)
            {
                Test = new clsTest();
            }
            else
            {
                Took();
            }

        }

        private void Took()
        {
            rbFail.Enabled = false;
            rbPass.Enabled = false;
            txtNotes.Enabled = false;
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            ctrlTestInfo1.LoadTestInfo(TestAppID);
        }

        private void _FillTestInfo()
        {
            Test.TestAppointmentID = TestAppID;
            Test.TestResult = rbPass.Checked;
            Test.Notes = txtNotes.Text;
            Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;

        }


        private void btnSave_Click(object sender, EventArgs e)
        {

                _FillTestInfo();
                Took();
             
      

            if (Test.Save())
                MessageBox.Show("Test Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Test Failed to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            ctrlTestInfo1.LoadTestInfo(TestAppID);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
