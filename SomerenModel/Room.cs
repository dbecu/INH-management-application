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

        // RoomNumber, e.g. 201 - 225 (incl) 
        public int Number { get; set; }

        // number of beds, either 4,6,8,12 or 16
        public int Capacity { get; set; }
        public bool Type { get; set; } 

        //What changes the Boolean Type to the String Type, student = false, teacher = true
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

        //Constructore for object Room
        public Room(int number, int capacity, bool type)
        {
            Number = number;
            Capacity = capacity;
            Type = type;
        }
    }
}
