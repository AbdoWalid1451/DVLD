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
        private int _ID;
     
        public frmPersonDetails(int ID)
        {
            _ID = ID;
            InitializeComponent(); 
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
