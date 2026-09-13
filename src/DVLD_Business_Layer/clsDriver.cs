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
    public class clsDriver
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public clsPerson PersonInfo { get; set; }

        private clsDriver(int DriverID,  int PersonID,  int CreatedByUserID, DateTime CreatedDate , clsPerson person)
        {
          this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            PersonInfo = person;
        }

        public clsDriver()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;
            PersonInfo = null;
        }

        static public clsDriver Find(int DriverID)
        {

            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;


            if (clsDriverData.find(DriverID, ref PersonID, ref CreatedByUserID,ref CreatedDate))

                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate, clsPerson.Find(PersonID));
            else
                return null;
        }


        public bool AddNew()
        {

            this.DriverID = clsDriverData.addNew(PersonID, CreatedByUserID,CreatedDate);

            return (this.PersonID != -1);

        }

    
        static public bool Delete(int ID)
        {
            return clsDriver.Delete(ID);

        }

        static public bool IsPersonAlreadyExist( int PersonID)
        {
            return clsDriverData.IsAlreadyExist(PersonID);
        }

        static public DataTable GetAll()
        {
            return clsDriverData.getAll();
        }

    }
}
