using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {

        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {
            try
            {
                if (panelName == "Dashboard")
                {
                    // hide all other panels
                    pnl_Students.Hide();
                    pnl_Rooms.Hide();
                    pnl_Lecturers.Hide();
                    pnl_RevenueReport.Hide();

                    // show dashboard
                    pnl_Dashboard.Show();
                    img_Dashboard.Show();

                    lbl_Dashboard.Font = new Font("Arial", 10, FontStyle.Regular);
                }
                else if (panelName == "Students")
                {
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Lecturers.Hide();
                    pnl_Rooms.Hide();
                    pnl_RevenueReport.Hide();

                    // show students
                    pnl_Students.Show();

                    // fill the students listview within the students panel with a list of students
                    SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                    List<Student> studentList = studService.GetStudents();

                    // clear the listview before filling it again
                    listViewStudents.Clear();
                    listViewStudents.Items.Clear();

                    // adds student columns
                    ColumnHeader columnHeader1 = new ColumnHeader();
                    columnHeader1.Text = "Student ID";

                    ColumnHeader columnHeader2 = new ColumnHeader();
                    columnHeader2.Text = "First Name";

                    ColumnHeader columnHeader3 = new ColumnHeader();
                    columnHeader3.Text = "Last Name";

                    ColumnHeader columnHeader4 = new ColumnHeader();
                    columnHeader4.Text = "Birthdate";

                    listViewStudents.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });

                    listViewStudents.Columns[0].Width = 80;
                    listViewStudents.Columns[1].Width = 100;
                    listViewStudents.Columns[2].Width = 100;
                    listViewStudents.Columns[3].Width = 100;

                    // adds student records to listview
                    foreach (SomerenModel.Student s in studentList)
                    {
                        ListViewItem li = new ListViewItem(s.Number.ToString());
                        li.SubItems.Add(s.Name);
                        li.SubItems.Add(s.LastName);
                        li.SubItems.Add(String.Format
                            ($"{s.BirthDate.Day} / {s.BirthDate.Month} / {s.BirthDate.Year}")); ;
                        listViewStudents.Items.Add(li);
                    }

                    listViewStudents.Font = new Font("Arial", 10, FontStyle.Regular);
                }
                else if (panelName == "Rooms")
                {
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Lecturers.Hide();
                    pnl_RevenueReport.Hide();

                    // show rooms
                    pnl_Rooms.Show();

                    // fill the room listview within the room panel with a list of room
                    SomerenLogic.Room_Service roomService = new SomerenLogic.Room_Service();
                    List<Room> roomList = roomService.GetRooms();

                    // clear the listview before filling it again
                    listViewRooms.Clear();
                    listViewRooms.Items.Clear();

                    //Makes the column headers for the listview
                    ColumnHeader columnHeader1 = new ColumnHeader();
                    columnHeader1.Text = "Room ID";

                    ColumnHeader columnHeader2 = new ColumnHeader();
                    columnHeader2.Text = "Capacity";

                    ColumnHeader columnHeader3 = new ColumnHeader();
                    columnHeader3.Text = "Type";

                    listViewRooms.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });

                    //Makes the column headers have proper width to see the whole title
                    listViewRooms.Columns[0].Width = 70;
                    listViewRooms.Columns[1].Width = 70;
                    listViewRooms.Columns[2].Width = 70;

                    //Adds records of data to the listview
                    foreach (SomerenModel.Room r in roomList)
                    {
                        ListViewItem lvi = new ListViewItem(r.Number.ToString());

                        lvi.SubItems.Add(r.Capacity.ToString());
                        lvi.SubItems.Add(r.StringType);
                        listViewRooms.Items.Add(lvi);
                    }

                    listViewRooms.Font = new Font("Arial", 10, FontStyle.Regular);

                }

                else if (panelName == "Lecturers")
                {
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Rooms.Hide();
                    pnl_RevenueReport.Hide();

                    //show lecturers
                    pnl_Lecturers.Show();

                    // fill the teachers listview within the lecturers panel with a list of teachers
                    SomerenLogic.Teacher_Service tchrService = new SomerenLogic.Teacher_Service();
                    List<Teacher> teacherList = tchrService.GetTeachers();

                    // clear the listview before filling it again
                    ListViewLecturers.Clear();
                    ListViewLecturers.Items.Clear();

                    ColumnHeader teacherID = new ColumnHeader();
                    teacherID.Text = "TeacherID";
                    
                    ColumnHeader firstname = new ColumnHeader();    
                    firstname.Text = "First Name";
                    
                    ColumnHeader lastname = new ColumnHeader();
                    lastname.Text = "Last Name";

                    ColumnHeader supervisor = new ColumnHeader();
                    supervisor.Text = "Supervisor";
                    

                    ListViewLecturers.Columns.AddRange(new ColumnHeader[] { teacherID, firstname, lastname, supervisor });
                    ListViewLecturers.Columns[0].Width = 100;
                    ListViewLecturers.Columns[1].Width = 100;
                    ListViewLecturers.Columns[2].Width = 100;
                    ListViewLecturers.Columns[3].Width = 100;

                    //Adds records of data to the listview
                    foreach (SomerenModel.Teacher teacher in teacherList)
                    {
                        ListViewItem lvi = new ListViewItem(teacher.Number.ToString());
                        lvi.SubItems.Add(teacher.FirstName.ToString());
                        lvi.SubItems.Add(teacher.LastName.ToString());
                        lvi.SubItems.Add(teacher.StringSupervisor.ToString());
                        ListViewLecturers.Items.Add(lvi);
                    }

                    ListViewLecturers.Font = new Font("Arial", 10, FontStyle.Regular);

                }
                else if (panelName == "Revenue Report")
                {
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Rooms.Hide();
                    pnl_Lecturers.Hide();

                    //show revenue report
                    pnl_RevenueReport.Show();

                    DateTime startDate = monthCalendar_StartDate.SelectionRange.Start;
                    DateTime endDate = monthCalendar_EndDate.SelectionRange.Start;

                    //show the list view and all responses
                    show_RevenueReport(startDate, endDate);
                }
            }
            catch (Exception e)
            {
                //Catches exception and shows an error message detailing what went wrong
                MessageBox.Show(e.Message, "SomerenApp Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void img_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Rooms");
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Lecturers");
        }

        private void revenueReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Revenue Report");
        }

        private void btn_RevenueReport_Click(object sender, EventArgs e)
        {
            DateTime startDate = monthCalendar_StartDate.SelectionRange.Start;
            DateTime endDate = monthCalendar_EndDate.SelectionRange.Start;

            //Checks that the start date is before the end date and if the start & enddate are before tomorrow
            if (startDate > endDate)
            {
                lbl_Message.Text = "You inserted an end date before the start date! Please try again.";
            }
            else if (startDate > DateTime.Now || endDate > DateTime.Now)
            {
                lbl_Message.Text = "You inserted the start date and/or the end date in the future! Please try again.";
            }
            else
            {
                lbl_Message.Text = "";

                show_RevenueReport(startDate, endDate);
            }

        }

        //Method to avoid dublication
        //Shows the ListView for the Revenue Report
        public void show_RevenueReport(DateTime startDate, DateTime endDate)
        {
            SomerenLogic.Order_Service orderService = new SomerenLogic.Order_Service();
            orderService.GetRevenueReport(
                startDate, endDate,
                out int amount, out decimal turnover, out int amountCustomers);

            lbl_ListViewRevenueReport.Text = "Revenue Report of: " + startDate.ToString("dd-MM-yyyy") + " to " + endDate.ToString("dd-MM-yyyy");

            // clear the listview before filling it again
            listViewRevenueReport.Clear();
            listViewRevenueReport.Items.Clear();

            ColumnHeader rr_amount = new ColumnHeader();
            rr_amount.Text = "Amount of Drinks";

            ColumnHeader rr_turnover = new ColumnHeader();
            rr_turnover.Text = "Turnover";

            ColumnHeader rr_customers = new ColumnHeader();
            rr_customers.Text = "Amount of Customers";

            listViewRevenueReport.Columns.AddRange(new ColumnHeader[] { rr_amount, rr_turnover, rr_customers });
            listViewRevenueReport.Columns[0].Width = 120;
            listViewRevenueReport.Columns[1].Width = 70;
            listViewRevenueReport.Columns[2].Width = 140;

            //Adds the one record of data to the listview
            ListViewItem lvi = new ListViewItem(amount.ToString());
            lvi.SubItems.Add(turnover.ToString("€0.00"));
            lvi.SubItems.Add(amountCustomers.ToString());
            listViewRevenueReport.Items.Add(lvi);

            listViewRevenueReport.Font = new Font("Arial", 10, FontStyle.Regular);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void label1_Click_2(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void lbl_Message_Click(object sender, EventArgs e)
        {

        }
    }
}
