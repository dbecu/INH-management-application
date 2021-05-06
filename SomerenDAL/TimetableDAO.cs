using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class TimetableDAO : Base
    {

        //Returns list of timetable from the database
        public List<Timetable> DB_To_Timetable()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand(
                "SELECT	A.activityID, A.[description], A.numberOfStudents, A.numberOfSupervisors, " +
                        "TE.teacherID, TE.[name], TE.lastname, " +
                        "T.[date], T.starttime, T.endtime " +
                "FROM timetable AS T " +
                        "JOIN activities AS A ON T.activityID = A.activityID " +
                        "JOIN supervisors AS S ON T.supervisorID = S.teacherID " +
                        "JOIN teachers AS TE ON S.teacherID = TE.teacherID", conn);

            SqlDataReader reader = cmd.ExecuteReader();
            List<Timetable> timetables = new List<Timetable>();

            Activity_DAO activity_DAO = new Activity_DAO();
            Supervisor_DAO supervisor_DAO = new Supervisor_DAO();

            //reads through all the records from the table 'activities'
            while (reader.Read())
            {
                timetables.Add(ReadTimetable(reader, activity_DAO, supervisor_DAO));
            }
            conn.Close();

            return timetables;
        }

        //Inserts a new timetable object in thedatabase
        public void DB_InsertTimetable(Timetable timetable)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO timetable " +
                "VALUES (@activityID, @supervisorID, @date, @starttime, @endtime)", conn);

            //Adds all needed timetable properties
            cmd.Parameters.AddWithValue("@activityID", timetable.Activity.Number);
            cmd.Parameters.AddWithValue("@supervisorID", timetable.Supervisor.Number);
            cmd.Parameters.AddWithValue("@date", timetable.Date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@starttime", timetable.StartTime.ToString("HH:mm:ss"));
            cmd.Parameters.AddWithValue("@endtime", timetable.EndTime.ToString("HH:mm:ss"));

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        //Reads a timetable record through a SqlDataReader and return a timetable object
        private Timetable ReadTimetable(SqlDataReader reader, Activity_DAO activity_DAO, Supervisor_DAO supervisor_DAO)
        {
            Activity activity = activity_DAO.ReadActivity(reader);
            Supervisor supervisor = supervisor_DAO.ReadSupervisor(reader);
            DateTime date = (DateTime)reader["date"];
            DateTime starttime = SqlTimeStringToDateTime(reader["starttime"].ToString());
            DateTime endtime = SqlTimeStringToDateTime(reader["endtime"].ToString());

            return new Timetable(activity, supervisor, date, starttime, endtime);
        }

        //Converts the toString form of sql Time to a DateTime object and returns it
        public DateTime SqlTimeStringToDateTime(string sqlTime)
        {
            DateTime time = DateTime.ParseExact($"2001-01-01 {sqlTime[0]}{sqlTime[1]}:{sqlTime[3]}{sqlTime[4]}:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            return time;
        }
    }
}
