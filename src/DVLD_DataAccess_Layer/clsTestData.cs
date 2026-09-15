using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess_Layer
{
    public class clsTestData
    {
        static public bool findbyID( int TestID, ref int TestAppointmentID, ref bool TestResult
            , ref string Notes, ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Select * from Tests" +
                " Where TestID = @TestID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TestID", TestID);

            bool flag = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];

                    if(reader["Notes"] == DBNull.Value)
                    Notes = "";
                    else
                        Notes = (string)reader["Notes"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];

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

        static public bool findbyTestAppointmentID(ref int TestID,  int TestAppointmentID, ref bool TestResult
            , ref string Notes, ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Select * from Tests Where TestAppointmentID = @TestAppointmentID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            bool flag = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    TestID = (int)reader["TestID"];
                    TestResult = (bool)reader["TestResult"];

                    if (reader["Notes"] == DBNull.Value)
                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];

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

        static public int addNew( int TestAppointmentID,  bool TestResult
            ,  string Notes,  int CreatedByUserID)
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Insert Into Tests " +
                "Values (@TestAppointmentID, @TestResult, @Notes,@CreatedByUserID)" +
                "Select Scope_Identity();";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@TestResult", TestResult);

            if(string.IsNullOrEmpty(Notes))
            cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@Notes", Notes);

            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            int ID = -1;

            try
            {
                connection.Open();

                Object CurrentID = cmd.ExecuteScalar();
                if (CurrentID != null)
                {
                    ID = Convert.ToInt32(CurrentID);

                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return ID;
        }


        static public int TestsPassedByLDLAppID(int LDLAppID)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "SELECT TestsPassed = Count(*)\r\nFROM     TestAppointments INNER JOIN\r\n                  Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID\r\n\t\t\t\t  Where TestResult =1\r\n\t\t\t\t  And LocalDrivingLicenseApplicationID = @LDLAppID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LDLAppID", LDLAppID);

            int testPassed = -1;
            try
            {
                connection.Open();

                object target;
                target = cmd.ExecuteScalar();

                if (target != null) 
                    testPassed = Convert.ToInt32(target);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return testPassed;
        }

        static public bool IsThatTestPassed(int LDLAppID , int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "SELECT found = 1 FROM     TestAppointments INNER JOIN    " +
                "              Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID   Where TestTypeID =@TestTypeID " +
                "  And LocalDrivingLicenseApplicationID = @LDLAppID And TestResult =1";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            bool flag = false;
            try
            {
                connection.Open();


                if (cmd.ExecuteScalar() != null)
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
