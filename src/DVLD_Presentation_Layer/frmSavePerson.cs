using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Properties;
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
    public partial class frmSavePerson : Form
    {

        clsPerson person;
        string _ImagePath;
        enum enMode { Add, Edit }

        enMode Mode { get; set; }


        public frmSavePerson(int PersonID)
        {
            InitializeComponent();

            if (PersonID == -1)
            {
                Mode = enMode.Add;
                person = new clsPerson();
            }
            else
            {
                Mode = enMode.Edit;
                person = clsPerson.FindByID(PersonID);
                _FillForm();
            }
        }


        private void _FillForm()
        {
            lblAddEditPerson.Text = "Edit Contact";
            lblPersonID.Text = person.PersonID.ToString();
            txtFirstName.Text = person.FirstName.ToString();
            txtSecondName.Text = person.SecondName.ToString();
            txtThirdName.Text = person.ThirdName.ToString();
            txtLastName.Text = person.LastName.ToString();
            txtNationalNo.Text = person.NationalNo.ToString();
            if (person.Gendor == 1)
                rbFemal.Checked = true;
            else
                rbMale.Checked = true;

            txtEmail.Text = person.Email.ToString();
            txtAddress.Text = person.Address.ToString();
            dtpDateOfBirth.Text = person.DateOfBirth.ToString();
            txtPhone.Text = person.Phone.ToString();
            cbCountry.Text = clsCountry.FindCountry(person.NationalityCountryID).CountryName;

            _ImagePath = person.ImagePath;
            if (_ImagePath != null)
                pbPersonImage.Image = Image.FromFile(_ImagePath);
        }

        private void frmSavePerson_Load(object sender, EventArgs e)
        {
            rbMale.Checked = true;
            _LoadCountriesNameToComboBox();

        }

        private void _LoadCountriesNameToComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow Row in dtCountries.Rows)
            {
                cbCountry.Items.Add(Row["CountryName"]);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _UpdateFormToEdit()
        {
            lblAddEditPerson.Text = "Edit Person";
            Mode = enMode.Edit;
            lblPersonID.Text = person.PersonID.ToString();
        }

        
        private void _FillPersonFromForm()
        {
            person.NationalNo = txtNationalNo.Text;
            person.FirstName = txtFirstName.Text;
            person.SecondName = txtSecondName.Text;
            person.ThirdName = txtThirdName.Text;
            person.LastName = txtLastName.Text;
            person.DateOfBirth = dtpDateOfBirth.Value;
            if (rbMale.Checked)
                person.Gendor = 0;
            else
                person.Gendor = 1;
            person.Address = txtAddress.Text;
            person.Phone = txtPhone.Text;
            person.Email = txtEmail.Text;
            person.ImagePath = _ImagePath;
            person.NationalityCountryID = clsCountry.FindCountry(cbCountry.Text).ID;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            _FillPersonFromForm();
            if (person.Save())
            {
                MessageBox.Show("Person saved successfully");
                _UpdateFormToEdit();
            }
            else
                MessageBox.Show("Person failed to saved");


        }

        private void ilblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Set Image";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                _ImagePath = openFileDialog1.FileName;
                pbPersonImage.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void ChangePicture(object sender, EventArgs e)
        {
            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

        }
    }
}
