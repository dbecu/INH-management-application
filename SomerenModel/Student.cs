using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Student
    {
        //Properties
        public String Name { get; set; }
        public String LastName { get; set; }
        public int Number { get; set; } // StudentNumber, e.g. 474791
        public DateTime BirthDate 
        {
            get; set;
        } 

        //Calculated property
        public string FullName
        {
            get
            {
                return $"{Name} {LastName}";
            }
        }

        //Constructor for object Student
        public Student(int number, string name, string lastName, DateTime birthDate)
        {
            this.Number = number;
            this.Name = name;
            this.LastName = lastName;
            this.BirthDate = birthDate;
        }

        //Overwritten ToString method
        public override string ToString()
        {
            return $"{Number}.{FullName} ({BirthDate})";
        }
    }
}
