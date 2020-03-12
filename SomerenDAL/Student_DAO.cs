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

        //returns the list of students from the database, table student
        public List<Student> Db_Get_All_Students()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT studentID, name, lastname, birthdate FROM students", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Student> students = new List<Student>();

            //reads through all the records from the table 'students'
            while (reader.Read())
            {
                Student student = ReadStudent(reader);
                students.Add(student);
            }

            reader.Close();
            conn.Close();

            return students;
        }

        //from table "student" in database into object Student
        private Student ReadStudent(SqlDataReader reader)
        {
            int studentID = (int)reader["studentID"];
            string firstName = (string)reader["name"];
            string lastName = (string)reader["lastName"];
            DateTime birthDate = (DateTime)reader["birthdate"];

            return new Student(studentID, firstName, lastName, birthDate);
        }
    }
}
