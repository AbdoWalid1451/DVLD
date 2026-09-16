
using System;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsGlobal global = new clsGlobal();
            if(global.Login(txtUserName.Text,txtPassword.Text))
            {
                frmMain main = new frmMain();
                main.Show();
                this.Hide();
                main.FormClosed += (s, args) => this.Close();

            }
            else
                MessageBox.Show("Wrong username or password","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
