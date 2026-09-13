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
    public partial class frmUpdateTestType : Form
    {
        clsTestType TestType;
        public frmUpdateTestType(int ID)
        {
            InitializeComponent();
            TestType =clsTestType.Find(ID);
        }

        private void _FillForm()
        {

            lblApplicationID.Text = TestType.TestTypeID.ToString();
            txtTitle.Text = TestType.TestTypeTitle.ToString();
            txtDescription.Text = TestType.TestTypeDescription.ToString();
            txtFees.Text = TestType.TestTypeFees.ToString();

        }
        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {   
            if (TestType == null)
            {
                MessageBox.Show("Couldn't Find Test Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            _FillForm();

        }

        private void UpdateTestTypeFromForm()
        {
            TestType.TestTypeTitle = txtTitle.Text;
            TestType.TestTypeDescription = txtDescription.Text;
            TestType.TestTypeFees = Decimal.Parse(txtFees.Text);
        }

        private bool InValidation()
        {
            if (string.IsNullOrEmpty(txtFees.Text) || string.IsNullOrEmpty(txtTitle.Text)
                || string.IsNullOrEmpty(txtDescription.Text))
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

            UpdateTestTypeFromForm();

            if (TestType.Update())
                MessageBox.Show("Test Type Updated Successfully", "Success");
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
