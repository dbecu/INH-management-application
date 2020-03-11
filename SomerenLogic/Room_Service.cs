using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Room_Service
    {
        Room_DAO room_db = new Room_DAO();

        //Will return a list of rooms from database. if an exception occurs, a hardcoded list is created
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
                string txt = e.Message;
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Room> rooms = new List<Room>();
                Room a = new Room(474791);
                a.Capacity = 4;
                a.Type = true;
                rooms.Add(a);

                Room b = new Room(123456);
                b.Capacity = 16;
                b.Type = false;
                rooms.Add(b);

                return rooms;

                throw e;


            }


        }
    }
}
