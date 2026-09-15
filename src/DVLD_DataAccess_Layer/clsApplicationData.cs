using System;
using System.Data.SqlClient;


namespace DVLD_DataAccess_Layer
{
    public class clsApplicationData
    {
        static public bool find(int ApplicationID,ref int ApplicantPersonID, ref DateTime AppDate
                                , ref int AppTypeID, ref Byte ApplicationStatus
                                , ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Select * from Applications Where ApplicationID = @ApplicationID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            bool flag = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    AppDate = (DateTime)reader["ApplicationDate"];
                    AppTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (Byte)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = (decimal)reader["PaidFees"];
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

  
        static public int addNew(int ApplicantPersonID , DateTime AppDate , int AppTypeID, Byte ApplicationStatus 
                                ,DateTime LastStatusDate ,decimal PaidFees , int CreatedByUserID)
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Insert Into Applications " +
                "Values (@ApplicantPersonID, @AppDate, @AppTypeID, @ApplicationStatus , @LastStatusDate, @PaidFees , @CreatedByUserID) " +
                "Select Scope_Identity();";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            cmd.Parameters.AddWithValue("@AppDate", AppDate);
            cmd.Parameters.AddWithValue("@AppTypeID", AppTypeID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
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

        static public bool Update(int ApplicationID, int ApplicantPersonID, DateTime AppDate
                                , int AppTypeID, Byte ApplicationStatus
                                , DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = @"Update Applications 
                              set ApplicantPersonID = @ApplicantPersonID, 
                                ApplicationDate = @AppDate,
                                ApplicationTypeID = @AppTypeID,
                               ApplicationStatus = @ApplicationStatus,
                               LastStatusDate =@LastStatusDate,
                               PaidFees =@PaidFees,
                               CreatedByUserID = @CreatedByUserID
                              Where ApplicationID = @ApplicationID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            cmd.Parameters.AddWithValue("@AppDate", AppDate);
            cmd.Parameters.AddWithValue("@AppTypeID", AppTypeID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


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

        static public bool ChangeStatus(int ApplicationID,int ApplicationStatus)
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = @"Update Applications 
                              set ApplicationStatus = @ApplicationStatus,
                                    LastStatusDate = @LastStatusDate
                              Where ApplicationID = @ApplicationID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);



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

       
        static public bool Delete(int ApplicationID)
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = @"Delete From Applications 
                              Where ApplicationID = @ApplicationID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);



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
