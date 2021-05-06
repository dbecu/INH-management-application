using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Drink
    {
        //Properties of object drink
        public int Number { get; set; }
        public string Name { get; set; }
        public bool Alcoholic { get; set; }
        public decimal VAT { get; set; }
        public decimal Price { get; set; }
       
        //amount in stock
        public int Amount { get; set; }

        //returns yes if its alcoholic, else returns no
        public string StringAlcoholic
        {
            get
            {
                if (Alcoholic)
                    return "Yes";
                else
                    return "No";
            }
        }

        //returns true if amount in stock is greater or equal to 10, else returns false
        public int Is_Stocked
        {
            get
            {
                if (Amount >= 10)
                    return 1;
                else
                    return 0;
            }
        }


        //Constructor for object Drink
        public Drink(int number, string name, decimal price, int amount)
        {
            Number = number;
            Name = name;
            Price = price;
            Amount = amount;
        }
        
        //empty constructor
        public Drink()
        {
        
        }
        
        //Overwritten ToString method
        public override string ToString()
        {
            return $"{Number}.{Name} (€ {Price})";
        }
    }
}