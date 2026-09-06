using DVLD_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_Business_Layer
{
    public class clsPerson
    {
        enum enMode { Add, Update }
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }
        enMode Mode { get; set; }



        private clsPerson(int id,string NationalNo, string firstName, string secondName
            , string thirdName, string lastName,
            DateTime dateOFBirth, short gendor,  string address, string phone, string email
            ,int NationalityCountryID , string imagePath)
        {
            this.PersonID = id;
            this.NationalNo = NationalNo;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.DateOfBirth = dateOFBirth;
            this.Gendor = gendor;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = imagePath;
            this.Mode = enMode.Update;
        }

        public clsPerson()
        {
            PersonID = -1;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gendor = 0;
            Address = "";
            Phone = "";
            Email = "";
            NationalityCountryID = -1;
            ImagePath = "";


            Mode = enMode.Add;
        }

        static public clsPerson FindByID(int PersonID)
        {
            string NationalNo = "",
                FName = "", SName = "", TName = "", LName = "", Email = "", Phone = "", Address = "";
            DateTime DateOfBirth = DateTime.Now; int NationalityCountryID = -1; string ImagePath = "";
            short Gendor = 0;


            if (clsPeopleData.findByID( PersonID,ref NationalNo, ref  FName, ref  SName
                , ref  TName, ref  LName,  ref  DateOfBirth,
                ref  Gendor, ref  Address
                ,  ref  Phone,ref  Email, ref  NationalityCountryID
               , ref  ImagePath))

                return new clsPerson(PersonID,  NationalNo,  FName,  SName
                , TName,  LName,  DateOfBirth, Gendor,  Address , 
                Phone,  Email,  NationalityCountryID
               ,  ImagePath);
            else
                return null;
        }

        private bool _AddNew()
        {
            this.PersonID = clsPeopleData.addNew(NationalNo, FirstName, SecondName
                , ThirdName, LastName, DateOfBirth, Gendor, Address,
                Phone, Email, NationalityCountryID
               , ImagePath);

            return (this.PersonID != -1);

        }

        private bool _Update()
        {
            return clsPeopleData.Update(PersonID, NationalNo, FirstName, SecondName
                , ThirdName, LastName, DateOfBirth, Gendor, Address,
                Phone, Email, NationalityCountryID
               , ImagePath);
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
            return clsPeopleData.Delete(ID);
        }

        static public DataTable GetAll()
        {
            return clsPeopleData.getAll();
        }

        static public bool IsExisting(int ID)
        {
            return clsPeopleData.IsExist(ID);
        }


    }

}

