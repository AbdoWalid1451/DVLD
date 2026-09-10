using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess_Layer
{
    public class clsTestTypeData
    {
        static public DataTable getAll()
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = $"Select ID = TestTypeID , Title =TestTypeTitle, Description =TestTypeDescription , Fees = TestTypeFees from TestTypes";

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

        static public bool findByID(int TestTypeID, ref string TestTypeTitle
            , ref string TestTypeDescription, ref Decimal TestFees)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Select * from TestTypes Where TestTypeID = @TestTypeID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            bool flag = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestTypeDescription = (string)reader["TestTypeDescription"];
                    TestFees = (Decimal)reader["TestTypeFees"];

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


        static public bool Update(int TestTypeID, string TestTypeTitle
            , string TestTypeDescription, Decimal TestTypeFees)
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = @"Update TestTypes 
                              set  
                                TestTypeTitle = @TestTypeTitle,
                                TestTypeDescription = @TestTypeDescription,
                                TestTypeFees = @TestTypeFees
                              Where TestTypeID = @TestTypeID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            cmd.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            cmd.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

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
