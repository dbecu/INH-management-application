using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SomerenDAL;
using SomerenModel;

namespace SomerenUI
{
    public partial class PopupUpdateDrink : Form
    {
        public PopupUpdateDrink()
        {
            InitializeComponent();
        }

        //creates a new public  object drink so that can be accessed in someren UI
        public Drink drink = new Drink();
        private void btn_UpdateDrink_Click(object sender, EventArgs e)
        {
            //tries to update the drink unless an exception occurs
            try
            {
                SomerenLogic.Drink_Service drinkService = new SomerenLogic.Drink_Service();
                if (MessageBox.Show("Are you sure you want to update the selected drink?", "Update Drink", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    drink.Amount = int.Parse(tb_Amount_Stock.Text);
                    drink.Price = decimal.Parse(tb_Price.Text);
                    drink.Name = tb_Name.Text;
                    drink.Number = SomerenUI.drink_popup.Number;

                    drinkService.UpdateDrink(drink);

                    MessageBox.Show("Drink updated", "SomerenApp",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return;
                }
            }
            catch (Exception excp)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{excp.Message}] POPUPUpdateDrink - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                MessageBox.Show("Please fill in all the fields to update ", "SomerenApp Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }

        //automatically displays the fileds of the selected drink when the popup form loads
        private void PopupUpdateDrink_Load(object sender, EventArgs e)
        {
            tb_Name.Text = SomerenUI.drink_popup.Name;
            tb_Price.Text = SomerenUI.drink_popup.Price.ToString();
            tb_Amount_Stock.Text = SomerenUI.drink_popup.Amount.ToString();
        }
    }
}
