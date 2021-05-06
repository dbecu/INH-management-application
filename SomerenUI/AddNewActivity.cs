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

namespace SomerenUI
{
    public partial class AddNewActivity : Form
    {
        public AddNewActivity()
        {
            InitializeComponent();
        }

        private void btn_AddActivity_Click(object sender, EventArgs e)
        {
            //tries to add an activity unless nothing is written
            try
            {
                //creates a new activity object 
                Activity activity = new Activity
                {
                    Description = tb_Description.Text,
                    NrOfStudents = int.Parse(tb_NrOfStudents.Text),
                    NrOfSupervisors = int.Parse(tb_NrOfSupervisors.Text)
                };

                SomerenLogic.Activity_Service activityService = new SomerenLogic.Activity_Service();
                activityService.AddActivity(activity);

                MessageBox.Show("activity added", "SomerenApp",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception excp)
            {
                //catches an exception if nothing is added or if there are incomplete fields.
                string errorMessage = String.Format
                        ($"[{excp.Message}] POPUPNewActivity - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                MessageBox.Show("Cannot add the activity. Make sure every field is filled and then try again.", "SomerenApp",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            finally
            {
                this.Close();
            }
        }
    }
}
