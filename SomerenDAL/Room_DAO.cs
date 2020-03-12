using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SomerenModel;

namespace SomerenDAL
{
    public class Room_DAO : Base
    {
        //returns the list of rooms from the database, for the table 'rooms'
        public List<Room> Db_Get_All_Rooms()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT roomID, capacity, type FROM rooms", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Room> rooms = new List<Room>();

            //reads through all the records from the table 'rooms'
            while (reader.Read())
            {
                Room room = ReadRoom(reader);
                rooms.Add(room);
            }

            reader.Close();
            conn.Close();

            return rooms;
        }

        //translates a record of the table 'rooms' from the database into an object Room
        private Room ReadRoom(SqlDataReader reader)
        {
            int roomID = (int)reader["roomID"];
            int capacity = (int)reader["capacity"];
            bool boolType = (bool)reader["type"];

            return new Room(roomID, capacity, boolType);
        }
    }
}
