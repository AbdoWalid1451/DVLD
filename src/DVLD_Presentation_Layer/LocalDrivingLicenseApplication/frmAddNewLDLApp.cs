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

namespace DVLD_Presentation_Layer
{
    public partial class frmAddNewLDLApp : Form
    {
        clsLDLApplication LDLApplication;

        enum enMode { Add ,Update}
        enMode Mode;

        public frmAddNewLDLApp(int ID)
        {
            InitializeComponent();
            if(ID == -1)
            {
                Mode = enMode.Add;
                LDLApplication = new clsLDLApplication();
            }
            else
            {
                Mode = enMode.Update;
                LDLApplication = clsLDLApplication.Find(ID);
                ctrlPersonCardWithFilter1.LoadPersonInfo(LDLApplication.ApplicationInfo.ApplicantPersonID);
                ConvertToUpdateMode();

            }
        }

        private void ctrlPersonCardWithFilter1_PersonSelected(int obj)
        {
            if (ctrlPersonCardWithFilter1.SelectedPersonInfo != null)
            {
                btnSave.Enabled = true;
                btnNext.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
                btnNext.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }


        private void _LoadLicenseClassesInComboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClass();

            foreach (DataRow Row in dtLicenseClasses.Rows)
            {
                cbLicenseClasses.Items.Add(Row["ClassName"]);
            }
            
        }

        private void _InitializingAppInfo()
        {  
            cbLicenseClasses.SelectedIndex = 0;
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblAppFees.Text = clsApplicationType.Find("New Local Driving License Service").ApplicationFees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private void frmAddNewLDLApp_Load(object sender, EventArgs e)
        {
            _LoadLicenseClassesInComboBox();

            _InitializingAppInfo();


        }

        private int _CreateApplicationForLDLApp()
        {
            clsApplication application = new clsApplication();

            application.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID;
            application.AppDate = DateTime.Now;
            application.AppTypeID = clsApplicationType.Find("New Local Driving License Service").ApplicationTypeID;
            application.ApplicationStatus = clsApplication.enApplicationStatus.New;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = Decimal.Parse(lblAppFees.Text);
            application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if(application.Save())
                return application.ApplicationID;
            else
                return -1;

        }

        private void ConvertToUpdateMode()
        {
            Mode = enMode.Update;
            lblAddEditLDLApp.Text = "Update Local Driving License Application";
            lblLDLAppID.Text = LDLApplication.LDLAppID.ToString();
            ctrlPersonCardWithFilter1.Filter.Enabled = false;
            btnNext.Enabled = true;
            btnSave.Enabled = true;
        }

        private bool SystemInValidation()
        {   
            if (ctrlPersonCardWithFilter1.SelectedPersonInfo == null)
                {
                    MessageBox.Show("You should select a person first","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return true;
                }

            if (clsLDLApplication.IsAlreadyExist(ctrlPersonCardWithFilter1.PersonID,LDLApplication.LicenseClassID))
            {
                MessageBox.Show("You should select a person first", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            LDLApplication.LicenseClassID = clsLicenseClass.Find(cbLicenseClasses.Text).LicenseClassID;

            if(Mode == enMode.Add) {
             
                if(SystemInValidation())
                    return;

                LDLApplication.ApplicationID = _CreateApplicationForLDLApp();
                ConvertToUpdateMode();


            }

            if(LDLApplication.Save())
                MessageBox.Show("Application Saved Successfully","Successfully",MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to Save","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);


        }
    }
}
