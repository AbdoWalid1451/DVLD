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
    public partial class frmUpdateApplicationType : Form
    {
        clsApplicationType ApplicationType;
        public frmUpdateApplicationType(int ID)
        {
            InitializeComponent();
            ApplicationType = clsApplicationType.Find(ID);
        }

        private void _FillForm()
        {

            lblApplicationID.Text = ApplicationType.ApplicationTypeID.ToString();
            txtTitle.Text = ApplicationType.ApplicationTypeTitle.ToString();
            txtFees.Text = ApplicationType.ApplicationFees.ToString();
            
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            if(ApplicationType == null)
            {
                MessageBox.Show("Couldn't Find Application Type","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
                return;
            }
            _FillForm();
        }

        private void UpdateAppTypeFromForm()
        {
            ApplicationType.ApplicationTypeTitle = txtTitle.Text;
            ApplicationType.ApplicationFees = Decimal.Parse(txtFees.Text);
        }

        private bool InValidation()
        {
            if(string.IsNullOrEmpty(txtFees.Text) || string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("You should fill the Empty Fields", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            
            
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (InValidation())
                return;

            UpdateAppTypeFromForm();

            if (ApplicationType.Update())
                MessageBox.Show("Application Type Updated Successfully","Success");
            else
                MessageBox.Show("Failed to Update", "Fail");
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

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
         
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
        }

    }
}
