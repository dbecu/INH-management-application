using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;
using System.Configuration;

namespace SomerenDAL
{
    public class Student_DAO : Base
    {

        private SqlConnection dbConnection;

        public Student_DAO()
        {
            string connString = ConfigurationManager
                .ConnectionStrings["pdb1920it10"]       //database name
                .ConnectionString;
            dbConnection = new SqlConnection(connString);
        }

        public List<Student> Db_Get_All_Students()
        {
            dbConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM students", dbConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Student> students = new List<Student>();

            while (reader.Read())
            {
                Student student = ReadStudent(reader);
                students.Add(student);
            }

            reader.Close();
            dbConnection.Close();

            return students;
        }

        private Student ReadStudent(SqlDataReader reader)
        {
            int studentID = (int)reader["studentID"];
            string firstName = (string)reader["name"];
            string lastName = (string)reader["lastName"];
            DateTime birthDate = (DateTime)reader["birthdate"];

            return new Student(studentID, firstName, lastName, birthDate);
        }


        //private List<Room> ReadTables(DataTable dataTable)
        //{
        //    List<Room> rooms = new List<Room>();

        //    foreach (DataRow dr in dataTable.Rows)
        //    {
        //        Room room = new Room()
        //        {
        //            Number = (int)dr["roomID"]
        //        };
        //        rooms.Add(room);
        //    }
        //    return rooms;
        //}
    }
}
