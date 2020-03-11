using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Room_Service
    {
        Room_DAO room_db = new Room_DAO();

        //Will return a list of rooms from database using a method from class Room_DAO
        //if an exception occurs, a hardcoded list is created
        public List<Room> GetRooms()
        {
            //tries to get list of rooms from database unless an exception occurs
            try
            {
                List<Room> rooms = room_db.Db_Get_All_Rooms();

                //Test for exception
                int[] test = new int[2];
                int num = test[5];

                return rooms;
            }
            catch (Exception)
            {

                // something went wrong connecting to the database, 
                //so we will make a fake list of rooms so 
                //the application continues working!

                List<Room> rooms = new List<Room>();
                Room a = new Room(474791, 4, true);
                Room b = new Room(123456, 16, false);

                rooms.Add(a);
                rooms.Add(b);

                //For the error log and error form
                string errorText = "Cannot reach the Database for rooms";
                File.AppendAllText(@"..\..\..\errorlog.txt", $"\n({DateTime.Now}) {errorText}");

                return rooms;

            }


        }
    }
}
