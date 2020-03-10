using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Student
    {
        public String Name { get; set; }
        public String lastName { get; set; }
        public int Number { get; set; } // StudentNumber, e.g. 474791
        public DateTime BirthDate { get; set; }

        public Student(int number, string name, string lastName, DateTime birthDate)
        {
            this.Number = number;
            this.Name = name;
            this.lastName = lastName;
            this.BirthDate = birthDate;
        }


        public string FullName
        {
            get
            {
                return $"{Name} {lastName}";
            }
        }


        public override string ToString()
        {
            return $"{Number}.{FullName} ({BirthDate})";
        }
    }
}
