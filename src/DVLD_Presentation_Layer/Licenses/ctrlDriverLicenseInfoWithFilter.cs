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

namespace DVLD_Presentation_Layer.Licenses
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public clsLicense license { get { return _license; } }

        private clsLicense _license;

        public GroupBox Filter { get { return gbFilter; } set { gbFilter = Filter; } }

        public void Search(int licenseID)
        {
            txtLicenseID.Text = licenseID.ToString();
            Add();
        }

        private void ctrlDriverLicenseInfoWithFilter_Load(object sender, EventArgs e)
        {

        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
    
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
        }

        private void Add()
        {
            if(string.IsNullOrEmpty(txtLicenseID.Text))
            {
                MessageBox.Show("Enter License ID first","InValid",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlLicenseInfo1.LoadLicenseInfoByLicenseID(int.Parse(txtLicenseID.Text));
            _license = ctrlLicenseInfo1.license;
            if (_license != null)
            {
                if (OnLicenseSelected != null)
                    LicenseSelected(_license.LicenseID);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();

        }

        public event Action<int> OnLicenseSelected;
        protected virtual void LicenseSelected(int obj)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
                handler(obj);

        }

    }
}
