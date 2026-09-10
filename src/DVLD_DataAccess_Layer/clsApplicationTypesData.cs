using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess_Layer
{
    public class clsApplicationTypesData
    {
        static public DataTable getAll()
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = $"Select ID = ApplicationTypeID , Title = ApplicationTypeTitle , Fees = ApplicationFees from ApplicationTypes";

            SqlCommand cmd = new SqlCommand(query, connection);

            DataTable dt = new DataTable();

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        static public bool findByID(int ApplicationTypeID, ref string ApplicationTypeTitle, ref Decimal ApplicationFees)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Select * from ApplicationTypes Where ApplicationTypeID = @ApplicationTypeID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            bool flag = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees = (Decimal)reader["ApplicationFees"];

                    flag = true;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return flag;
        }


        static public bool Update(int ApplicationTypeID, string ApplicationTypeTitle, Decimal ApplicationFees)
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = @"Update ApplicationTypes 
                              set  
                                ApplicationTypeTitle = @ApplicationTypeTitle,
                                ApplicationFees = @ApplicationFees
                              Where ApplicationTypeID = @ApplicationTypeID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            cmd.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

            bool flag = false;
            try
            {
                connection.Open();

                if (cmd.ExecuteNonQuery() > 0)
                    flag = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return flag;
        }

    }
}
