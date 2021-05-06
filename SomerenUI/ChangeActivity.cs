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
using SomerenUI;

namespace SomerenUI
{
    public partial class ChangeActivity : Form
    {
        public ChangeActivity()
        {
            InitializeComponent();
        }

        public Activity activity = new Activity();
        private void btn_UpdateActivity_Click(object sender, EventArgs e)
        {
            //tries to update the activity unless an exception occurs
            try
            {
                SomerenLogic.Activity_Service activityService = new SomerenLogic.Activity_Service();
                if (MessageBox.Show("Are you sure you want to update the selected activity?", "Update Activity", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    activity.Number = SomerenUI.activity_popup.Number;
                    activity.Description = tb_Description.Text;
                    activity.NrOfStudents = int.Parse(tb_NrOfStudents.Text);
                    activity.NrOfSupervisors = int.Parse(tb_NrOfSupervisors.Text);

                    activityService.UpdateActivity(activity);

                    MessageBox.Show("activity updated", "SomerenApp",
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
                    ($"[{excp.Message}] POPUPUpdateActivity - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                MessageBox.Show("Something went wrong while updating.", "SomerenApp Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }

        //automatically displays the fields of the selected activity when the popup form loads
        private void ChangeActivity_Load(object sender, EventArgs e)
        {
            tb_Description.Text = SomerenUI.activity_popup.Description;
            tb_NrOfStudents.Text = SomerenUI.activity_popup.NrOfStudents.ToString();
            tb_NrOfSupervisors.Text = SomerenUI.activity_popup.NrOfSupervisors.ToString();
        }
    }
}
