using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using SomerenModel;

namespace SomerenDAL
{
    public class Room_DAO : Base
    {
        private SqlConnection dbConnection;

        //Connects the database for this class, for the classes related to room
        public Room_DAO()
        {
            string connString = ConfigurationManager
                .ConnectionStrings["pdb1920it10"]       //pdb1920it10 = database name
                .ConnectionString;
            dbConnection = new SqlConnection(connString);
        }

        //returns the list of rooms from the database, for the table rooms
        public List<Room> Db_Get_All_Rooms()
        {
            dbConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT roomID, capacity, type FROM rooms", dbConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Room> rooms = new List<Room>();

            while (reader.Read())
            {
                Room room = ReadRoom(reader);
                rooms.Add(room);
            }

            reader.Close();
            dbConnection.Close();

            return rooms;
        }

        //translates a record of the table 'room' from the database into an object Room
        private Room ReadRoom(SqlDataReader reader)
        {
            int roomID = (int)reader["roomID"];
            int capacity = (int)reader["capacity"];
            bool boolType = (bool)reader["type"];

            return new Room(roomID, capacity, boolType);
        }
    }
}
