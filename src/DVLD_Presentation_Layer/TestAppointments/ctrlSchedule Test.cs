using DVLD_Business_Layer;
using System;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.TestAppointments
{
    public partial class ctrlSchedule_Test : UserControl
    {

        public ctrlSchedule_Test()
        {
            InitializeComponent();
        }

        public DateTime dtDate 
        { get { return dateTimePicker1.Value; } set { dtDate = dateTimePicker1.Value; }  }
        public void LoadTestInfo(int LDLAppID, int TestTypeID)
        {
            clsLDLApplication LDLApp = clsLDLApplication.Find(LDLAppID);
            lblDLAppID.Text = lblDLAppID.ToString();
            lblLicensClass.Text = clsLicenseClass.Find(LDLApp.LicenseClassID).ClassName;
            lblName.Text = clsPerson.Find(LDLApp.ApplicationInfo.ApplicantPersonID).ToString();
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
    }
}
