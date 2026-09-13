using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess_Layer
{
    public class clsLDLAppData
    {
        static public bool find(int LDLAppID, ref int ApplicationID, ref int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Select * from LocalDrivingLicenseApplications Where LocalDrivingLicenseApplicationID = @LDLAppID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LDLAppID", LDLAppID);

            bool flag = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];

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

        static public int addNew( int ApplicationID,  int LicenseClassID)
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Insert Into LocalDrivingLicenseApplications " +
                "Values (@ApplicationID, @LicenseClassID )" +
                "Select Scope_Identity();";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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

        static public bool Update(int LDLAppID,  int ApplicationID,  int LicenseClassID)
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = @"Update LocalDrivingLicenseApplications 
                              set ApplicationID = @ApplicationID, 
                                LicenseClassID = @LicenseClassID
                              Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


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

        static public bool Delete(int LDLAppID)
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = @"Delete From LocalDrivingLicenseApplications 
                              Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAppID);



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

        static public bool IsAlreadyExist(int ApplicantPersonID , int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "SELECT Found = 1 FROM  LocalDrivingLicenseApplications " +
                " INNER JOIN  Applications   " +
                " ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID " +
                "  Where ApplicantPersonID = @ApplicantPersonID And LicenseClassID = @LicenseClassID " +
                "And ApplicationStatus = 1 ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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

        static public DataTable getAll()
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = 
                $"SELECT LDLAppID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, DrivingClass = LicenseClasses.ClassName,People.NationalNo" +
                $",  FullName = People.FirstName +' '+  People.SecondName +' '+   People.ThirdName +' '+   People.LastName," +
                $"  Applications.ApplicationDate,PassedTests = COALESCE(T1.PassedTests, 0) " +
                $",Status =" +
                $" Case " +
                $"When Applications.ApplicationStatus = 1 THen 'New'" +
                $"  When Applications.ApplicationStatus = 2 THen 'Canceled'" +
                $"  When Applications.ApplicationStatus = 3 THen 'Completed'  " +
                $"End " +
                $"FROM     LocalDrivingLicenseApplications " +
                $" INNER JOIN     " +
                $" LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID    " +
                $" INNER JOIN       " +
                $"            Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID " +
                $"   INNER JOIN           " +
                $"      People ON Applications.ApplicantPersonID = People.PersonID " +
                $"  Left JOIN  " +
                $" (   Select LocalDrivingLicenseApplicationID,PassedTests = count(*) From( SELECT TestAppointments.LocalDrivingLicenseApplicationID, Tests.TestResult FROM     Tests " +
                $"INNER JOIN      " +
                $"   TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID" +
                $"   Where TestResult = 1 )R1 " +
                $"Group By LocalDrivingLicenseApplicationID )T1 " +
                $"ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = T1.LocalDrivingLicenseApplicationID";

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
