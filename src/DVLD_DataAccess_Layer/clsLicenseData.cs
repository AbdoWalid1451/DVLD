using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess_Layer
{
    public class clsLicenseData
    {

        static public bool find(int LicenseID, ref int ApplicationID, ref int DriverID
                              , ref int LicenseClass, ref DateTime IssueDate
                              , ref DateTime ExpirationDate,ref string Notes
                              , ref decimal PaidFees, ref bool IsActive
                              , ref Byte IssueReason, ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Select * from Licenses Where LicenseID = @LicenseID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            bool flag = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];

                    if (reader["Notes"] != DBNull.Value)
                        Notes = (string)reader["Notes"];
                    else
                        Notes = "";

                    PaidFees = (decimal)reader["PaidFees"];
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (Byte)reader["IssueReason"];
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
        static public bool findByAppID(ref int LicenseID,  int ApplicationID, ref int DriverID
                              , ref int LicenseClass, ref DateTime IssueDate
                              , ref DateTime ExpirationDate,ref string Notes
                              , ref decimal PaidFees, ref bool IsActive
                              , ref Byte IssueReason, ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Select * from Licenses Where ApplicationID = @ApplicationID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            bool flag = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    LicenseID = (int)reader["LicenseID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];

                    if (reader["Notes"] != DBNull.Value)
                        Notes = (string)reader["Notes"];
                    else
                        Notes = "";

                    PaidFees = (decimal)reader["PaidFees"];
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (Byte)reader["IssueReason"];
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


        static public int addNew( int ApplicationID,  int DriverID
                              , int LicenseClass,  DateTime IssueDate
                              ,  DateTime ExpirationDate,  string Notes
                              ,  decimal PaidFees,  bool IsActive
                              , Byte IssueReason,  int CreatedByUserID)
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Insert Into Licenses " +
                "Values (@ApplicationID, @DriverID, @LicenseClass, @IssueDate , @ExpirationDate, @Notes ,@PaidFees ,@IsActive ,@IssueReason , @CreatedByUserID) " +
                "Select Scope_Identity();";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            
            if(string.IsNullOrEmpty(Notes))
            cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@Notes", Notes);

            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
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


        static public DataTable GetPersonLicenseHistory(int ApplicantPersonID)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = $"SELECT Licenses.LicenseID, Licenses.ApplicationID, LicenseClasses.ClassName, Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive " +
                $"FROM     Licenses INNER JOIN     " +
                $"           Applications ON Licenses.ApplicationID = Applications.ApplicationID" +
                $" INNER JOIN     " +
                $"             LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID" +
                $" Where ApplicantPersonID =@ApplicantPersonID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);

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



        static public bool Activation(int LicenseID,bool IsActive)
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = @"Update Licenses 
                              set IsActive = @IsActive
                              Where LicenseID = @LicenseID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);



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

        static public bool IsPersonHaveLicense(int ApplicantPersonID , int LicenseClass)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "SELECT found =1 FROM     Licenses INNER JOIN         " +
                "          Applications ON Licenses.ApplicationID = Applications.ApplicationID" +
                "   where Applications.ApplicantPersonID =@ApplicantPersonID  And Licenses.LicenseClass = @LicenseClass";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            cmd.Parameters.AddWithValue("@LicenseClass", LicenseClass);

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

        static public bool Delete(int LicenseID)
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = @"Delete From Licenses 
                              Where LicenseID = @LicenseID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);



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
