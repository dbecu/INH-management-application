using System.Collections.Generic;
using System.Data.SqlClient;
using SomerenModel;


namespace SomerenDAL
{
    public class Activity_DAO : Base
    {
        //returns the list of activities from the database, for the table 'activities'
        public List<Activity> Db_Get_All_Activities()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT activityID,description,numberOfStudents,numberOfSupervisors FROM activities", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Activity> activities = new List<Activity>();

            //reads through all the records from the table 'activities'
            while (reader.Read())
            {
                Activity activity = ReadActivity(reader);
                activities.Add(activity);
            }

            reader.Close();
            conn.Close();

            return activities;
        }

        //translates a record of the table 'activities' from the database into an object Activity
        internal Activity ReadActivity(SqlDataReader reader)
        {
            int activityID = (int)reader["activityID"];
            string description = (string)reader["description"];
            int nrOfStudents = (int)reader["numberOfStudents"];
            int nrOfSupervisors = (int)reader["numberOfSupervisors"];

            return new Activity(activityID, description, nrOfStudents, nrOfSupervisors);
        }

        //Adds a new activity to the database
        public void Add_Activity(Activity activity)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO activities" +
                                            " VALUES(@description, @numberOfStudents, @numberOfSupervisors)", conn);

            cmd.Parameters.AddWithValue("@description", activity.Description);
            cmd.Parameters.AddWithValue("@numberOfStudents", activity.NrOfStudents);
            cmd.Parameters.AddWithValue("@numberOfSupervisors", activity.NrOfSupervisors);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        //removes the selected activity from the database
        public void Remove_Activity(int activityId)
        {
            SqlCommand cmd0 = new SqlCommand("DELETE FROM timetable WHERE activityID = @activityID ", conn);
            SqlCommand cmd = new SqlCommand("DELETE FROM activities WHERE activityID = @activityID ", conn);

            cmd0.Parameters.AddWithValue("@activityID", activityId);
            cmd.Parameters.AddWithValue("@activityID", activityId);

            conn.Open();

            cmd0.ExecuteNonQuery();
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        //updates the activity in the database
        public void Update_Activity(Activity activity)
        {
            SqlCommand cmd = new SqlCommand("UPDATE activities " +
                 "SET description = @description, numberOfStudents = @nrOfStudents, numberOfSupervisors = @nrOfSupervisors " +
                  "WHERE activityID = @activityId", conn);

            cmd.Parameters.AddWithValue("@activityId", activity.Number);
            cmd.Parameters.AddWithValue("@description", activity.Description);
            cmd.Parameters.AddWithValue("@nrOfStudents", activity.NrOfStudents);
            cmd.Parameters.AddWithValue("@nrOfSupervisors", activity.NrOfSupervisors);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
