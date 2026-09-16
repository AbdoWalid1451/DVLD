
using DVLD_Presentation_Layer.Applications;
using DVLD_Presentation_Layer.Detain_License;
using DVLD_Presentation_Layer.Drivers;
using DVLD_Presentation_Layer.lnternationalLicenseApplication;
using DVLD_Presentation_Layer.Users;
using System;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople frmPeople = new frmManagePeople();
            frmPeople.MdiParent = this;
            frmPeople.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frmUsers = new frmManageUsers();
            frmUsers.MdiParent = this;
            frmUsers.Show();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo info = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            info.ShowDialog();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            changePassword.ShowDialog();
        }

        private void signToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = new frmLogin();
            login.Show();
            login.FormClosed +=(s,args) => this.Close();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frm = new frmManageTestTypes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewLDLApp frm = new frmAddNewLDLApp(-1);
            frm.MdiParent = this;
            frm.Show();
        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLDLApp frm = new frmManageLDLApp();
            frm.MdiParent = this;
            frm.Show();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDrivers frm = new frmManageDrivers();
            frm.MdiParent = this;
            frm.Show();
        }

        private void internationLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddInternationLicenseApp frm = new frmAddInternationLicenseApp();
            frm.MdiParent = this;
            frm.Show();
        }

        private void internationalLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageInterLicenseApp frm = new frmManageInterLicenseApp();
            frm.MdiParent = this;
            frm.Show();
        }

        private void renewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicenseApplication frm = new frmRenewLicenseApplication();
            frm.MdiParent = this;
            frm.Show();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacemtOrLostLicense frm = new frmReplacemtOrLostLicense();
            frm.MdiParent = this;
            frm.Show();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses frm = new frmManageDetainedLicenses();
            frm.MdiParent = this;
            frm.Show();
        }

        private void detainLicensesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.MdiParent = this;
            frm.Show();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedlicense frm = new frmReleaseDetainedlicense();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
