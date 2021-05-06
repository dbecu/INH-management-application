using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;

namespace SomerenLogic
{
    public class Order_Service
    {
        Order_DAO order_db = new Order_DAO();

        //returns amount turnover and amount of customers from database
        public void GetRevenueReport(DateTime startDate, DateTime endDate, out int amount, out decimal turnover, out int amountCustomers)
        {
            //tries to get list of rooms from database unless an exception occurs
            try
            {
                order_db.Db_Get_TurnOver(startDate, endDate, out amount, out turnover, out amountCustomers);
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
    }
}
