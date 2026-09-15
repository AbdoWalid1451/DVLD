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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Presentation_Layer.Tests
{
    public partial class ctrlTestInfo : UserControl
    {
        public ctrlTestInfo()
        {
            InitializeComponent();
        }

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
        public void LoadTestInfo(int TestAppID)
        {
            clsScheduleTest testApp = clsScheduleTest.Find(TestAppID);

            _HandleImage(testApp.TestTypeID);

            clsLDLApplication LDLApp = clsLDLApplication.Find(testApp.LDLAppID);
            lblDLAppID.Text = lblDLAppID.ToString();
            lblLicensClass.Text = clsLicenseClass.Find(LDLApp.LicenseClassID).ClassName;

            clsPerson applicant = clsPerson.Find(LDLApp.ApplicationInfo.ApplicantPersonID);
            lblName.Text = applicant.FirstName + " " + applicant.SecondName + " " + applicant.ThirdName + " " + applicant.LastName;

            lblTrial.Text = clsScheduleTest.GetAllTestAppointmentByLDLAppIDAndTestType(testApp.LDLAppID, testApp.TestTypeID).Rows.Count.ToString();

            clsTestType TestType = clsTestType.Find(testApp.TestTypeID);
            lblTestFees.Text = TestType.TestTypeFees.ToString();
            
            lblDate.Text = testApp.AppointmentDate.ToShortDateString();

            clsTest Test = clsTest.FindByTestAppointmentID(TestAppID);
            if (Test == null)
                lblTestID.Text = "Not Taken yet";
            else
                lblTestID.Text = Test.TestID.ToString();

        }
        private void ctrlTestInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
