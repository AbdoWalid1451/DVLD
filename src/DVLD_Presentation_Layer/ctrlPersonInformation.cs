using DVLD_Business_Layer;
using System;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Presentation_Layer.Properties;

namespace DVLD_Presentation_Layer
{
    public partial class ctrlPersonInformation : UserControl
    {
        public int _ID;
        public ctrlPersonInformation(int ID)
        {
            _ID = ID;
            InitializeComponent();
        }

        private void ctrlPersonInformation_Load(object sender, EventArgs e)
        {
            _RefreshPersonInfo();
        }

        private void ShowImage(string ImagePath , short gendor)
        {
            if (ImagePath != null && File.Exists(ImagePath))
                pbPersonImage.Image = Image.FromFile(ImagePath);
            else
            {
                if (gendor == 0)
                    pbPersonImage.Image = Resources.Male_512;
                else
                    pbPersonImage.Image = Resources.Female_512;

            }
        }

        private void _RefreshPersonInfo()
        {
            clsPerson _person = clsPerson.FindByID(_ID);
            if (_person != null)
            {
              lblPersonID.Text = _person.PersonID.ToString();

              lblName.Text = _person.FirstName.ToString() + " " + _person.SecondName.ToString() + " " + _person.ThirdName.ToString() + " " +  _person.LastName.ToString();

              lblNationalNo.Text = _person.NationalNo.ToString();

              
              if (_person.Gendor == 0)
                  lblGendor.Text = "Male";
              else
                  lblGendor.Text = "Female";
              
              lblEmail.Text = _person.Email;
              lblAddress.Text = _person.Address;
              lblDateOfBirth.Text = _person.DateOfBirth.ToShortDateString();
              lblPhone.Text = _person.Phone;
              lblCountry.Text = _person.NationalityCountryID.ToString();

                ShowImage(_person.ImagePath, _person.Gendor);


            }

        }
        private void ilblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSavePerson frm = new frmSavePerson(_ID);
            frm.ShowDialog();
            _RefreshPersonInfo();


        }
    }
}
