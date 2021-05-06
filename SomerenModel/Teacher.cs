using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Teacher
    {
        //Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Number { get; set; } // LecturerNumber, e.g. 47198
        public virtual bool IsSupervisor { get; set; } 
        public string FullName  // full name 
        {
            get
            {
                return FirstName + " " + LastName;
            }

        }

        //returns yes if its a supervisor else returns no
        public string StringSupervisor
        {
            get
            {
                if (IsSupervisor)
                    return "Yes";
                else
                    return "No";
            }
        }

        //constructor of Teacher
        public Teacher(int number, string firstName, string lastName) 
        {
            FirstName = firstName;
            LastName = lastName;
            Number = number;
        }

        //Overwritten toString method
        public override string ToString()
        {
            return $"({Number})" + FullName;
        }
    }
}