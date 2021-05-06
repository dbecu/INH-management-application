using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;

namespace SomerenLogic
{
    public class Drink_Service
    {
        Drink_DAO drink_db = new Drink_DAO();

        //Will return a list of drinks from database using a method from class Drink_DAO
        public List<Drink> GetDrinks()
        {
            //tries to get list of drinks from database unless an exception occurs
            try
            {
                List<Drink> drinks = drink_db.Db_Get_All_Drinks();

                return drinks;
            }
            catch (Exception e)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{e.Message}] Drink - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when connecting to the database for drink!");
            }
        }

        //Will return a list of specific drinks from database using a method from class Drink_DAO
        public List<Drink> GetDrinksWithAmount()
        {
            //tries to get list of drinks from database unless an exception occurs
            try
            {
                List<Drink> drinks = drink_db.Db_Get_Specific_Drinks();

                return drinks;
            }
            catch (Exception e)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{e.Message}] Drink - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when connecting to the database for drink!");
            }
        }

        //Removes a drink from the database using a method from class Drink_DAO
        public void RemoveDrink(int drinkID)
        {
            //tries to remove a drink from the database unless an exception occurs
            try
            {
                drink_db.Remove_Drink(drinkID);
            }
            catch (Exception e)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{e.Message}] Drink - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when connecting to the database for drink!");
            }
        }
        
        //returns the price of the drink from the drink ID
        public decimal GetDrinksPrice(int drinkID)
        {
            //tries to get drinkPrice from database unless an exception occurs
            try
            {
                decimal drinks = drink_db.Db_Get_Price_Of_DrinkID(drinkID);

                return drinks;
            }
            catch (Exception e)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{e.Message}] Drink - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when connecting to the database for drink!");
            }
        }

        //Adds a drink to the database using a method from class Drink_DAO
        public void AddDrink(Drink drink)
        {
            //tries to add a drink to the database unless an exception occurs
            try
            {
                drink_db.Add_Drink(drink);
                int id = drink_db.Get_DrinkID(drink);
                drink_db.Insert_Into_Stocks(id);

            }
            catch (Exception e)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{e.Message}] Drink - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when connecting to the database for drink!");
            }
        }

        //Updates a drink in the database using a method from class Drink_DAO
        public void UpdateDrink(Drink drink)
        {
            //tries to update a drink in the database unless an exception occurs
            try
            {
                drink_db.Update_Drink(drink);
            }
            catch (Exception e)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{e.Message}] Drink - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when connecting to the database for drink!");
            }
        }

        //inserts a drink into orders in database 
        public void InsertOrders(int studentID, int drinkID)
        {
            //tries to insert studentID, drinkId,date into database unless an exception occurs
            try
            {
                drink_db.Db_insert_orders(studentID, drinkID);

            }
            catch (Exception e)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{e.Message}] Order - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when connecting to the database for order!");
            }
        }

        //updates the amount in the database
        public void UpdateAmount(int drinkID)
        {
            //tries to update drinks amount in database unless an exception occurs
            try
            {
                drink_db.Db_Change_Amount(drinkID);

            }
            catch (Exception e)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{e.Message}] Stock - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when connecting to the database for stock!");
            }
        }
    }
}