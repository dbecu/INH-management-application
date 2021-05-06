using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Activity
    {
        //properties of activity
        public int Number { get; set; }
        public string Description { get; set; }
        public int NrOfStudents { get; set; }
        public int NrOfSupervisors { get; set; }

        public Activity()
        {
            //default constructor
        }

        //constructor with 3 parameters
        public Activity(int Number, string Description, int NrOfStudents, int NrOfSupervisors)
        {
            this.Number = Number;
            this.Description = Description;
            this.NrOfStudents = NrOfStudents;
            this.NrOfSupervisors = NrOfSupervisors;
        }


        //overwritten ToString method
        public override string ToString()
        {
            return Number + " " + Description;
        }
    }
}
