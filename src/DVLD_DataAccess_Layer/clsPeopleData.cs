using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess_Layer
{
    public class clsPeopleData
    {
        static public DataTable getAll()
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = $"SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName," +
                $" Gendor =  case When Gendor = 0 Then 'Male' When Gendor = 1 then 'Female' else 'UnKnown' END " +
                $", People.DateOfBirth, Nationality = Countries.CountryName, People.Phone, People.Email" +
                $" FROM  People INNER JOIN " +
                $"  Countries ON People.NationalityCountryID = Countries.CountryID";

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

        static public bool findByID(int PersonID,ref string NationalNo, ref string FName, ref string SName
                , ref string TName, ref string LName,  ref DateTime DateOfBirth ,
                ref short Gendor, ref string Address
                ,  ref string Phone,ref string Email, ref int NationalCountryID
               , ref string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Select * from People Where PersonID = @PersonID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            bool flag = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    NationalNo = (string)reader["NationalNo"];
                    FName = (string)reader["FirstName"];
                    SName = (string)reader["SecondName"];

                    if (reader["ThirdName"] == DBNull.Value)
                        TName = null;
                    else
                        TName = (string)reader["ThirdName"];

                    LName = (string)reader["LastName"]; 
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];

                    if (reader["Email"] == DBNull.Value)
                        Email = null;
                    else
                        Email = (string)reader["Email"];

                    NationalCountryID = (int)reader["NationalityCountryID"];
       
                    if (reader["ImagePath"] == DBNull.Value)
                        ImagePath = null;
                    else
                        ImagePath = (string)reader["ImagePath"];

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

        static public bool findByNationalNo( string NationalNo,ref int PersonID,  ref string FName, ref string SName
             , ref string TName, ref string LName, ref DateTime DateOfBirth,
             ref short Gendor, ref string Address
             , ref string Phone, ref string Email, ref int NationalCountryID
            , ref string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Select * from People Where NationalNo = @NationalNo";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);

            bool flag = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    NationalNo = (string)reader["PersonID"];
                    FName = (string)reader["FirstName"];
                    SName = (string)reader["SecondName"];

                    if (reader["ThirdName"] == DBNull.Value)
                        TName = null;
                    else
                        TName = (string)reader["ThirdName"];

                    LName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];

                    if (reader["Email"] == DBNull.Value)
                        Email = null;
                    else
                        Email = (string)reader["Email"];

                    NationalCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] == DBNull.Value)
                        ImagePath = null;
                    else
                        ImagePath = (string)reader["ImagePath"];

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

        static public int addNew( string NationalNo,  string FName,  string SName
                ,  string TName,  string LName,   DateTime DateOfBirth,
                 short Gendor,  string Address
                ,   string Phone,string Email,  int NationalityCountryID
               ,  string ImagePath)
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Insert Into People " +
                "Values (@NationalNo, @FirstName, @SecondName, @ThirdName , @LastName, @DateOfBirth , @Gendor " +
                ", @Address , @Phone, @Email   " +
                ",@NationalityCountryID , @ImagePath);" +
                "Select Scope_Identity();";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
            cmd.Parameters.AddWithValue("@FirstName", FName);
            cmd.Parameters.AddWithValue("@SecondName", SName);
            cmd.Parameters.AddWithValue("@ThirdName", TName);
            cmd.Parameters.AddWithValue("@LastName", LName);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@Gendor", Gendor);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (string.IsNullOrEmpty(ImagePath))
                cmd.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@ImagePath", ImagePath);

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

        static public bool Update(int PersonID,  string NationalNo,  string FName,  string SName
                ,  string TName,  string LName,  DateTime DateOfBirth,  short Gendor,  
            string Address,  string Phone,  string Email,  int NationalityCountryID,  string ImagePath)
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = @"Update People 
                              set NationalNo = @NationalNo, 
                                FirstName = @FirstName,
                                SecondName = @SecondName,
                               ThirdName = @ThirdName,
                               LastName =@LastName,
                               DateOfBirth =@DateOfBirth,
                               Gendor = @Gendor, 
                               Address =@Address,
                               Phone =@Phone,
                                Email =@Email,
                                NationalityCountryID = @NationalityCountryID,
                               ImagePath =@ImagePath
                              Where PersonID = @PersonID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
            cmd.Parameters.AddWithValue("@FirstName", FName);
            cmd.Parameters.AddWithValue("@SecondName", SName);
            cmd.Parameters.AddWithValue("@ThirdName", TName);
            cmd.Parameters.AddWithValue("@LastName", LName);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@Gendor", Gendor);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (string.IsNullOrEmpty(ImagePath))
                cmd.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@ImagePath", ImagePath);


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

        static public bool Delete(int PersonID)
        {


            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = @"Delete From People 
                              Where PersonID = @PersonID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);



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

        static public bool IsExistByNationalNo(string NationalNo)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Select found = 1 from People Where NationalNo = @NationalNo";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);

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

        static public bool IsExistByPersonID(int PersonID)
        {
            SqlConnection connection = new SqlConnection(clsSettings.ConnectionString);
            string query = "Select found = 1 from People Where PersonID = @PersonID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

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
