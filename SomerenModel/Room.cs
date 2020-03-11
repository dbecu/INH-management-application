using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Room 
    {
        //Properties of object room
        public int Number { get; set; } // RoomNumber, e.g. 206
        public int Capacity { get; set;  } // number of beds, either 4,6,8,12 or 16
        public bool Type { get; set; } // student = false, teacher = true

        //What changes the Boolean Type to the String Type
        public string StringType
        {
            get
            {
                if (Type)
                    return "teacher";
                else
                    return "student";
            }
        }

        public Room(int number, int capacity, bool type)
        {
            Number = number;
            Capacity = capacity;
            Type = type;
        }

        public Room(int number)
        {
            Number = number;
            Capacity = 0;
            Type = false;
        }

    }
}
