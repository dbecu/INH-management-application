using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SomerenDAL
{
    public class Teacher_DAO : Base
    {
        private SqlConnection dbConnection;

        public Teacher_DAO()
        {
            string connString = ConfigurationManager
                .ConnectionStrings["pdb1920it10"]       //database name
                .ConnectionString;
            dbConnection = new SqlConnection(connString);
        }
        public List<Teacher> Db_Get_All_Teachers()  //gets all the teachers from database
        {
            dbConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM teachers", dbConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();

            while (reader.Read())
            {
                Teacher teacher = ReadTeacher(reader);
                teachers.Add(teacher);
            }

            reader.Close();
            dbConnection.Close();

            return teachers;
        }

        private Teacher ReadTeacher(SqlDataReader reader)
        {
            int teacherID = (int)reader["teacherID"];
            string firstName = (string)reader["name"];
            string lastName = (string)reader["lastname"];

            return new Teacher(teacherID, firstName, lastName);
        }
    }
}