using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;
using System.Configuration;

namespace SomerenDAL
{
    public class Room_DAO : Base
    {

        //test beta

        private SqlConnection dbConnection;

        public Room_DAO()
        {
            string connString = ConfigurationManager
                .ConnectionStrings["pdb1920it10"]       //database name
                .ConnectionString;
            dbConnection = new SqlConnection(connString);
        }

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

        private Room ReadRoom(SqlDataReader reader)
        {
            int roomID = (int)reader["roomID"];
            int capacity = (int)reader["capacity"];
            bool boolType = (bool)reader["type"];

            return new Room(roomID, capacity, boolType);
        }


    }
}
