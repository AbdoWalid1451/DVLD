using DVLD_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsApplication
    {
        enum enMode { Add, Update }
        public enum enApplicationStatus {New = 1 , Canceled = 2 , Completed = 3  }


        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime AppDate { get; set; }
        public int AppTypeID { get; set; }
        public enApplicationStatus ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        enMode Mode { get; set; }


        private clsApplication(int ApplicationID ,int ApplicantPersonID, DateTime AppDate,
                                int AppTypeID , enApplicationStatus ApplicationStatus
                                , DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.AppDate = AppDate;
            this.AppTypeID = AppTypeID;
            this.ApplicationStatus =ApplicationStatus; 
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;


            this.Mode = enMode.Update;
        }

        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.AppDate = DateTime.Now;
            this.AppTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;


            this.Mode = enMode.Add;
        }

        static public clsApplication Find(int ApplicationID)
        {
           int ApplicantPersonID = -1;
           DateTime AppDate = DateTime.Now;
           int AppTypeID = -1;
            Byte ApplicationStatus = 1;
           DateTime LastStatusDate = DateTime.Now;
           decimal PaidFees = 0;
           int CreatedByUserID = -1;


            if (clsApplicationData.find( ApplicationID, ref  ApplicantPersonID, ref  AppDate
                                , ref  AppTypeID, ref  ApplicationStatus
                                , ref  LastStatusDate, ref  PaidFees, ref  CreatedByUserID))

                return new clsApplication(ApplicationID, ApplicantPersonID, 
                                        AppDate,  AppTypeID,(enApplicationStatus) ApplicationStatus
                                ,  LastStatusDate,  PaidFees,  CreatedByUserID);
            else
                return null;
        }


        private bool _AddNew()
        {

            this.ApplicationID = clsApplicationData.addNew( ApplicantPersonID, AppDate, AppTypeID,(Byte) ApplicationStatus
                                , LastStatusDate, PaidFees, CreatedByUserID);

            return (this.ApplicationID != -1);

        }

        private bool _Update()
        {
            return clsApplicationData.Update(ApplicationID, ApplicantPersonID, AppDate, AppTypeID, (Byte)ApplicationStatus
                                , LastStatusDate, PaidFees, CreatedByUserID);

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
            return clsApplicationData.Delete(ID);

        }
        static public bool ChangeStatus(int ID ,enApplicationStatus status)
        {
            return clsApplicationData.ChangeStatus(ID ,(int) status);

        }



    }
}
