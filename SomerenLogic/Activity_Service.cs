using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;

namespace SomerenLogic
{
    public class Activity_Service
    {
        Activity_DAO activity_db = new Activity_DAO();

        //Will return a list of activities from database using a method from class Activity_DAO
        public List<Activity> GetAllActivities()
        {
            //tries to get list of activities from database unless an exception occurs
            try
            {
                List<Activity> activities = activity_db.Db_Get_All_Activities();

                return activities;
            }
            catch (Exception e)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{e.Message}] Activity - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when connecting to the database for activities!");
            }
        }

        //Adds new activity object to database as a record
        public void AddActivity(Activity activity)
        {
            //tries to add an activity to the database unless an exception occurs
            try
            {
                activity_db.Add_Activity(activity);
            }
            catch (Exception e)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{e.Message}] Activities - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when connecting to the database for activities!");
            }
        }

        //Removes an activity from the database using a method from class Activity_DAO
        public void RemoveActivity(int activityID)
        {
            //tries to remove an activity from the database unless an exception occurs
            try
            {
                activity_db.Remove_Activity(activityID);
            }
            catch (Exception e)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{e.Message}] Activities - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when connecting to the database for activities!");
            }
        }

        //Updates an activity in the database using a method from class Activity_DAO
        public void UpdateActivity(Activity activity)
        {
            //tries to update an activity in the database unless an exception occurs
            try
            {
                activity_db.Update_Activity(activity);
            }
            catch (Exception e)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{e.Message}] Activities - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when connecting to the database for activities!");
            }
        }
    }
}

