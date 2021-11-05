using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace StudentBC
{
    class DataHandler
    {
        public DataHandler() { }

        string con = "Server=(local); Initial Catalog=StudentBC; Integrated Security=SSPI";
        List<User> user = new List<User>();
        public void AddUser(string u,string p)
        {
            User us = new User(u, p);

            user.Add(us);

        }
        public List<string> Format()
        {
            List<string> formatedData = new List<string>();

            foreach (User usr in user)
            {
                formatedData.Add(usr.ToString());
            }

            return formatedData;
        }
        public void LogIn()
        {
            try
            {

                DCDashboard Dc = new DCDashboard();
                MessageBox.Show("Login Sucessful");
            }
            catch
            {
                MessageBox.Show("Login UnSucessful");
            }
            
        }
        public void AddStudent(string StuNr, Image StdImg, string name, string surname, DateTime DOB, string Gender, string Addressline1, string Addressline2, string City,string @Province, string PostalCode, string course)
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spAddStudent", connect);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StuNr", StuNr);
                    cmd.Parameters.AddWithValue("@StdImg", StdImg);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@surname", surname);
                    cmd.Parameters.AddWithValue("@DOB", DOB);
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("@AddressLine1", Addressline1);
                    cmd.Parameters.AddWithValue("@AddressLine2", Addressline2);
                    cmd.Parameters.AddWithValue("@City", City);
                    cmd.Parameters.AddWithValue("@Province", Province);
                    cmd.Parameters.AddWithValue("@PostalCode", PostalCode);
                    cmd.Parameters.AddWithValue("@course", course);

                    connect.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong" + ex);
            }

        }
        public void UpdateStudent(string StuNr, Image StdImg, string name, string surname, DateTime DOB, string Gender, string Addressline1, string Addressline2, string City, string @Province, string PostalCode, string course)
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(con))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateStudent", connect);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StuNr", StuNr);
                    cmd.Parameters.AddWithValue("@StdImg", StdImg);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@surname", surname);
                    cmd.Parameters.AddWithValue("@DOB", DOB);
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("@AddressLine1", Addressline1);
                    cmd.Parameters.AddWithValue("@AddressLine2", Addressline2);
                    cmd.Parameters.AddWithValue("@City", City);
                    cmd.Parameters.AddWithValue("@Province", Province);
                    cmd.Parameters.AddWithValue("@PostalCode", PostalCode);
                    cmd.Parameters.AddWithValue("@course", course);

                    connect.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong" + ex);
            }

        }
        public DataTable DeleteData(int StuNr)
        {
            using (SqlConnection connect = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand("spDeleteStudent", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StuNr", StuNr);

                connect.Open();
                DataTable dt = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);
                    return dt;
                }
            }
        }
        //Show All
        public DataTable GetStudents()
        {
            SqlConnection connect = new SqlConnection(con);
            SqlDataAdapter adapter = new SqlDataAdapter("spGETStudent", connect);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();

            adapter.Fill(dt);
            return dt;
        }
        //search
        public DataTable SearchData(int id)
        {
            using (SqlConnection connect = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand("spSearchStudent", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StuNr", id);

                connect.Open();
                DataTable lb = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    lb.Load(dr);
                    return lb;
                }
            }
        }
    }
}
