using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Properties;
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
            lblRecords.Text = dgvAllTestApp.Rows.Count.ToString();
        }

        private void btnAddLDLApp_Click(object sender, EventArgs e)
        {
           frmAddTestAppointment frm = new frmAddTestAppointment(_DlDAppID,_TestTypeID,-1);
           frm.ShowDialog();
           _RefreshGridView();
        }
    }
}
