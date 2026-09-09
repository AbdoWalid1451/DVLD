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
    public partial class frmPersonDetails : Form
    {

     
        public frmPersonDetails(int ID)
        {
            InitializeComponent(); 
          ctrlPersonInformation1.LoadPersonInfo(ID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
