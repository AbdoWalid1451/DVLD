using DVLD_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsLicense
    {

        public enum enIssueReason
        {FirstTime = 1, Renew = 2 , ReplaceForDamaged = 3 , ReplacementForLost = 4}

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }


        private clsLicense(int LicenseID, int ApplicationID, int DriverID
            , int LicenseClass, DateTime IssueDate, DateTime ExpirationDate
            , string Notes, decimal PaidFees, bool IsActive
             , Byte IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = (enIssueReason)IssueReason;
            this.CreatedByUserID = CreatedByUserID;

        }

        public clsLicense()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = -1;
            this.IsActive = false;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = CreatedByUserID;

        }

        static public clsLicense FindByID(int LicenseID)
        {
            int  ApplicationID = -1,
                 DriverID = -1,
                 LicenseClass = -1;
            DateTime IssueDate = DateTime.Now,
             ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = -1;
            bool IsActive = false;
            Byte IssueReason = 0;
             int CreatedByUserID = -1;


            if (clsLicenseData.find(LicenseID, ref ApplicationID, ref DriverID
                                , ref LicenseClass, ref IssueDate, ref ExpirationDate, ref Notes
                                , ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))

                return new clsLicense(LicenseID,  ApplicationID, DriverID
                                , LicenseClass, IssueDate,  ExpirationDate,  Notes
                                ,  PaidFees,  IsActive,IssueReason,  CreatedByUserID);
            else
                return null;
        }

   
        static public clsLicense findByAppID(int ApplicationID)
        {
            int  LicenseID = -1,
                 DriverID = -1,
                 LicenseClass = -1;
            DateTime IssueDate = DateTime.Now,
             ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = -1;
            bool IsActive = false;
            Byte IssueReason = 0;
             int CreatedByUserID = -1;


            if (clsLicenseData.findByAppID(ref LicenseID,  ApplicationID, ref DriverID
                                , ref LicenseClass, ref IssueDate, ref ExpirationDate, ref Notes
                                , ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))

                return new clsLicense(LicenseID,  ApplicationID, DriverID
                                , LicenseClass, IssueDate,  ExpirationDate,  Notes
                                ,  PaidFees,  IsActive,IssueReason,  CreatedByUserID);
            else
                return null;
        }

   

        private bool _AddNew()
        {

            this.LicenseID = clsLicenseData.addNew(ApplicationID, DriverID
                                , LicenseClass, IssueDate, ExpirationDate, Notes
                                , PaidFees, IsActive,(Byte) IssueReason, CreatedByUserID);

            return (this.LicenseID != -1);

        }



        public bool Save()
        {

            if (_AddNew())
            {
                return true;
            }

            return false;


        }

        static public bool Activation(int LicenseID,bool IsActive)
        {
            return clsLicenseData.Activation(LicenseID,IsActive);
        }

        static public bool IsPersonHaveLicense(int ApplicantPersonID, int LicenseClass)
        {
            return clsLicenseData.IsPersonHaveLicense(ApplicantPersonID, LicenseClass);
        }

        static public bool Delete(int LicenseID)
        {
            return clsLicenseData.Delete(LicenseID);
        }

        static public DataTable GetPersonLicenseHistory(int personID)
        {
            return clsLicenseData.GetPersonLicenseHistory(personID);
        }

    }
}
