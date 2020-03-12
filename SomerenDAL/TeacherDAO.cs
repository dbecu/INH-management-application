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
        //gets all the teachers from database and returns a list of teachers
        public List<Teacher> Db_Get_All_Teachers()  
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT teacherID, name,lastname FROM teachers", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>(); //list of teachers

            //reads a teacher object and stores it in the list of teachers
            while (reader.Read())  
            {
                Teacher teacher = ReadTeacher(reader);
                teachers.Add(teacher);
            }
            reader.Close();

            SqlCommand cmd2 = new SqlCommand("SELECT teacherID FROM supervisors", conn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            List<int> supervisors = new List<int>(); //list of supervisors

            //reads teacherID from supervisor table of database and stores it into a list
            while (reader2.Read())
            {
                int teacherID = (int)reader2["teacherID"];
                supervisors.Add(teacherID);
            }

            reader2.Close();

            //checks if the supervisor contains that teacherId, if yes, then sets the supervisor property of teacher true
            foreach (Teacher teacher in teachers)
            {
                if (supervisors.Contains(teacher.Number))
                    teacher.Supervisor = true;
                
            }

            conn.Close();

            return teachers;
        }

        //reads a teacher from the database and converts it into a teacher object
        private Teacher ReadTeacher(SqlDataReader reader)
        {
            int teacherID = (int)reader["teacherID"];
            string firstName = (string)reader["name"];
            string lastName = (string)reader["lastname"];

            return new Teacher(teacherID, firstName, lastName);
        }
    }
}