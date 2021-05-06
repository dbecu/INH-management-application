using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Supervisor : Teacher
    {
        //Overwritten IsSupervisor Property, as IsSupervisor will always return true for this class
        public override bool IsSupervisor
        {
            get
            {
                return true;
            }
        }

        //Construstor using teacher constructor 
        public Supervisor(int number, string firstName, string lastNmae) : base(number, firstName, lastNmae)
        {
            Number = number;
            FirstName = firstName;
            LastName = lastNmae;

        }
    }
}

