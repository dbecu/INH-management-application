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

        ErrorForm form;

        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            form = new ErrorForm();
            form.Show();
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {

            if (panelName == "Dashboard")
            {

                // hide all other panels
                pnl_Students.Hide();
                pnl_Rooms.Hide();
                pnl_Lecturers.Hide();


                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            else if(panelName == "Students")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Lecturers.Hide();

                pnl_Rooms.Hide();

                // show students
                pnl_Students.Show();



                // fill the students listview within the students panel with a list of students
                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                List<Student> studentList = studService.GetStudents();

                // clear the listview before filling it again
                listViewStudents.Clear();
                listViewStudents.Items.Clear();

                ColumnHeader columnHeader1 = new ColumnHeader();
                columnHeader1.Text = "Student ID";

                ColumnHeader columnHeader2 = new ColumnHeader();
                columnHeader2.Text = "First Name";

                ColumnHeader columnHeader3 = new ColumnHeader();
                columnHeader3.Text = "Last Name";

                ColumnHeader columnHeader4 = new ColumnHeader();
                columnHeader4.Text = "Birthdate";

                listViewStudents.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });

                listViewStudents.Columns[0].Width = 100;
                listViewStudents.Columns[1].Width = 100;
                listViewStudents.Columns[2].Width = 100;
                listViewStudents.Columns[3].Width = 100;


                foreach (SomerenModel.Student s in studentList)
                {

                    ListViewItem li = new ListViewItem(s.Name);
                    li.SubItems.Add(s.Number.ToString());
                    li.SubItems.Add(s.lastName);
                    li.SubItems.Add(s.BirthDate.ToString());
                    listViewStudents.Items.Add(li);
                }
            }
            else if (panelName == "Rooms")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();

                pnl_Students.Hide();
                pnl_Lecturers.Hide();

                // show rooms
                pnl_Rooms.Show();



                // fill the students listview within the students panel with a list of students
                SomerenLogic.Room_Service roomService = new SomerenLogic.Room_Service();
                List<Room> roomList = roomService.GetRooms();

                // clear the listview before filling it again
                listViewRooms.Clear();
                listViewRooms.Items.Clear();

                ColumnHeader columnHeader1 = new ColumnHeader();
                columnHeader1.Text = "Room ID";

                ColumnHeader columnHeader2 = new ColumnHeader();
                columnHeader2.Text = "Capacity";

                ColumnHeader columnHeader3 = new ColumnHeader();
                columnHeader3.Text = "Type";

                listViewRooms.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });

                listViewRooms.Columns[0].Width = 70;
                listViewRooms.Columns[1].Width = 70;
                listViewRooms.Columns[2].Width = 70;

                foreach (SomerenModel.Room r in roomList)
                {
                    ListViewItem lvi = new ListViewItem(r.Number.ToString());

                    lvi.SubItems.Add(r.Capacity.ToString());
                    lvi.SubItems.Add(r.StringType);
                    listViewRooms.Items.Add(lvi);

                }
            }

            else if (panelName == "Lecturers")
            {

                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();

                pnl_Students.Hide();

                pnl_Rooms.Hide();

                //show lecturers
                pnl_Lecturers.Show();


                // fill the teachers listview within the lecturers panel with a list of teachers
                SomerenLogic.Teacher_Service tchrService = new SomerenLogic.Teacher_Service();
                List<Teacher> teacherList = tchrService.GetTeachers();

                // clear the listview before filling it again
                ListViewLecturers.Clear();
                ListViewLecturers.Items.Clear();

                ColumnHeader teacherID = new ColumnHeader();
                {
                    teacherID.Text = "TeacherID";
                }

                ColumnHeader name = new ColumnHeader();
                {
                    name.Text = "Name";
                }

                ListViewLecturers.Columns.AddRange(new ColumnHeader[] { teacherID, name });
                ListViewLecturers.Columns[0].Width = 70;
                ListViewLecturers.Columns[1].Width = 130;


                foreach (SomerenModel.Teacher teacher in teacherList)
                {
                    ListViewItem lvi = new ListViewItem(teacher.Number.ToString());
                    lvi.SubItems.Add(teacher.FullName.ToString());
                    ListViewLecturers.Items.Add(lvi);

                }

            }


            form.UpdateListBox();
            form.Refresh();
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

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Lecturers");
        }
    }
}
