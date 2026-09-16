using DVLD_Business_Layer;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Applications
{
    public partial class ctrlApplicationCard : UserControl
    {
        private int _ApplicationID = -1;
        private clsApplication _Application;

        public int ApplicationID { get { return _ApplicationID; } }
        public clsApplication ApplicationInfo { get { return _Application; } }

        public ctrlApplicationCard()
        {
            InitializeComponent();
        }

        private void _FillApplicationCard(clsApplication application)
        {
            if (application != null)
            {
                lblApplicationID.Text = application.ApplicationID.ToString();

                lblStatus.Text = application.ApplicationStatus.ToString();

                lblFees.Text = application.PaidFees.ToString();

                lblType.Text = clsApplicationType.Find(application.AppTypeID).ApplicationTypeTitle.ToString();

                clsPerson applicant = clsPerson.Find(application.ApplicantPersonID);
                lblApplicant.Text = applicant.FirstName +" "+ applicant.SecondName + " " + applicant.ThirdName + " " + applicant.LastName;

                lblDate.Text = application.AppDate.ToShortDateString();
                lblStatusDate.Text = application.LastStatusDate.ToShortDateString();
                lblCreatedBy.Text = clsUser.Find(application.CreatedByUserID).UserName.ToString();

                ilblViewPersonInfo.Visible = true;
            }
        }

        private void _ResetApplicationCard()
        {
            lblApplicationID.Text = "???";

            lblStatus.Text = "???";

            lblFees.Text = "???";

            lblType.Text = "???";

            lblApplicant.Text = "???";

            lblDate.Text = "???";
            lblStatus.Text = "???";
            lblCreatedBy.Text = "???";

            ilblViewPersonInfo.Visible = false;
            _ApplicationID = -1;
            _Application = null;
        }

        public void LoadApplicationInfo(int ApplicationID)
        {
            _ApplicationID = ApplicationID;

            if (ApplicationID == -1)
            {
                _ResetApplicationCard();
                MessageBox.Show("Application is not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Application = clsApplication.Find(ApplicationID);

            if (ApplicationInfo != null)
            {
                _FillApplicationCard(_Application);

            }
            else
            {
                MessageBox.Show("Person is not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetApplicationCard();
            }

        }

        private void ilblViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
            frmPersonDetails frmPerson = new frmPersonDetails(ApplicationInfo.ApplicantPersonID);
            frmPerson.ShowDialog();
            _FillApplicationCard(ApplicationInfo);

        }

        private void ctrlApplicationCard_Load(object sender, System.EventArgs e)
        {

        }
    }
}
