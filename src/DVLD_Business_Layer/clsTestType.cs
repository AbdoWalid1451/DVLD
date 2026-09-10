using DVLD_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsTestType
    {
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public Decimal TestTypeFees { get; set; }

        private clsTestType(int TestTypeID, string TestTypeTitle
            , string TestTypeDescription, Decimal TestFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestFees;
        }

        static public clsTestType Find(int TestTypeID)
        {

            string TestTypeTitle = "" ,  TestTypeDescription = ""; Decimal TestTypeFees = -1;


            if (clsTestTypeData.findByID(TestTypeID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))

                return new clsTestType(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            else
                return null;
        }

        public bool Update()
        {
            return clsTestTypeData.Update(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);

        }

        static public DataTable GetAll()
        {
            return clsTestTypeData.getAll();
        }


    }
}
