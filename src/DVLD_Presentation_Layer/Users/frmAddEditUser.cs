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


namespace DVLD_Presentation_Layer.Users
{
    public partial class frmAddEditUser : Form
    {
        clsUser User;
        enum enMode { Add, Edit }

        enMode Mode { get; set; }

        public frmAddEditUser(int UserID)
        {
            InitializeComponent();

            if (UserID == -1)
            {
                Mode = enMode.Add;
                User = new clsUser();
            }
            else
            {
                Mode = enMode.Edit;
                User = clsUser.Find(UserID);
                if (User == null)
                {
                    MessageBox.Show("This UserID not found ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                _FillForm();
            }
        }
        private void _FillForm()
        {
            lblAddEditUser.Text = "Edit User";
            ctrlPersonCardWithFilter1.LoadPersonInfo(User.PersonID);
            txtUserName.Text = User.UserName;
            txtPassword.Text = User.Password;
            cbIsActive.Checked = User.IsActive;
            lblUserID.Text = User.UserID.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tpLoginInfo;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidationUserData()
        {

            if (ctrlPersonCardWithFilter1.PersonID == -1 || ctrlPersonCardWithFilter1.SelectedPersonInfo == null)
            {
                MessageBox.Show("You Should Fill All Data ", "Empty Data", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return true;
            }
           else if(Mode == enMode.Add && clsUser.IsExistingByPersonID(ctrlPersonCardWithFilter1.PersonID))
            {
                MessageBox.Show("This Person already Existing", "InValid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            else if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text) ||     string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                MessageBox.Show("You Should Fill All Data ","Empty Data",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("InCorrect Confirm password ", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return true;
            }
            else
                return false;
        }

        private void _FillUserFromForm()
        {
            User.UserName = txtUserName.Text;
            User.Password = txtPassword.Text;
            User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            User.IsActive = cbIsActive.Checked;
        }

        private void _UpdateFormToEdit()
        {
            lblAddEditUser.Text = "Edit User";
            Mode = enMode.Edit;
            lblUserID.Text = User.UserID.ToString();
        }

        public delegate void dlgDataBack(int ID);

        public event dlgDataBack DataBack;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidationUserData())
                return;
          

            _FillUserFromForm();

            if (User.Save())
            {
                MessageBox.Show("User saved successfully");
                _UpdateFormToEdit();
                DataBack?.Invoke(User.UserID);
            }
            else
                MessageBox.Show("User failed to saved");

        }

        private void _ReturnFormToAddMode()
        {
            Mode = enMode.Add;
            User = new clsUser();
            lblAddEditUser.Text = "Add New User";
            txtUserName.Text = "";
            txtPassword.Text = "";
            cbIsActive.Checked = false;
            lblUserID.Text = "???";
        }
        private void ctrlPersonCardWithFilter1_PersonSelected(int obj)
        {
            _ReturnFormToAddMode();

        }


        private void EmptyBoxValidatling(object sender, CancelEventArgs e)
        { 
            TextBox txt = sender as TextBox;

            if (string.IsNullOrEmpty(txt.Text))
            {
                error.SetError(txt, "it shouldn't be empty");
            }
            else
            {
                error.SetError(txt, "");
            }


        }
    }
}
