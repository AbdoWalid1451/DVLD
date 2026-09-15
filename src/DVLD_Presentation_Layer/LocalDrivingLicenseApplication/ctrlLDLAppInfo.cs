using DVLD_Business_Layer;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.LocalDrivingLicenseApplication
{
    public partial class ctrlLDLAppInfo : UserControl
    {
        public ctrlLDLAppInfo()
        {
            InitializeComponent();
        }
        private int _DLAppID = -1;
        private clsLDLApplication _DlApp;

        public int DLAppID { get { return _DLAppID; } }
        public clsLDLApplication DLApp { get { return _DlApp; } }

      
        private void _FillApplicationCard(clsLDLApplication LDLApp)
        {
            if (LDLApp != null)
            {
                ctrlApplicationCard1.LoadApplicationInfo(LDLApp.ApplicationID);

                lblDLAppID.Text = LDLApp.LDLAppID.ToString();
                lblLicensClass.Text = clsLicenseClass.Find(LDLApp.LicenseClassID).ClassName.ToString();
                lblpassedTests.Text = clsTest.TestsPassedByLDLAppID(LDLApp.LDLAppID).ToString();

                ilblShowLicenseInfo.Visible = true;
            }
        }

        private void _ResetLDLAppCard()
        {
            ctrlApplicationCard1.LoadApplicationInfo(-1);

            lblDLAppID.Text = "???";
            lblLicensClass.Text = "???";
            lblpassedTests.Text = "??";
            ilblShowLicenseInfo.Visible = false;
            _DLAppID = -1;
            _DlApp = null;
        }

        public void LoadLDLAppInfo(int LDLAppID)
        {
            _DLAppID = LDLAppID;

            if (LDLAppID == -1)
            {
                _ResetLDLAppCard();
                MessageBox.Show("Application is not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DlApp = clsLDLApplication.Find(LDLAppID);

            if (DLApp != null)
            {
                _FillApplicationCard(_DlApp);

            }
            else
            {
                MessageBox.Show("Application is not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetLDLAppCard();
            }

        }

        private void ilblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void ctrlLDLAppInfo_Load(object sender, System.EventArgs e)
        {

        }
    }
}
