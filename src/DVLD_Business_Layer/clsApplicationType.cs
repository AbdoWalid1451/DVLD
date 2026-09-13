using DVLD_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_Business_Layer
{
    public class clsApplicationType
    {
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public Decimal ApplicationFees { get; set; }

        private clsApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, Decimal ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationFees;
        }

        static public clsApplicationType Find(int ApplicationTypeID)
        {

            string ApplicationTypeTitle = ""; Decimal ApplicationFees = -1;


            if (clsApplicationTypesData.find(ref ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))

                return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle,ApplicationFees);
            else
                return null;
        }
        static public clsApplicationType Find(string ApplicationTypeTitle)
        {

            int ApplicationTypeID = -1; Decimal ApplicationFees = -1;


            if (clsApplicationTypesData.find(ref ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))

                return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle,ApplicationFees);
            else
                return null;
        }

        public bool Update()
        {
            return clsApplicationTypesData.Update(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);

        }

        static public DataTable GetAll()
        {
            return clsApplicationTypesData.getAll();
        }


    }
}
