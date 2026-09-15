using DVLD_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsScheduleTest
    {
        enum enMode { Add, Update }

        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LDLAppID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestAppID { get; set; }
        enMode Mode { get; set; }


        private clsScheduleTest(int TestAppointmentID,  int TestTypeID,  int LDLAppID
            ,  DateTime AppointmentDate,  decimal PaidFees,  int CreatedByUserID
                             ,  bool IsLocked,  int RetakeTestAppID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LDLAppID = LDLAppID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestAppID = RetakeTestAppID;


            this.Mode = enMode.Update;
        }

        public clsScheduleTest()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LDLAppID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestAppID = -1;


            this.Mode = enMode.Add;
        }

        static public clsScheduleTest Find(int TestAppointmentID)
        {
            
            int TestTypeID = -1;
            int LDLAppID = -1;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = -1;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestAppID = -1;


            if (clsScheduleTestData.find(TestAppointmentID, ref TestTypeID, ref LDLAppID
                                , ref AppointmentDate, ref PaidFees
                                , ref CreatedByUserID, ref IsLocked, ref RetakeTestAppID))

                return new clsScheduleTest(TestAppointmentID,  TestTypeID,  LDLAppID
                                ,    AppointmentDate,  PaidFees
                                , CreatedByUserID, IsLocked, RetakeTestAppID);
            else
                return null;
        }


        private bool _AddNew()
        {

            this.TestAppointmentID = clsScheduleTestData.addNew(TestTypeID, LDLAppID
                                , AppointmentDate, PaidFees
                                , CreatedByUserID, IsLocked, RetakeTestAppID);

            return (this.TestAppointmentID != -1);

        }

        private bool _Update()
        {
            return clsScheduleTestData.UpdateDateAppointment(TestAppointmentID, AppointmentDate);

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _Update();

                default: return false;

            }
        }

        static public bool Delete(int ID)
        {
            return clsScheduleTestData.Delete(ID);

        }

        static public DataTable GetAllTestAppointmentByLDLAppIDAndTestType(int LDLAppID, int TestTypeID)
        {
            return clsScheduleTestData.GetAllTestAppointmentByLDLAppIDAndTestType(LDLAppID, TestTypeID);
        }

        static public bool LockedTest(int TestAppointmentID)
        {
            return clsScheduleTestData.LockedTest(TestAppointmentID);
        }

        static public bool IsThereAppointment(int LDLAppID, int TestTypeID,bool IsLooked)
        {
            return clsScheduleTestData.IsThereAppointment(LDLAppID, TestTypeID, IsLooked);
        }


    }
}
