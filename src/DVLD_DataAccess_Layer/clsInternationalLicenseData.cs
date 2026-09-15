using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess_Layer
{
    public class clsInternationalLicenseData
    {


        static public bool find(int InternationalLicenseID, ref int ApplicationID, ref int DriverID
                              , ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate
                              , ref DateTime ExpirationDate, ref bool IsActive
                              , ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Select * from InternationalLicenses Where InternationalLicenseID = @InternationalLicenseID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            bool flag = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
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
      
        static public int addNew(int ApplicationID, int DriverID
                              , int IssuedUsingLocalLicenseID, DateTime IssueDate
                              , DateTime ExpirationDate, bool IsActive
                              , int CreatedByUserID)
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Insert Into InternationalLicenses " +
                "Values (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate , @ExpirationDate ,@IsActive , @CreatedByUserID) " +
                "Select Scope_Identity();";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
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
            string query = $"SELECT InternationalLicenses.InternationalLicenseID, InternationalLicenses.ApplicationID ,LocalLicenseID = InternationalLicenses.IssuedUsingLocalLicenseID, InternationalLicenses.IssueDate, InternationalLicenses.ExpirationDate,                    InternationalLicenses.IsActive FROM     InternationalLicenses INNER JOIN               Applications ON InternationalLicenses.ApplicationID = Applications.ApplicationID INNER JOIN            People ON Applications.ApplicantPersonID = People.PersonID   where Applications.ApplicantPersonID =  @ApplicantPersonID";

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
        static public DataTable GetAll()
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = $"SELECT * from  InternationalLicenses ";

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


        static public bool Activation(int InternationalLicenseID, bool IsActive)
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = @"Update InternationalLicenses 
                              set IsActive = @IsActive
                              Where InternationalLicenseID = @InternationalLicenseID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
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

        static public bool IsPersonHaveLicense(int PersonID, bool IsActive)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "SELECT found = 1 FROM     InternationalLicenses INNER JOIN                   Applications ON InternationalLicenses.ApplicationID = Applications.ApplicationID INNER JOIN  People ON Applications.ApplicantPersonID = People.PersonID   Where Applications.ApplicantPersonID =@PersonID And IsActive = @IsActive";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);

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

        static public bool Delete(int InternationalLicenseID)
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = @"Delete From InternationalLicenses 
                              Where InternationalLicenseID = @InternationalLicenseID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);



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
