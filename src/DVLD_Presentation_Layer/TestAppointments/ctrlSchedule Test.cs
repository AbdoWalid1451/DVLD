using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Properties;
using System;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Presentation_Layer.TestAppointments
{
    public partial class ctrlSchedule_Test : UserControl
    {

        public ctrlSchedule_Test()
        {
            InitializeComponent();
        }

        public DateTime dtDate 
        { get { return dateTimePicker1.Value; } set { dateTimePicker1.Value = dtDate; }  }

        private void _HandleImage(int TestType)
        {
            switch (TestType)
            {
                case 1:
                    pbImage.Image = Resources.Vision_512;
                    gbTestType.Text = "Vision Test Appointments";
                    break;
                case 2:
                    pbImage.Image = Resources.Written_Test_512;
                    gbTestType.Text = "Written Test Appointments";
                    break;
                case 3:
                    pbImage.Image = Resources.driving_test_512;
                    gbTestType.Text = "Driving Test Appointments";
                    break;

            }

        }
        public void LoadTestInfo(int LDLAppID, int TestTypeID)
        {
            _HandleImage(TestTypeID);

            clsLDLApplication LDLApp = clsLDLApplication.Find(LDLAppID);
            lblDLAppID.Text = lblDLAppID.ToString();
            lblLicensClass.Text = clsLicenseClass.Find(LDLApp.LicenseClassID).ClassName;

            clsPerson applicant = clsPerson.Find(LDLApp.ApplicationInfo.ApplicantPersonID);
            lblName.Text = applicant.FirstName + " " + applicant.SecondName + " " + applicant.ThirdName + " " + applicant.LastName;

            lblTrial.Text = clsScheduleTest.GetAllTestAppointmentByLDLAppIDAndTestType(LDLAppID,TestTypeID).Rows.Count.ToString();

            clsTestType TestType = clsTestType.Find(TestTypeID);
            lblTestFees.Text = TestType.TestTypeFees.ToString();
            gbTestType.Text = TestType.TestTypeTitle.ToString();

           
        }


        private void ctrlSchedule_Test_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now.AddMonths(1);
        }

        private void gbTestType_Enter(object sender, EventArgs e)
        {

        }
    }
}
