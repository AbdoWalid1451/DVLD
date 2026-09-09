using DVLD_Business_Layer;
using DVLD_Presentation_Layer.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace DVLD_Presentation_Layer
{
    public partial class frmSavePerson : Form
    {

        clsPerson person;
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
                person = clsPerson.Find(PersonID);
                if (person == null)
                {
                    MessageBox.Show("This personID not found ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
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

            if (!string.IsNullOrEmpty( person.ImagePath))
                pbPersonImage.ImageLocation = person.ImagePath;
        }

        private void _UpdateAllowableAge()
        {
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
        }

        private void frmSavePerson_Load(object sender, EventArgs e)
        {
            _LoadCountriesNameToComboBox();
            cbCountry.SelectedIndex = 89;//Jordan
            _UpdateAllowableAge();
            if(string.IsNullOrEmpty(person.ImagePath))
            ilblRemaveImage.Visible = false;

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

        private bool ValidationData()
        {
            return string.IsNullOrEmpty(txtNationalNo.Text) && string.IsNullOrEmpty(txtFirstName.Text)
                 && string.IsNullOrEmpty(txtSecondName.Text)
                  && string.IsNullOrEmpty(txtLastName.Text) && string.IsNullOrEmpty(txtAddress.Text)
                   && string.IsNullOrEmpty(txtPhone.Text);
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
            person.ImagePath = pbPersonImage.ImageLocation;
            person.NationalityCountryID = clsCountry.FindCountry(cbCountry.Text).ID;

        }

        private void _HandleImage()
        {
            if (pbPersonImage.ImageLocation == person.ImagePath)
                return;

            if(string.IsNullOrEmpty(pbPersonImage.ImageLocation))
            {
                if (!string.IsNullOrEmpty(person.ImagePath))
                {
                     File.Delete(person.ImagePath);

                }
            }
            else
            {
                if (!string.IsNullOrEmpty(person.ImagePath))
                {
                   File.Delete(person.ImagePath);
                 
                }   
                string source = pbPersonImage.ImageLocation;
                clsUtil.CopyPhotoToPhotosPlace(ref source);
                pbPersonImage.ImageLocation = source;
            }

        }

        public delegate void dlgDataBack(int ID);

        public event dlgDataBack DataBack;


        private void btnSave_Click(object sender, EventArgs e)
        {
            if(ValidationData())
            {
                MessageBox.Show("You should fill all data in thier boxes ","Info",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _HandleImage();

            _FillPersonFromForm();

            if (person.Save())
            {
                MessageBox.Show("Person saved successfully");
                _UpdateFormToEdit();
                DataBack?.Invoke(person.PersonID);
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

                pbPersonImage.ImageLocation = openFileDialog1.FileName;

                ilblRemaveImage.Visible = true;
            }

        }

        private void ChangeDefaultPicture(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
            {
                if (rbMale.Checked)
                    pbPersonImage.Image = Resources.Male_512;
                else
                    pbPersonImage.Image = Resources.Female_512;

                ilblRemaveImage.Visible = false;
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (clsPerson.IsExisting(txtNationalNo.Text))
            {
                e.Cancel = true;
                txtNationalNo.Focus();
                error.SetError(txtNationalNo, "National Number is Used For Another person");
            }
            else
            {
                e.Cancel = false;
                error.SetError(txtNationalNo, "");
            }
           

        }
        
        private void EmptyBoxValidatling(object sender, EventArgs e)
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

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!(txtEmail.Text.Contains("@gmail.com")))

                error.SetError(txtEmail, "it not true format");

            else
                error.SetError(txtEmail, "");

        }

        private void ilblRemaveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ilblRemaveImage.Visible = false;
            pbPersonImage.ImageLocation = null;
            ChangeDefaultPicture( sender,  e);
        }
    }
}
