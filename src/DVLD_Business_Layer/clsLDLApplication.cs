using DVLD_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsLDLApplication
    {
        enum enMode { Add, Update }

        public int LDLAppID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public clsApplication ApplicationInfo {  get; set; }
        enMode Mode { get; set; }


        private clsLDLApplication(int LDLAppID,  int ApplicationID,  int LicenseClassID, clsApplication ApplicationInfo)
        {
            this.LDLAppID = LDLAppID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
            this.ApplicationInfo = ApplicationInfo;

            this.Mode = enMode.Update;
        }

        public clsLDLApplication()
        {
            this.LDLAppID = -1;
            this.ApplicationID = -1;
            this.LicenseClassID = -1;
            this.ApplicationInfo=null;

            this.Mode = enMode.Add;
        }

        static public clsLDLApplication Find(int LDLAppID)
        {
    
            int ApplicationID = -1;
            int LicenseClassID = -1;


            if (clsLDLAppData.find(LDLAppID, ref ApplicationID, ref LicenseClassID))

                return new clsLDLApplication(LDLAppID, ApplicationID, LicenseClassID,clsApplication.Find(ApplicationID));
            else
                return null;
        }


        private bool _AddNew()
        {

            this.LDLAppID = clsLDLAppData.addNew(ApplicationID, LicenseClassID);

            return (this.ApplicationID != -1);

        }

        private bool _Update()
        {
            return clsLDLAppData.Update(LDLAppID, ApplicationID, LicenseClassID);

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
            return clsLDLAppData.Delete(ID);

        }

        static public bool IsAlreadyExist(int ApplicantID ,int LicenseID)
        {
            return clsLDLAppData.IsAlreadyExist(ApplicantID, LicenseID);
        }

        static public DataTable GetAll()
        {
            return clsLDLAppData.getAll();
        }

    }
}
