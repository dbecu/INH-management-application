using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SomerenModel;


namespace SomerenDAL
{
    public class Order_DAO : Base
    {
        //does not have a return method, as there are multiple vairables that want to be returned
        //Thus out amount, out turnover and out amountCustomers are used
        public void Db_Get_TurnOver(DateTime startDate, DateTime endDate, out int amount, out decimal turnover, out int amountCustomers)
        {
            conn.Open();
            //changing dates into string for SQL
            string str_startDate = startDate.ToString("yyyy-MM-dd");
            string str_endDate = endDate.ToString("yyyy-MM-dd");

            //SQL query
            SqlCommand cmd = new SqlCommand(
                    "SELECT count(*) AS amount, SUM(drinks.price) AS turnover, count(distinct studentID) AS [amount_customers] " +
                    "FROM orders " +
                        "JOIN drinks ON orders.drinkID = drinks.drinkID " +
                    "WHERE dateOrders BETWEEN @startdate AND @enddate", conn);

            //puts in date variables in the SQL query. Done like this to avoid SQL injection
            cmd.Parameters.AddWithValue("@startdate", str_startDate);  
            cmd.Parameters.AddWithValue("@enddate", str_endDate);

            SqlDataReader reader = cmd.ExecuteReader();

            //Not a while loop because there will only be one record
            if (reader.Read())
            {
                ReadTurnOver(reader, out amount, out turnover, out amountCustomers);
            }
            else  //if not read, then something went wrong
                throw (new Exception());
            
            reader.Close();
            conn.Close();
        }

        //Reads the record and returns them as the out variables
        private void ReadTurnOver(SqlDataReader reader, out int amount, out decimal turnover, out int amountCustomers)
        {
            //In a try catch because if there are no records, it will return null values and decimals cannot be a null value
            //so catch will catch the exception and set everything to 0
            try
            {
                amount = (int)reader["amount"];
                turnover = (decimal)reader["turnover"];
                amountCustomers = (int)reader["amount_customers"];
            }
            catch(Exception)
            {
                amount = 0;
                turnover = 0;
                amountCustomers = 0;
                //throw new Exception(String.Format($"[{e.Message}] - Cannot cast NULL!"));
            }
        }
    }
}
