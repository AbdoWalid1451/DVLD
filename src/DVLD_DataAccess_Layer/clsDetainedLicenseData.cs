using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess_Layer
{
    public class clsDetainedLicenseData
    {
        static public bool IsLicenseDetained(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Select found = 1 from DetainedLicenses Where LicenseID = @LicenseID And IsReleased = 0";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        static public int addNew( int LicenseID
                             , DateTime DetainDate, decimal FineFees, int CreatedByUserID
                            , bool IsReleased, DateTime? ReleaseDate, int ReleasedByUserID
                             , int ReleaseApplicationID )
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Insert Into DetainedLicenses " +
                "Values ( @LicenseID, @DetainDate, @FineFees , @CreatedByUserID ,@IsReleased , @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID) " +
                "Select Scope_Identity();";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("@DetainDate", DetainDate);
            cmd.Parameters.AddWithValue("@FineFees", FineFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsReleased", IsReleased);

            if(ReleaseDate == null)
            cmd.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
            else
            cmd.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);

            if (ReleasedByUserID == -1)
                cmd.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);

            if(ReleaseApplicationID == -1)
            cmd.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);


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

        static public bool findDetainedLicense(ref int DetainID, ref int LicenseID
                             , ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID
                            , ref bool IsReleased, ref DateTime? ReleaseDate, ref int ReleasedByUserID
                             , ref int ReleaseApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Select * from DetainedLicenses Where DetainID = @DetainID OR " +
                "LicenseID = @LicenseID And IsReleased = 0";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@DetainID", DetainID);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            bool flag = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    DetainID = (int)reader["DetainID"];
                    LicenseID = (int)reader["LicenseID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (decimal)reader["FineFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];

                    if(reader["ReleaseDate"] == DBNull.Value)
                    ReleaseDate = null;
                    else
                    ReleaseDate = (DateTime)reader["ReleaseDate"];

                    if (reader["ReleasedByUserID"] == DBNull.Value)
                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];

                    if (reader["ReleaseApplicationID"] == DBNull.Value)
                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];

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

        static public bool Release(int DetainID, int LicenseID , bool IsReleased , DateTime? ReleaseDate , int ReleasedByUserID , int ReleaseApplicationID)
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = @"Update DetainedLicenses 
                              set IsReleased = @IsReleased , ReleaseDate = @ReleaseDate , ReleasedByUserID = @ReleasedByUserID ,ReleaseApplicationID = @ReleaseApplicationID
                              Where DetainID = @DetainID OR LicenseID =@LicenseID And IsReleased = @IsReleased";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@DetainID", DetainID);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("@IsReleased", IsReleased);
            cmd.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            cmd.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            cmd.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);



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

        static public DataTable getAll()
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Select DetainID , LicenseID , DetainDate,FineFees,IsReleased,ReleaseDate,ReleaseApplicationID from DetainedLicenses";

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


    }
}
