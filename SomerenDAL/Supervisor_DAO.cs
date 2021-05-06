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
    public class Supervisor_DAO : Base
    {
        //gets all the supervisors from database and returns a list of supervisors
        public List<Supervisor> Db_Get_All_Supervisors()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT S.teacherID, T.[name], T.lastname FROM supervisors S INNER JOIN teachers T ON S.teacherID = T.teacherID WHERE S.teacherID != 0", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Supervisor> supervisors = new List<Supervisor>(); //list of supervisors

            //reads a supervisor object and stores it in the list of Supervisors
            while (reader.Read())
            {
                Supervisor supervisor = ReadSupervisor(reader);
                supervisors.Add(supervisor);
            }
            reader.Close();
            conn.Close();

            return supervisors;
        }

        //reads a supervisor from the database and converts it into a supervisor object
        internal Supervisor ReadSupervisor(SqlDataReader reader)
        {
            int teacherID = (int)reader["teacherID"];
            string firstName = (string)reader["name"];
            string lastName = (string)reader["lastname"];

            return new Supervisor(teacherID, firstName, lastName);
        }

        //removes a supervisor from supervisors-table in the database
        public void Db_Remove_Supervisor(int teacherID)
        {
            SqlCommand cmd = new SqlCommand("UPDATE timetable SET supervisorID = 0 WHERE supervisorID = @supervisorIDGODELETE", conn);

            SqlCommand cmd2 = new SqlCommand("DELETE FROM supervisors WHERE teacherID = @teacherID ", conn);


            cmd.Parameters.AddWithValue("@supervisorIDGODELETE", teacherID);
            cmd2.Parameters.AddWithValue("@teacherID", teacherID);

            conn.Open();

            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();

            conn.Close();
        }

    }
}

