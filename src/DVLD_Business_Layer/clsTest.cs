using DVLD_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsTest
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsScheduleTest TestAppointment {  get; set; }


        private clsTest(int TestID, int TestAppointmentID, bool TestResult,
                                string Notes,  int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            TestAppointment = clsScheduleTest.Find(TestAppointmentID);

        }

        public clsTest()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -1;
            TestAppointment = new clsScheduleTest();

        }

        static public clsTest  FindByID(int TestID)
        {

            int TestAppointmentID = -1;
            bool TestResult = false;
            string Notes = "";
            int CreatedByUserID = -1;


            if (clsTestData.findbyID(TestID, ref TestAppointmentID, ref TestResult
                                , ref Notes, ref CreatedByUserID))

                return new clsTest(TestID,  TestAppointmentID,  TestResult
                                ,  Notes,  CreatedByUserID);
            else
                return null;
        }
        static public clsTest FindByTestAppointmentID(int TestAppointmentID)
        {

            int TestID  = -1;
            bool TestResult = false;
            string Notes = "";
            int CreatedByUserID = -1;


            if (clsTestData.findbyTestAppointmentID(ref TestID,  TestAppointmentID, ref TestResult
                                , ref Notes, ref CreatedByUserID))

                return new clsTest(TestID,  TestAppointmentID,  TestResult
                                ,  Notes,  CreatedByUserID);
            else
                return null;
        }


        private bool _AddNew()
        {

            this.TestID = clsTestData.addNew( TestAppointmentID, TestResult
                                , Notes, CreatedByUserID);

            return (this.TestID != -1);

        }

        static public bool IsThatTestPassed(int LDLAppID, int TestTypeID)
        {
            return clsTestData.IsThatTestPassed(LDLAppID, TestTypeID);
        }


        static public int TestsPassedByLDLAppID(int LDLAppID)
        {
            return clsTestData.TestsPassedByLDLAppID(LDLAppID);
        }

        public bool Save()
        {

            if (_AddNew())
            {
                clsScheduleTest.LockedTest(TestAppointmentID);
                return true;
            }
     
            return false;
   

        }

 
    }
}
