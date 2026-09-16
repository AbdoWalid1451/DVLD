using DVLD_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsInternationalLicense
    {
    
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }


        private clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID
            , int IssuedUsingLocalLicenseID, DateTime IssueDate
            , DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

        }

        public clsInternationalLicense()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = false;
            this.CreatedByUserID = CreatedByUserID;

        }

        static public clsInternationalLicense FindByID(int InternationalLicenseID)
        {
            int ApplicationID = -1,
                 DriverID = -1,
                 IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now,
             ExpirationDate = DateTime.Now;
            bool IsActive = false;
            int CreatedByUserID = -1;


            if (clsInternationalLicenseData.find(InternationalLicenseID, ref ApplicationID, ref DriverID
                                , ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate
                                , ref IsActive, ref CreatedByUserID))

                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID
                                , IssuedUsingLocalLicenseID, IssueDate,
                                ExpirationDate, IsActive, CreatedByUserID);
            else
                return null;
        }

        private bool _AddNew()
        {

            this.InternationalLicenseID = clsInternationalLicenseData.addNew(ApplicationID, DriverID
                                , IssuedUsingLocalLicenseID, IssueDate
                                , ExpirationDate, IsActive ,CreatedByUserID);

            return (this.InternationalLicenseID != -1);

        }

        public bool Save()
        {

            if (_AddNew())
            {
                return true;
            }

            return false;


        }

        static public bool Activation(int LicenseID, bool IsActive)
        {
            return clsInternationalLicenseData.Activation(LicenseID, IsActive);
        }

        static public bool IsPersonHaveLicense(int ApplicantPersonID, bool IsActive)
        {
            return clsInternationalLicenseData.IsPersonHaveLicense(ApplicantPersonID, IsActive);
        }

        static public bool Delete(int LicenseID)
        {
            return clsInternationalLicenseData.Delete(LicenseID);
        }

        static public DataTable GetPersonLicenseHistory(int personID)
        {
            return clsInternationalLicenseData.GetPersonLicenseHistory(personID);
        }

        static public DataTable GetAll()
        {
            return clsInternationalLicenseData.GetAll();
        }

    }
}
