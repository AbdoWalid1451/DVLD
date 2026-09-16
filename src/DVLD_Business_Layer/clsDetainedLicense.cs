using System;
using DVLD_DataAccess_Layer;
using System.Data;

namespace DVLD_Business_Layer
{
    public class clsDetainedLicense
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }

        private clsDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate
          , decimal FineFees, int CreatedByUserID, bool IsReleased
          , DateTime? ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID; 
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;

        }

        public clsDetainedLicense()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.Now;
            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1; ;

        }

        private bool _AddNew()
        {

            this.DetainID = clsDetainedLicenseData.addNew(LicenseID, DetainDate
                                , FineFees, CreatedByUserID
                                , IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);

            return (this.DetainID != -1);

        }

        public bool Save()
        {

            if (_AddNew())
            {
                return true;
            }

            return false;


        }

        static public bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicenseData.IsLicenseDetained(LicenseID);
        }

        static public clsDetainedLicense findDetainedLicenseByLicenseID(int LicenseID)
        {
            int DetainID = -1, CreatedByUserID = -1, ReleasedByUserID = -1, ReleaseApplicationID = -1;

            DateTime DetainDate = DateTime.Now; DateTime? ReleaseDate = DateTime.Now;
            
            decimal FineFees = 0;
           
            bool IsReleased = false;

            if (clsDetainedLicenseData.findDetainedLicense(ref DetainID, ref LicenseID, ref DetainDate
                                , ref FineFees, ref CreatedByUserID, ref IsReleased
                                , ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))

                return new clsDetainedLicense( DetainID,  LicenseID,  DetainDate
                                ,  FineFees,  CreatedByUserID,  IsReleased
                                ,  ReleaseDate,  ReleasedByUserID,  ReleaseApplicationID);
            else
                return null;



        }

         public bool Release()
        {
            return clsDetainedLicenseData.Release(DetainID,LicenseID,IsReleased,ReleaseDate,ReleasedByUserID,ReleaseApplicationID);
        }
       
        public static DataTable  GetAll()
        {
            return clsDetainedLicenseData.getAll();
        }

    }
}
