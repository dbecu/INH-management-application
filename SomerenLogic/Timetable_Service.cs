using System;
using System.Collections.Generic;
using SomerenModel;
using SomerenDAL;
using System.Data;

namespace SomerenLogic
{
    public class Timetable_Service
    {
        TimetableDAO timetable_db = new TimetableDAO();

        //returns a list of timetable using DAO class
        public List<Timetable> GetTimetable()
        {
            try
            {
                List<Timetable> list = timetable_db.DB_To_Timetable();

                return list;
            }
            catch (Exception e)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{e.Message}] Timetable - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when connecting to the database for timetable!");
            }
        }

        //inserts a timetable object in the database, as timetable record
        public void InsertTimetable(Timetable timetable)
        {
            try
            {
                timetable_db.DB_InsertTimetable(timetable);
            }
            catch (Exception e)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{e.Message}] Timetable - Something went wrong when inserting a timetable to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when trying to add your new timetable to the database!");
            }
        }
    }
}
