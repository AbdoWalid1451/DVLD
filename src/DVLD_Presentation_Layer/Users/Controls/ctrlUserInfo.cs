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
    public partial class ctrlUserInfo : UserControl
    {
        public ctrlUserInfo()
        {
            InitializeComponent();
        }

        private int _UserID = -1;
        private clsUser _User;

        public int UserID { get { return _UserID; } }
        public clsUser SelectedUserInfo { get { return _User; } }

        private void _FillUserCard(clsUser User)
        {
            if (User != null)
            {
                ctrlPersonInformation1.LoadPersonInfo(User.PersonID);
                lblUserID.Text = User.UserID.ToString();
                lblUsername.Text = User.UserName.ToString();
                if (User.IsActive)
                    lblIsActive.Text = "Yes";
                else lblIsActive.Text = "No";
            }
        }

        private void _ResetPersonCard()
        {
            ctrlPersonInformation1.LoadPersonInfo(-1);
            lblUserID.Text = "???";
            lblUsername.Text = "???";
            lblIsActive.Text = "???";
        }

        public void LoadUserInfo(int UserID)
        {
            _UserID = UserID;

            if (UserID == -1)
            {
                _ResetPersonCard();
                MessageBox.Show("User is not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User = clsUser.Find(UserID);

            if (SelectedUserInfo != null)
            {
                _FillUserCard(_User);

            }
            else
            {
                MessageBox.Show("User is not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetPersonCard();
            }

        }

    }
}
