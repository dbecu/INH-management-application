using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;

namespace SomerenLogic
{
    public class Room_Service
    {
        Room_DAO room_db = new Room_DAO();

        //Will return a list of rooms from database using a method from class Room_DAO
        public List<Room> GetRooms()
        {
            //tries to get list of rooms from database unless an exception occurs
            try
            {
                List<Room> rooms = room_db.Db_Get_All_Rooms();

                return rooms;
            }
            catch (Exception e)     
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{e.Message}] Room - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when connecting to the database for room!");
            }
        }
    }
}
