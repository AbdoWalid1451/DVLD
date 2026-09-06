using DVLD_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_Business_Layer
{
    public class clsCountry
    {
        public int ID { get; set; }
        public string CountryName { get; set; }

        private clsCountry(int id, string countryName)
        {
            ID = id;
            CountryName = countryName;
          
        }

        public clsCountry()
        {
            ID = -1;
            CountryName = "";
            
        }

        static public clsCountry FindCountry(int ID )
        {
            string CountryName = "";
            if(clsCountryData.Find(ref ID,ref CountryName))
                    return new clsCountry(ID,CountryName);
            else
                return null;

        }
        static public clsCountry FindCountry(string CountryName )
        {
            int ID = -1;
            if(clsCountryData.Find(ref ID,ref CountryName))
                    return new clsCountry(ID,CountryName);
            else
                return null;

        }

        static public DataTable GetAllCountries()
        {
            return clsCountryData.getAll();
        }

    }
}
