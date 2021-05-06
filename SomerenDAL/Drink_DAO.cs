using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SomerenModel;

namespace SomerenDAL
{
    public class Drink_DAO : Base
    {
        //returns the list of drinks from the database, for the table 'drinks'
        public List<Drink> Db_Get_All_Drinks()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT drinks.drinkID, drinks.[name], drinks.price, stocks.amount FROM drinks JOIN stocks ON drinks.drinkID = stocks.drinkID", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Drink> drinks = new List<Drink>();

            //reads through all the records from the table 'drinks'
            while (reader.Read())
            {
                Drink drink = ReadDrink(reader);
                drinks.Add(drink);
            }

            reader.Close();
            conn.Close();

            return drinks;
        }

        //insert studentId and drinkId for new order to the database for the table 'orders'
        public void Db_insert_orders(int studentID, int drinkID)
        {
            conn.Open();
            string strDate = DateTime.Now.ToString("yyyy-MM-dd");
            SqlCommand cmd = new SqlCommand("INSERT INTO orders VALUES (@studentID, @drinkID, @strDate)", conn);
            cmd.Parameters.AddWithValue("@studentID", studentID);
            cmd.Parameters.AddWithValue("@drinkID", drinkID);
            cmd.Parameters.AddWithValue("@strDate", strDate);

            cmd.ExecuteNonQuery();

            conn.Close();
        }


        //update amont of drinks in table 'stocks'
        public void Db_Change_Amount(int drinkID)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE stocks SET amount = amount - 1 WHERE drinkID = @drinkID", conn);
            cmd.Parameters.AddWithValue("@drinkID", drinkID);
            cmd.ExecuteNonQuery();

            conn.Close();


        }

        //returns the price of drinks selected from database
        public decimal Db_Get_Price_Of_DrinkID(int drinkID)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT D.[name], price AS [totalPrice] FROM drinks D WHERE drinkID = @drinkID", conn);
            cmd.Parameters.AddWithValue("@drinkID", drinkID);
            SqlDataReader reader = cmd.ExecuteReader();


            decimal price;


            if (reader.Read())
            {
                price = (decimal)reader["totalPrice"];
            }
            else
            {
                price = 0;
            }

            reader.Close();
            conn.Close();

            return price;
        }

        //translates a record of the table 'drinks' from the database into an object Drink
        private Drink ReadDrink(SqlDataReader reader)
        {
            int drinkID = (int)reader["drinkID"];
            string name = (string)reader["name"];
            decimal price = (decimal)reader["price"];
            int amount = (int)reader["amount"];

            return new Drink(drinkID, name, price, amount);
        }


        //returns the list of drinks(excluding water,orangeade,cherry juice) from the database
        public List<Drink> Db_Get_Specific_Drinks()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT drinks.drinkID,drinks.[name],drinks.price, stocks.amount AS [amount_stock]" +
                " FROM drinks " +
                "JOIN stocks ON drinks.drinkID = stocks.drinkID " +
                "WHERE stocks.amount > 1 " +
                "AND drinks.price > 1 " +
                "AND NOT [name] LIKE 'orangeade' " +
                "AND NOT [name] LIKE 'cherry juice' " +
                "AND NOT [name] LIKE 'water' " +
                "GROUP BY drinks.drinkID,drinks.[name], stocks.amount, drinks.price " +
                "ORDER BY stocks.amount, drinks.price", conn);

            SqlDataReader reader = cmd.ExecuteReader();
            List<Drink> drinks = new List<Drink>();

            //reads through all the records from the table 'drinks'
            while (reader.Read())
            {
                Drink drink = ReadDrinkWithAmount(reader);
                drinks.Add(drink);
            }

            reader.Close();
            conn.Close();

            return drinks;
        }

        //translates a record of the table 'drinks' from the database into an object Drink
        private Drink ReadDrinkWithAmount(SqlDataReader reader)
        {
            int drinkID = (int)reader["drinkID"];
            string name = (string)reader["name"];
            decimal price = (decimal)reader["price"];
            int amountInStock = (int)reader["amount_stock"];

            Drink drink = new Drink(drinkID, name, price, amountInStock);
            return drink;
        }

        //Adds a new drink to the database
        public void Add_Drink(Drink drink)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO drinks(name,alcoholic,price,VAT) VALUES(@name, @alcoholic, @price , @VAT)", conn);

            cmd.Parameters.AddWithValue("@name", drink.Name);
            cmd.Parameters.AddWithValue("@alcoholic", drink.Alcoholic);
            cmd.Parameters.AddWithValue("@price", drink.Price);
            cmd.Parameters.AddWithValue("@VAT", drink.VAT);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        //removes the selected drink from the database
        public void Remove_Drink(int drinkID)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM orders WHERE drinkId = @drinkID ", conn);
            SqlCommand cmd2 = new SqlCommand("DELETE FROM stocks WHERE drinkId = @drinkID", conn);
            SqlCommand cmd3 = new SqlCommand("DELETE FROM drinks WHERE drinkId = @drinkID", conn);

            cmd.Parameters.AddWithValue("@drinkID", drinkID);
            cmd2.Parameters.AddWithValue("@drinkID", drinkID);
            cmd3.Parameters.AddWithValue("@drinkID", drinkID);

            conn.Open();

            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cmd3.ExecuteNonQuery();

            conn.Close();
        }

        //updates the drink(name,price,amount in stock) in the database
        public void Update_Drink(Drink drink)
        {
            SqlCommand cmd = new SqlCommand("UPDATE drinks SET name=@name , price= @price WHERE drinkID = @drinkId", conn);
            SqlCommand cmd2 = new SqlCommand("UPDATE stocks SET amount = @amount WHERE drinkID = @drinkId", conn);

            cmd.Parameters.AddWithValue("@drinkId", drink.Number);
            cmd.Parameters.AddWithValue("@name", drink.Name);
            cmd.Parameters.AddWithValue("@price", drink.Price);
            cmd2.Parameters.AddWithValue("@amount", drink.Amount);
            cmd2.Parameters.AddWithValue("@drinkId", drink.Number);

            conn.Open();

            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();

            conn.Close();
        }

        //inserts an amount of drink into stocks
        public void Insert_Into_Stocks(int drinkID)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO stocks VALUES(10, @drinkID)", conn);

            cmd.Parameters.AddWithValue("@drinkId", drinkID);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();

        }

        //returns a drinkID from the database using drink name
        public int Get_DrinkID(Drink drink)
        {
            int id = -1;

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT drinkID FROM drinks WHERE [name] = @name ORDER BY drinkID DESC", conn);

            cmd.Parameters.AddWithValue("@name", drink.Name);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                id = (int)reader["drinkID"];
            }

            conn.Close();

            return id;
        }
    }
}