using System;
using System.Collections.Generic;
using SomerenModel;
using SomerenDAL;

namespace SomerenLogic
{
    public class Teacher_Service
    {
        Teacher_DAO teacher_db = new Teacher_DAO();

        // retreives a list of teachers from database and returns it.In case of an exception, a hardcoded list is created
        public List<Teacher> GetTeachers()
        {
            try
            {
                List<Teacher> teacher = teacher_db.Db_Get_All_Teachers();
                return teacher;
            }
            catch (Exception e)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{e.Message}] Teacher - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when connecting to the database for teacher!");

            }

        }

        // retreives a list of teachers from database and returns it.In case of an exception, a hardcoded list is created
        public List<Teacher> Show_nonSupervisors()
        {
            try
            {
                List<Teacher> teacher = teacher_db.Db_Get_Non_supervisors();
                return teacher;

            }
            catch (Exception e)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{e.Message}] Teacher - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when connecting to the database for teacher!");

            }

        }

        //inserts a teacher into supervisors-table in database 
        public void InsertSupervisors(int teacherID)
        {
            //tries to insert teacherID into database unless an exception occurs
            try
            {
                teacher_db.Db_Insert_Supervisor(teacherID);

            }
            catch (Exception e)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{e.Message}] Teacher - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when connecting to the database for order!");
            }
        }
    }
}
