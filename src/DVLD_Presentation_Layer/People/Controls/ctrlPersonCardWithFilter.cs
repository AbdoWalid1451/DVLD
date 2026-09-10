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

namespace DVLD_Presentation_Layer.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public int PersonID { get { return ctrlPersonInformation1.PersonID; } }
        public clsPerson SelectedPersonInfo { get { return ctrlPersonInformation1.SelectedPersonInfo; } }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
            cbFilter.SelectedIndex = 0;
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
         
        }
        public void LoadPersonInfo(int  personID)
        {
            cbFilter.SelectedIndex = 1;
            txtSearch.Text = personID.ToString();
            FindNow();
        }
        private void FindNow()
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
                switch (cbFilter.Text)
                {
                    case "Person ID":
                        ctrlPersonInformation1.LoadPersonInfo(int.Parse(txtSearch.Text));
                        break;
                    case "National No":
                        ctrlPersonInformation1.LoadPersonInfo(txtSearch.Text);
                        break;
                }
            else
                ctrlPersonInformation1.LoadPersonInfo(-1);
        }
  
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Please Enter data to search","Empty search",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            FindNow();
            OnPersonSelected(PersonID);
        }
        private void TakeDataBack(int PersonID)
        {
            LoadPersonInfo(PersonID);
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmSavePerson frmSave = new frmSavePerson(-1);
            frmSave.DataBack += TakeDataBack;
            frmSave.ShowDialog();

                OnPersonSelected(PersonID);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Person ID" )
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
        }

        public event Action<int> PersonSelected;
        protected virtual void OnPersonSelected(int obj)
        {
            Action<int> handler = PersonSelected;
            if (handler != null)
                handler(obj);

        }

    }
}
