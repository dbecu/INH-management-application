using System;
using System.Collections.Generic;
using SomerenModel;
using SomerenDAL;

namespace SomerenLogic
{
    public class Supervisor_Service
    {
        Supervisor_DAO supervisor_db = new Supervisor_DAO();

        // retreives a list of supervisors from database and returns it.In case of an exception, a hardcoded list is created
        public List<Supervisor> GetSupervisors()
        {
            try
            {
                List<Supervisor> supervisor = supervisor_db.Db_Get_All_Supervisors();
                return supervisor;
            }
            catch (Exception e)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{e.Message}] Supervisor - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when connecting to the database for supervisor!");

            }

        }

        //Removes a drink from the database using a method from class Drink_DAO
        public void RemoveSupervisor(int teacherID)
        {
            //tries to remove a drink from the database unless an exception occurs
            try
            {
                supervisor_db.Db_Remove_Supervisor(teacherID);
            }
            catch (Exception e)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{e.Message}] Supervisor - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when trying to remove a supervisor!");
            }
        }
    }
}

