using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Teacher
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Number { get; set; } // LecturerNumber, e.g. 47198

        public string FullName  // full name 
        {
            get
            {
                return FirstName + " " + LastName;
            }

        }

        public Teacher()
        {

        }

        public Teacher(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Teacher(int number, string firstName, string lastName)
            : this(firstName, lastName)
        {
            Number = number;
        }

        public override string ToString()
        {
            return $"({Number})" + FullName;
        }
    }
}