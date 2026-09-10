using DVLD_Business_Layer;
using DVLD_Presentation_Layer.People.Controls;
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
    public partial class frmChangePassword : Form
    {
        clsUser User ;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            ctrlUserInfo1.LoadUserInfo(UserID);
            User = ctrlUserInfo1.SelectedUserInfo;
        }

        private bool InValidation()
        {
            if (User == null)
            {
                MessageBox.Show("There is no User ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return true;
            }

            else if (string.IsNullOrEmpty(txtCurrentPassword.Text) || string.IsNullOrEmpty(txtNewPassword.Text) || string.IsNullOrEmpty(txtNewPassword.Text))
            {
                MessageBox.Show("You Should Fill All Data ", "Empty Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            else if (txtNewPassword.Text != txtConfirmNewPass.Text)
            {
                MessageBox.Show("InCorrect Confirm password ", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return true;
            }
            else
                return false;
        }

        private void ChangePassword()
        {
            User.Password = txtNewPassword.Text;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (InValidation()) 
                return;


            ChangePassword();
            
            if(User.Save())
            {
                MessageBox.Show("Password changed Successfully ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Failed to change ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
