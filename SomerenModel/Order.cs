using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Order
    {
        //Properties
        public int OrderId { get; set;  }

        public int StudentId { get; set; }

        public int DrinkId { get; set; }

        public DateTime Date { get; set; }

        //Two constructors as date is can be pre determined as now
        public Order(int orderId, int studentId, int drinkId)
        {
            OrderId = orderId;
            StudentId = studentId;
            DrinkId = drinkId;
            Date = DateTime.Now;
        }

        public Order(int orderId, int studentId, int drinkId, DateTime date)
        {
            OrderId = orderId;
            StudentId = studentId;
            DrinkId = drinkId;
            Date = date;
        }

        //Overwritten ToString method
        public override string ToString()
        {
            return String.Format($"({OrderId}) Student {StudentId} ordered {DrinkId} at {Date.ToString("yyyy-MM-dd")}");
        }
    }
}
