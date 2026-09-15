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

namespace DVLD_Presentation_Layer.TestAppointments
{
    public partial class frmAddTestAppointment : Form
    {
        enum enMode { Add ,Update ,retake}

        int _LDLAppID;
        int _TestTypeID;
        enMode Mode;
        clsScheduleTest TestApp;
        public frmAddTestAppointment(int LDLAppID , int TestTypeID ,int TestAppID)
        {
            InitializeComponent();
            _LDLAppID = LDLAppID;
            _TestTypeID = TestTypeID;

            if(TestAppID != -1)
            {
                TestApp = clsScheduleTest.Find(TestAppID);
                Mode = enMode.Update;


            }
            else
            {
                TestApp = new clsScheduleTest();
                Mode = enMode.Add;
            }

            if(clsScheduleTest.IsThereAppointment( LDLAppID, TestTypeID,true))
            {
                Mode = enMode.retake;
                TestApp = new clsScheduleTest();
            }



        }
        
        public void InCaseRetakeTest()
        {
            gbRetakeTest.Enabled = true;
            lblRAppFees.Text = clsApplicationType.Find("Retake Test").ApplicationFees.ToString();
            lblTotalFees.Text = (decimal.Parse(lblRAppFees.Text) 
                + clsTestType.Find(_TestTypeID).TestTypeFees).ToString();
        }


        private void frmAddTestAppointment_Load(object sender, EventArgs e)
        {
            ctrlSchedule_Test1.LoadTestInfo(_LDLAppID, _TestTypeID);
            if (TestApp != null)
            {
                ctrlSchedule_Test1.dtDate = TestApp.AppointmentDate;
            }

            if (Mode == enMode.retake)
                InCaseRetakeTest();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _FillTestAppointmentFirstTime()
        {
            TestApp.LDLAppID = _LDLAppID;
            TestApp.TestTypeID = _TestTypeID;
            TestApp.PaidFees = clsTestType.Find(_TestTypeID).TestTypeFees;
            TestApp.CreatedByUserID = clsGlobal.CurrentUser.UserID;
        }

        private int MakeAppForRetake()
        {
            clsApplication application = new clsApplication();

            application.ApplicantPersonID = clsLDLApplication.Find(_LDLAppID).ApplicationInfo.ApplicantPersonID;

            application.AppDate = DateTime.Now;
            application.AppTypeID = clsApplicationType.Find("Retake Test").ApplicationTypeID;
            application.ApplicationStatus = clsApplication.enApplicationStatus.New;
            application.LastStatusDate = DateTime.Now;
            application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            application.Save();

            return application.ApplicationID;

        }

        private void _FillRetakeTestAppointment()
        {

            TestApp.RetakeTestAppID = MakeAppForRetake();
            _FillTestAppointmentFirstTime();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TestApp.AppointmentDate =  ctrlSchedule_Test1.dtDate;

            if (Mode == enMode.Add)
                _FillTestAppointmentFirstTime();
            
            else if (Mode == enMode.retake)
                _FillRetakeTestAppointment();

            if (TestApp.Save())
            {
                MessageBox.Show("Test Appointment Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Failed to Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void ctrlSchedule_Test1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
