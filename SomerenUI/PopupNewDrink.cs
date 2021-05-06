using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SomerenModel;
using SomerenDAL;
using SomerenLogic;

namespace SomerenUI
{
    public partial class PopupNewDrink : Form
    {

        public PopupNewDrink()
        {
            InitializeComponent();
        }

        private void rbAlcoholic_CheckedChanged(object sender, EventArgs e)
        {
            //automatically displays the VAT (0.21) for alcoholic drinks
            if (rbAlcoholic.Checked == true)
            {
                tbVAT.Text = (0.21).ToString();
            }
        }

        private void btnAddDrink_Click(object sender, EventArgs e)
        {
            //tries to add a drink unless nothing is written
            try
            {
                //creates a new drink object 
                Drink drink = new Drink
                {
                    Price = decimal.Parse(tbPrice.Text),
                    Name = tbName.Text,
                };

                //checks if the drink is alcoholic or non-alcoholic
                if (rbAlcoholic.Checked)
                {
                    drink.Alcoholic = true;
                    drink.VAT = (decimal)0.21;
                }
                else if (rbNonAlcoholic.Checked)
                {
                    drink.Alcoholic = false;
                    drink.VAT = (decimal)0.09;
                }

                SomerenLogic.Drink_Service drinkService = new SomerenLogic.Drink_Service();
                drinkService.AddDrink(drink);

                MessageBox.Show("drink added", "SomerenApp",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception excp)
            {
                //catches an exception if nothing is added or if there are incomplete fields.
                string errorMessage = String.Format
                        ($"[{excp.Message}] POPUPNewDrink - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                MessageBox.Show("Cannot add the drink. Make sure every field is filled and then try again.", "SomerenApp",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }
            finally
            {
                this.Close();
            }
        }

        private void rbNonAlcoholic_CheckedChanged(object sender, EventArgs e)
        {
            //automatically displays the VAT (0.09) for non-alcoholic drinks
            if (rbNonAlcoholic.Checked == true)
            {
                tbVAT.Text = (0.09).ToString();
            }
        }
    }
}

