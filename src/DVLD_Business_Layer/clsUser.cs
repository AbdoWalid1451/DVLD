using DVLD_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsUser
    {
        enum enMode { Add, Update }
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        enMode Mode { get; set; }

        private clsUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.Mode = enMode.Update;
        }

        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            IsActive = false;

            Mode = enMode.Add;
        }

        static public clsUser Find(int UserID)
        {
            int PersonID = -1;

            string UserName = "", Password = "";

            bool IsActive = false; 


            if (clsUserData.findByID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))

                return new clsUser(UserID,  PersonID,  UserName,  Password,  IsActive);
            else
                return null;
        }

        static public clsUser Find(string Username , string Password)
        {
            int PersonID = -1;

            int UserID = -1;

            bool IsActive = false;


            if (clsUserData.findByUsername(  Username, Password,ref UserID, ref PersonID, ref IsActive))

                return new clsUser(UserID, PersonID, Username, Password, IsActive);
            else
                return null;
        }

        private bool _AddNew()
        {

            this.UserID = clsUserData.addNew(PersonID,UserName,Password,IsActive);

            return (this.UserID != -1);

        }

        private bool _Update()
        {
            return clsUserData.Update(UserID, PersonID, UserName, Password, IsActive);

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
            return clsUserData.Delete(ID);

        }

        static public DataTable GetAll()
        {
            return clsUserData.getAll();
        }


        static public bool IsExistingByUserID(int UserID)
        {
            return clsUserData.IsExistByUserID(UserID);
        }

        static public bool IsExistingByPersonID(int UserID)
        {
            return clsUserData.IsExistByPersonID(UserID);
        }



    }
}
