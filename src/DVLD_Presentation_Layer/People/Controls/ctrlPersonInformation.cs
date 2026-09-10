using DVLD_Business_Layer;
using System;
using System.Windows.Forms;
using DVLD_Presentation_Layer.Properties;

namespace DVLD_Presentation_Layer
{
    public partial class ctrlPersonInformation : UserControl
    {
        private int _PersonID = -1;
        private clsPerson _Person;

        public int PersonID { get { return _PersonID; }  }
        public clsPerson SelectedPersonInfo { get { return _Person; } }


        public ctrlPersonInformation()
        {
            InitializeComponent();
        }

        private void ShowImage(string ImagePath , short gendor)
        {
            if (ImagePath != null )
                pbPersonImage.ImageLocation=ImagePath;
            else
            {
                if (gendor == 0)
                    pbPersonImage.Image = Resources.Male_512;
                else
                    pbPersonImage.Image = Resources.Female_512;

            }
        }

        private void _FillPersonCard(clsPerson person)
        {
            if (person != null)
            {
                lblPersonID.Text = person.PersonID.ToString();

                lblName.Text = person.FirstName.ToString() + " " + person.SecondName.ToString() + " " + person.ThirdName.ToString() + " " + person.LastName.ToString();

                lblNationalNo.Text = person.NationalNo.ToString();


                if (person.Gendor == 0)
                    lblGendor.Text = "Male";
                else
                    lblGendor.Text = "Female";

                lblEmail.Text = person.Email;
                lblAddress.Text = person.Address;
                lblDateOfBirth.Text = person.DateOfBirth.ToShortDateString();
                lblPhone.Text = person.Phone;
                lblCountry.Text = clsCountry.FindCountry(person.NationalityCountryID).CountryName;

                ShowImage(person.ImagePath, person.Gendor);

                ilblEditPersonInfo.Visible = true;
            }
        }

        private void _ResetPersonCard()
        {
            lblPersonID.Text = "";

            lblName.Text = "???";

            lblNationalNo.Text = "???";

            lblGendor.Text = "???";

            lblEmail.Text = "???";
            lblAddress.Text = "???";
            lblDateOfBirth.Text = "???";
            lblPhone.Text = "???";
            lblCountry.Text = "???";

            ShowImage(null, 0);

            ilblEditPersonInfo.Visible = false;
            _PersonID = -1;
            _Person = null;
        } 

        public void LoadPersonInfo(int PersonID)
        {
            _PersonID =PersonID;

            if(PersonID == -1)
            {
                _ResetPersonCard();
                MessageBox.Show("Person is not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

             _Person = clsPerson.Find(PersonID);

            if(SelectedPersonInfo != null)
            {
            _FillPersonCard(_Person);
                
            }
            else
            {
                MessageBox.Show("Person is not found","Not Found",MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetPersonCard();
            }

        }

        public void LoadPersonInfo(string NationalNo)
        {
             _Person = clsPerson.Find(NationalNo);
            _PersonID = _Person.PersonID;
            if(SelectedPersonInfo != null)
            {
                _PersonID = PersonID;
            _FillPersonCard(_Person);

            }
            else
            {
                MessageBox.Show("Person is not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetPersonCard();
            }

        }

        private void ilblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSavePerson frm = new frmSavePerson(PersonID);
            frm.ShowDialog();
            LoadPersonInfo(_PersonID);


        }

        private void ctrlPersonInformation_Load(object sender, EventArgs e)
        {

        }
    }
}
