using SomerenDAL;
using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
                    pnl_Counter.Hide();
                    pnl_Drinks.Hide();
                    pnl_Timetable.Hide();
                    pnl_Activities.Hide();
                    pnl_Supervisors.Hide();


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
                    pnl_Counter.Hide();
                    pnl_Drinks.Hide();
                    pnl_Timetable.Hide();
                    pnl_Activities.Hide();
                    pnl_Supervisors.Hide();


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
                    pnl_Supervisors.Hide();



                    // adds student records to listview
                    foreach (SomerenModel.Student s in studentList)
                    {
                        ListViewItem li = new ListViewItem(s.Number.ToString());
                        li.SubItems.Add(s.Name);
                        li.SubItems.Add(s.LastName);
                        li.SubItems.Add(s.BirthDate.ToString("d - M - yyyy"));
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
                    pnl_Counter.Hide();
                    pnl_Drinks.Hide();
                    pnl_Timetable.Hide();
                    pnl_Activities.Hide();
                    pnl_Supervisors.Hide();


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
                    pnl_Counter.Hide();
                    pnl_Drinks.Hide();
                    pnl_Timetable.Hide();
                    pnl_Activities.Hide();
                    pnl_Supervisors.Hide();


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
                    pnl_Counter.Hide();
                    pnl_Drinks.Hide();
                    pnl_Timetable.Hide();
                    pnl_Activities.Hide();
                    pnl_Supervisors.Hide();


                    //show revenue report
                    pnl_RevenueReport.Show();

                    DateTime startDate = monthCalendar_StartDate.SelectionRange.Start;
                    DateTime endDate = monthCalendar_EndDate.SelectionRange.Start;

                    //show the list view and all responses
                    show_RevenueReport(startDate, endDate);
                }
                else if (panelName == "Counter")
                {
                    //hides all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Lecturers.Hide();
                    pnl_Rooms.Hide();
                    pnl_RevenueReport.Hide();
                    pnl_Drinks.Hide();
                    pnl_Timetable.Hide();
                    pnl_Activities.Hide();
                    pnl_Supervisors.Hide();


                    // shows counter
                    pnl_Counter.Show();

                    SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                    List<Student> studentList = studService.GetStudents();

                    // clear the listview before filling it again
                    students_listView.Clear();
                    students_listView.Items.Clear();

                    ColumnHeader columnHeader1 = new ColumnHeader();
                    columnHeader1.Text = "Student ID";

                    ColumnHeader columnHeader2 = new ColumnHeader();
                    columnHeader2.Text = "Full name";

                    students_listView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });

                    students_listView.Columns[0].Width = 80;
                    students_listView.Columns[1].Width = 120;

                    foreach (SomerenModel.Student s in studentList)
                    {
                        ListViewItem li = new ListViewItem(s.Number.ToString());
                        li.SubItems.Add(s.FullName);
                        students_listView.Items.Add(li);
                    }

                    students_listView.Font = new Font("Arial", 10, FontStyle.Regular);

                    //Loads listView for the drinks
                    show_DrinksList();

                }
                else if (panelName == "Drinks")
                {
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Rooms.Hide();
                    pnl_Lecturers.Hide();
                    pnl_RevenueReport.Hide();
                    pnl_Counter.Hide();
                    pnl_Timetable.Hide();
                    pnl_Activities.Hide();
                    pnl_Supervisors.Hide();

                    //show drinks
                    pnl_Drinks.Show();

                    Show_Drinks();

                }
                else if (panelName == "Timetable")
                {
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Rooms.Hide();
                    pnl_Lecturers.Hide();
                    pnl_RevenueReport.Hide();
                    pnl_Counter.Hide();
                    pnl_Drinks.Hide();
                    pnl_Activities.Hide();
                    pnl_Supervisors.Hide();

                    //show Timetable
                    pnl_Timetable.Show();

                    Show_Timetable();
                }
                else if (panelName == "Activities")
                {
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Rooms.Hide();
                    pnl_Lecturers.Hide();
                    pnl_RevenueReport.Hide();
                    pnl_Counter.Hide();
                    pnl_Drinks.Hide();
                    pnl_Timetable.Hide();
                    pnl_Supervisors.Hide();

                    //show activities
                    pnl_Activities.Show();

                    Show_Activities();

                }
                else if (panelName == "Supervisors")
                {
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Lecturers.Hide();
                    pnl_RevenueReport.Hide();
                    pnl_Counter.Hide();
                    pnl_Drinks.Hide();
                    pnl_Rooms.Hide();
                    pnl_Activities.Hide();
                    pnl_Timetable.Hide();

                    // show supervisors
                    pnl_Supervisors.Show();


                    Show_NON_SupervisorsList();
                    Show_Supervisors();
                }


            }
            catch (Exception e)
            {
                //Catches exception and shows an error message detailing what went wrong
                MessageBox.Show(e.Message, "SomerenApp Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //All the strip menu clicks
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

        private void counterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Counter");
        }

        private void drinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Drinks");
        }

        private void activitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Activities");
        }

        private void supervisorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Supervisors");
        }

        private void timetableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Timetable");
        }


        /////
        //Drinks
        /////

        private void btnNewDrink_Click(object sender, EventArgs e)
        {
            try
            {
                PopupNewDrink popup = new PopupNewDrink();
                popup.ShowDialog();

                Show_Drinks();
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "SomerenApp Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRemoveDrink_Click(object sender, EventArgs e)
        {

            int drinkID = -1;

            try
            {
                drinkID = int.Parse(ListViewDrinks.SelectedItems[0].Text);

            }
            catch (Exception)
            {
                MessageBox.Show("Nothing selected. Please select a drink from the list to remove.", "SomerenApp",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                SomerenLogic.Drink_Service drinkService = new SomerenLogic.Drink_Service();

                if (MessageBox.Show("Are you sure you want to remove the selected drink?", "Remove Drink", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    drinkService.RemoveDrink(drinkID);
                }
                else
                {
                    return;
                }

                Show_Drinks();

            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "SomerenApp Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        //Method to avoid duplication
        public void Show_Drinks()
        {
            // fill the drinks listview within the drinks panel with a list of drinks
            SomerenLogic.Drink_Service drinkService = new SomerenLogic.Drink_Service();
            List<Drink> drinksList = drinkService.GetDrinksWithAmount();

            // clear the listview before filling it again
            ListViewDrinks.Clear();
            ListViewDrinks.Items.Clear();

            ColumnHeader drinkID = new ColumnHeader();
            {
                drinkID.Text = "drinkID";
            }

            ColumnHeader name = new ColumnHeader();
            {
                name.Text = "Drink Name";
            }

            ColumnHeader price = new ColumnHeader();
            {
                price.Text = "Sales price";
            }

            ColumnHeader amount = new ColumnHeader();
            {
                amount.Text = "Amount in Stock";
            }
            
           //displays images for stock amount
            ImageList imgs = new ImageList();
            imgs.ImageSize = new Size(15, 15);

            //gets path of images
            String[] paths;
            paths = Directory.GetFiles("../../../imgs");

            //tries to add the images to image list
            try
            {
                foreach (String path in paths)
                {
                    imgs.Images.Add(Image.FromFile(path));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            //adds column headers to the list view
            ListViewDrinks.Columns.AddRange(new ColumnHeader[] { drinkID, name, price, amount });
            ListViewDrinks.Columns[0].Width = 60;
            ListViewDrinks.Columns[1].Width = 100;
            ListViewDrinks.Columns[2].Width = 100;
            ListViewDrinks.Columns[3].Width = 120;


            //Adds records of data to the listview
            foreach (SomerenModel.Drink drink in drinksList)
            {
                ListViewItem lvi = new ListViewItem(drink.Number.ToString(), drink.Is_Stocked);
                lvi.SubItems.Add(drink.Name.ToString());
                lvi.SubItems.Add(drink.Price.ToString("00.00"));
                lvi.SubItems.Add(drink.Amount.ToString());
                ListViewDrinks.Items.Add(lvi);
            }

            ListViewDrinks.Font = new Font("Arial", 10, FontStyle.Regular);

            ListViewDrinks.SmallImageList = imgs;

        }

        //public object drink so that it can accessed from the popup window
        public static Drink drink_popup;

        //executes when update button is clicked
        private void btnUpdateDrink_Click(object sender, EventArgs e)
        {
            //tries to get the id of the selected drink unless nothing is selected
            try
            {
                drink_popup = new Drink();
                drink_popup.Number = int.Parse(ListViewDrinks.SelectedItems[0].Text);

            }
            catch (Exception)
            {
                MessageBox.Show("Nothing selected. Please select a drink from the list to update.", "SomerenApp",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            //tries to get the properties of selected drink from the list view 
            try
            {
                SomerenLogic.Drink_Service drinkService = new SomerenLogic.Drink_Service();

                drink_popup.Name = ListViewDrinks.SelectedItems[0].SubItems[1].Text;
                drink_popup.Price = decimal.Parse(ListViewDrinks.SelectedItems[0].SubItems[2].Text);
                drink_popup.Amount = int.Parse(ListViewDrinks.SelectedItems[0].SubItems[3].Text);

                PopupUpdateDrink updateDrink = new PopupUpdateDrink();
                updateDrink.ShowDialog();

                Show_Drinks();
            }
            catch (Exception excp)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{excp.Message}] Drink - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will throw excepton that will be caught in the SomerenUI
                throw new Exception("Something went wrong when connecting to the database for drink!");
            }
        }


        /////
        //Revenue Report
        /////

        //executes when revenue report button is clicked
        private void btn_RevenueReport_Click(object sender, EventArgs e)
        {
            try
            {
                //gets dates from calendar
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
            catch (Exception ex)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{ex.Message}] Revenue - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will show error popup
                MessageBox.Show("Something went wrong trying to get your Revenue Report!", "SomerenApp",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Method to avoid duplication, shows the ListView for the Revenue Report
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
            rr_amount.Text = "Amount of Drinks Sold";

            ColumnHeader rr_turnover = new ColumnHeader();
            rr_turnover.Text = "Turnover";

            ColumnHeader rr_customers = new ColumnHeader();
            rr_customers.Text = "Amount of Customers";

            listViewRevenueReport.Columns.AddRange(new ColumnHeader[] { rr_amount, rr_turnover, rr_customers });
            listViewRevenueReport.Columns[0].Width = 150;
            listViewRevenueReport.Columns[1].Width = 70;
            listViewRevenueReport.Columns[2].Width = 140;

            //Adds the one record of data to the listview
            ListViewItem lvi = new ListViewItem(amount.ToString());
            lvi.SubItems.Add(turnover.ToString("€0.00"));
            lvi.SubItems.Add(amountCustomers.ToString());
            listViewRevenueReport.Items.Add(lvi);

            listViewRevenueReport.Font = new Font("Arial", 10, FontStyle.Regular);
        }


        /////
        //Counter
        /////

        //Method to avoid duplication
        public void show_DrinksList()
        {

            // fill the drinks listview within the drinks panel with a list of drinks
            SomerenLogic.Drink_Service drkService = new SomerenLogic.Drink_Service();
            List<Drink> drinkList = drkService.GetDrinks();

            // clear the drink listview before filling it again
            drinks_listView.Clear();
            drinks_listView.Items.Clear();

            //adds drink columns
            ColumnHeader dr_columnHeader1 = new ColumnHeader();
            dr_columnHeader1.Text = "Drink ID";

            ColumnHeader dr_columnHeader2 = new ColumnHeader();
            dr_columnHeader2.Text = "Drinks";

            ColumnHeader dr_columnHeader3 = new ColumnHeader();
            dr_columnHeader3.Text = "Price";

            ColumnHeader dr_columnHeader4 = new ColumnHeader();
            dr_columnHeader4.Text = "Amount in Stock";

            drinks_listView.Columns.AddRange(new ColumnHeader[] { dr_columnHeader1, dr_columnHeader2, dr_columnHeader3, dr_columnHeader4 });

            drinks_listView.Columns[0].Width = 70;
            drinks_listView.Columns[1].Width = 120;
            drinks_listView.Columns[2].Width = 80;
            drinks_listView.Columns[3].Width = 120;

            //adds record of data to the ListView
            foreach (SomerenModel.Drink d in drinkList)
            {
                ListViewItem li = new ListViewItem(d.Number.ToString());
                li.Tag = d;
                li.SubItems.Add(d.Name);
                li.SubItems.Add(d.Price.ToString("0.00"));
                li.SubItems.Add(d.Amount.ToString());
                drinks_listView.Items.Add(li);
            }

            drinks_listView.Font = new Font("Arial", 10, FontStyle.Regular);
        }

        //executes when checkout button is pressed
        private void Checkout_button_Click(object sender, EventArgs e)
        {
            //Calculates total price and changes the amount in stock
            try
            {
                string stu_txt = students_listView.SelectedItems[0].Text;
                int student_count = Convert.ToInt32(stu_txt);

                SomerenLogic.Drink_Service drkService = new SomerenLogic.Drink_Service();

                decimal drink_count = 0;

                foreach (ListViewItem drink_List in drinks_listView.SelectedItems)
                {
                    Drink d = (Drink)drink_List.Tag;
                    drink_count += d.Price;

                    drkService.InsertOrders(student_count, d.Number);

                    drkService.UpdateAmount(d.Number);
                }

                Total_textBox.Text = drink_count.ToString("0.00");

                show_DrinksList();
            }
            catch (Exception)
            {
                //Catches exception and shows an error message detailing what went wrong
                MessageBox.Show("You must SELECT a students and/or at least one drink", "SomerenApp Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /////
        //Timetable
        /////

        // Drag and Drop functionality
        private Rectangle dragBoxFromMouseDown;
        private object valueFromMouseDown;

        //Activates event when mouse is moved on activities datagridview,and outsite it
        private void dataGridView_Activities_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                {
                    // If the mouse moves outside the rectangle, start the drag.
                    if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                    {
                        // Proceed with the drag and drop, passing in the list item.                    
                        DragDropEffects dropEffect = dataGridView_Activities.DoDragDrop(valueFromMouseDown, DragDropEffects.Copy);
                    }
                }
            }
            catch (Exception ex)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{ex.Message}] Timetable drag - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will show error popup
                MessageBox.Show("Something went wrong when you tried to drag an activity", "SomerenApp",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Activated event when slot of the datagrid view is selected in activities grid
        private void dataGridView_Activities_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                // Get the index of the item the mouse is below.
                var hittestInfo = dataGridView_Activities.HitTest(e.X, e.Y);

                if (hittestInfo.RowIndex != -1 && hittestInfo.ColumnIndex != -1)
                {
                    valueFromMouseDown = dataGridView_Activities.Rows[hittestInfo.RowIndex].Cells[hittestInfo.ColumnIndex].Value;
                    if (valueFromMouseDown != null)
                    {
                        // Remember the point where the mouse down occurred. 
                        // The DragSize indicates the size that the mouse can move 
                        // before a drag event should be started.                
                        Size dragSize = SystemInformation.DragSize;

                        // Create a rectangle using the DragSize, with the mouse position being
                        // at the center of the rectangle.
                        dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
                    }
                }
                else
                    // Reset the rectangle if the mouse is not over an item in the ListBox.
                    dragBoxFromMouseDown = Rectangle.Empty;
            }
            catch (Exception ex)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{ex.Message}] Timetable drag - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will show error popup
                MessageBox.Show("Something went wrong when you tried to drag an activity", "SomerenApp",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Drags value from activities to timetable
        private void dataGridView_Timetable_DragOver(object sender, DragEventArgs e)
        {
            try
            {
                e.Effect = DragDropEffects.Copy;
            }
            catch (Exception ex)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{ex.Message}] Timetable drag - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will show error popup
                MessageBox.Show("Something went wrong when you tried to drag an activity", "SomerenApp",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Drops value from activities list to timetable list
        //Will used other method to insert newtimetable record in the database
        private void dataGridView_Timetable_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                // The mouse locations are relative to the screen, so they must be 
                // converted to client coordinates.
                Point clientPoint = dataGridView_Timetable.PointToClient(new Point(e.X, e.Y));

                // If the drag operation was a copy then add the row to the other control.
                if (e.Effect == DragDropEffects.Copy)
                {
                    string cellvalue = e.Data.GetData(typeof(string)) as string;

                    //Arrays to put correct values for the timetable object
                    string test = "";
                    int[] days = { 22, 23, 24, 25, 26, 27, 28 };
                    int[] hours = { 9, 11, 13, 15, 17, 19 };

                    //Slot where value is
                    var hittest = dataGridView_Timetable.HitTest(clientPoint.X, clientPoint.Y);

                    if (hittest.ColumnIndex != -1
                        && hittest.RowIndex != -1)
                    {

                        //If time column or last row, don't do anything
                        if (hittest.ColumnIndex == 0 || hittest.RowIndex == 5)
                            return;

                        dataGridView_Timetable[hittest.ColumnIndex, hittest.RowIndex].Value = cellvalue;
                        dataGridView_Timetable[hittest.ColumnIndex, hittest.RowIndex].Style.ForeColor = Color.Red;

                        test += String.Format($"Added activity '{cellvalue}' for March {days[hittest.ColumnIndex]} at {hours[hittest.RowIndex]}:00");

                        InsertTimetable_UI(cellvalue, days[hittest.ColumnIndex], hours[hittest.RowIndex]);

                    }

                    lbl_test.Text = test;
                }
            }
            catch (Exception ex)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{ex.Message}] Timetable drag - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will show error popup
                MessageBox.Show("Something went wrong when you tried to drag an activity", "SomerenApp",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }



        //Gets information from user to add timetable to the Timetable list and into the database
        private static void InsertTimetable_UI(string activityName, int day, int starttime)
        {
            try
            {
                Activity_Service activity_Service = new Activity_Service();
                List<Activity> activityList = activity_Service.GetAllActivities();

                foreach (Activity activity in activityList)
                {
                    if (activity.Description.Equals(activityName))
                    {
                        Timetable timetable = new Timetable(activity, DateTime.Parse($"2020-03-{day}"),
                            DateTime.Parse($"{starttime}:00:00"), DateTime.Parse($"{starttime + 1}:30:00"));

                        Timetable_Service timetable_Service = new Timetable_Service();
                        timetable_Service.InsertTimetable(timetable);

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{ex.Message}] Timetable InsertTimetable_UI - Something went wrong when connecting to the database & inserting a new record");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                //Will show error popup
                MessageBox.Show("Something went wrong when you tried to add an activity to the timetable", "SomerenApp",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Shows timetable features
        private void Show_Timetable()
        {
            Timetable_Service timetable_Service = new Timetable_Service();
            List<Timetable> timetableList = timetable_Service.GetTimetable();

            Activity_Service activity_Service = new Activity_Service();
            List<Activity> activityList = activity_Service.GetAllActivities();

            dataGridView_Timetable.Rows.Clear();
            dataGridView_Activities.Rows.Clear();

            dataGridView_Timetable.AllowDrop = true;

            for (int i = 9; i < 19; i += 2)
            {
                dataGridView_Timetable.Rows.Add(i.ToString() + ":00");
            }

            int[] days = { 23, 24, 25, 26, 27 };

            int row;
            foreach (Timetable tt in timetableList)
            {
                row = 0;

                for (int i = 9; i < 19; i += 2) //row -> times
                {
                    if (tt.StartTime.Hour == i)
                    {
                        for (int j = 0; j < 5; j++) //column -> days
                        {
                            if (days[j] == tt.Date.Day)
                            {
                                dataGridView_Timetable.Rows[row].Cells[j + 1].Value = tt.Activity.Description;

                                if (tt.Supervisor.Number == 0)
                                    dataGridView_Timetable.Rows[row].Cells[j + 1].Style.ForeColor = Color.Red;

                                break;
                            }
                        }

                        break;
                    }

                    row++;
                }
            }

            foreach (Activity activity in activityList)
                dataGridView_Activities.Rows.Add(activity.Description);


            foreach (DataGridViewColumn c in dataGridView_Activities.Columns)
            {
                c.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            }

            foreach (DataGridViewColumn c in dataGridView_Timetable.Columns)
            {
                c.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            }

            DataGridViewColumn col1 = dataGridView_Timetable.Columns[0];
            DataGridViewColumn col2 = dataGridView_Timetable.Columns[1];
            DataGridViewColumn col3 = dataGridView_Timetable.Columns[2];
            DataGridViewColumn col4 = dataGridView_Timetable.Columns[3];
            DataGridViewColumn col5 = dataGridView_Timetable.Columns[4];
            DataGridViewColumn col6 = dataGridView_Timetable.Columns[5];
            DataGridViewColumn col7 = dataGridView_Activities.Columns[0];

            col1.Width = 100;
            col2.Width = 150;
            col3.Width = 150;
            col4.Width = 150;
            col5.Width = 150;
            col6.Width = 150;
            col7.Width = 150;

        }


        /////
        //Activities
        /////

        //Method to avoid duplication
        //Shows the ListView for the Activities
        public void Show_Activities()
        {
            // fill the activities listview within the activities panel with a list of activities
            SomerenLogic.Activity_Service activityService = new SomerenLogic.Activity_Service();
            List<Activity> activitiesList = activityService.GetAllActivities();

            // clear the listview before filling it again
            ListViewActivities.Clear();
            ListViewActivities.Items.Clear();

            ColumnHeader activityID = new ColumnHeader();
            {
                activityID.Text = "ActivityID";
            }

            ColumnHeader description = new ColumnHeader();
            {
                description.Text = "Description";
            }

            ColumnHeader nrOfStudents = new ColumnHeader();
            {
                nrOfStudents.Text = "Number Of Students";
            }

            ColumnHeader nrOfSupervisors = new ColumnHeader();
            {
                nrOfSupervisors.Text = "Number Of Supervisors";
            }


            //adds column headers to the list view
            ListViewActivities.Columns.AddRange(new ColumnHeader[] { activityID, description, nrOfStudents, nrOfSupervisors });
            ListViewActivities.Columns[0].Width = 70;
            ListViewActivities.Columns[1].Width = 150;
            ListViewActivities.Columns[2].Width = 150;
            ListViewActivities.Columns[3].Width = 150;

            //Adds records of data to the listview
            foreach (SomerenModel.Activity activity in activitiesList)
            {
                ListViewItem lvi = new ListViewItem(activity.Number.ToString());
                lvi.SubItems.Add(activity.Description.ToString());
                lvi.SubItems.Add(activity.NrOfStudents.ToString());
                lvi.SubItems.Add(activity.NrOfSupervisors.ToString());
                ListViewActivities.Items.Add(lvi);
            }

            ListViewActivities.Font = new Font("Arial", 10, FontStyle.Regular);
        }

        private void btn_AddActivity_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewActivity popupNewactivity = new AddNewActivity();
                popupNewactivity.ShowDialog();

                Show_Activities();
            }
            catch (Exception excp)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{excp.Message}] Activity - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                MessageBox.Show("Something went wrong.Please try again later.", "SomerenApp Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        //public properties of activity so that they can be accessed from the popup window

        public static Activity activity_popup;

        //executes when update button is pressed for an activity
        private void btn_ChangeActivity_Click(object sender, EventArgs e)
        {
            //tries to get the id of the selected activity unless nothing is selected
            try
            {
                activity_popup = new Activity();
                activity_popup.Number = int.Parse(ListViewActivities.SelectedItems[0].Text);

            }
            catch (Exception)
            {
                MessageBox.Show("Nothing selected. Please select an activity from the list to update.", "SomerenApp",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            //tries to get the properties of selected activity from the list view 
            try
            {
                activity_popup.Description = ListViewActivities.SelectedItems[0].SubItems[1].Text;
                activity_popup.NrOfStudents = int.Parse(ListViewActivities.SelectedItems[0].SubItems[2].Text);
                activity_popup.NrOfSupervisors = int.Parse(ListViewActivities.SelectedItems[0].SubItems[3].Text);

                ChangeActivity changeActivity = new ChangeActivity();
                changeActivity.ShowDialog();

                Show_Activities();
            }
            catch (Exception excp)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{excp.Message}] Activity - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                MessageBox.Show("Cannot update the activity. Something went wrong.", "SomerenApp",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_RemoveActivity_Click(object sender, EventArgs e)
        {

            int activityID = -1;

            try
            {
                activityID = int.Parse(ListViewActivities.SelectedItems[0].Text);

            }
            catch (Exception)
            {
                MessageBox.Show("Nothing selected. Please select an activity from the list to remove.", "SomerenApp",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                SomerenLogic.Activity_Service activityService = new SomerenLogic.Activity_Service();

                if (MessageBox.Show("Are you sure you want to remove the selected activity?", "Remove Activity", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    activityService.RemoveActivity(activityID);
                }
                else
                {
                    return;
                }


                Show_Activities();

            }
            catch (Exception excp)
            {
                //For the error log and error form
                string errorMessage = String.Format
                    ($"[{excp.Message}] Activity - Something went wrong when connecting to the database.");

                ErrorLog_DAO errorLog_DAO = new ErrorLog_DAO();
                errorLog_DAO.UpdateErrorLog(errorMessage);

                MessageBox.Show("Something went wrong.Please try again later.", "SomerenApp Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /////
        //Supervisor
        /////

        //Shows supervisor features for supervisor panel
        public void Show_Supervisors()
        {
            // fill the supervisor listview within the supervisor panel with a list of supervisor
            SomerenLogic.Supervisor_Service supervisorService = new SomerenLogic.Supervisor_Service();
            List<Supervisor> supervisorList = supervisorService.GetSupervisors();

            // clear the listview before filling it again
            supervisors_listView.Clear();
            supervisors_listView.Items.Clear();

            //Makes the column headers for the listview
            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "SupervisorID";

            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "FirstName";

            ColumnHeader columnHeader3 = new ColumnHeader();
            columnHeader3.Text = "LastName";

            supervisors_listView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });

            //Makes the column headers have proper width to see the whole title
            supervisors_listView.Columns[0].Width = 100;
            supervisors_listView.Columns[1].Width = 100;
            supervisors_listView.Columns[2].Width = 100;

            //Adds records of data to the listview
            foreach (SomerenModel.Supervisor sup in supervisorList)
            {
                ListViewItem lvi = new ListViewItem(sup.Number.ToString());

                lvi.SubItems.Add(sup.FirstName);
                lvi.SubItems.Add(sup.LastName);
                supervisors_listView.Items.Add(lvi);
            }

            supervisors_listView.Font = new Font("Arial", 10, FontStyle.Regular);

        }

        //Shows the non supervisor list of the supervisor panel
        public void Show_NON_SupervisorsList()
        {

            SomerenLogic.Teacher_Service tchrService = new SomerenLogic.Teacher_Service();
            List<Teacher> teacherList = tchrService.Show_nonSupervisors();

            // clear the listview before filling it again
            nonSupervisors_listView.Clear();
            nonSupervisors_listView.Items.Clear();

            ColumnHeader teacherID = new ColumnHeader();
            teacherID.Text = "TeacherID";

            ColumnHeader firstname = new ColumnHeader();
            firstname.Text = "First Name";

            ColumnHeader lastname = new ColumnHeader();
            lastname.Text = "Last Name";


            nonSupervisors_listView.Columns.AddRange(new ColumnHeader[] { teacherID, firstname, lastname });
            nonSupervisors_listView.Columns[0].Width = 100;
            nonSupervisors_listView.Columns[1].Width = 100;
            nonSupervisors_listView.Columns[2].Width = 100;

            //Adds records of data to the listview
            foreach (SomerenModel.Teacher teacher in teacherList)
            {
                ListViewItem lvi = new ListViewItem(teacher.Number.ToString());
                lvi.SubItems.Add(teacher.FirstName.ToString());
                lvi.SubItems.Add(teacher.LastName.ToString());

                nonSupervisors_listView.Items.Add(lvi);
            }
            supervisors_listView.Font = new Font("Arial", 10, FontStyle.Regular);
        }

        //executes when Add supervisor button is pressed
        private void supervisorAdd_btn_Click(object sender, EventArgs e)
        {
            //adds a teacher into supervisors-list
            try
            {
                string teacher = nonSupervisors_listView.SelectedItems[0].Text;
                int teacherID = Convert.ToInt32(teacher);

                SomerenLogic.Teacher_Service tchrService = new SomerenLogic.Teacher_Service();
                tchrService.InsertSupervisors(teacherID);

                Show_NON_SupervisorsList();
                Show_Supervisors();

            }
            catch (Exception)
            {
                //Catches exception and shows an error message detailing what went wrong
                MessageBox.Show("You must SELECT a teacher", "SomerenApp Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //executes when Remove-supervisor-button is pressed
        private void supervisorRemove_btn_Click(object sender, EventArgs e)
        {
            ////removes a teacher from supervisors-list
            try
            {
                string supervisor = supervisors_listView.SelectedItems[0].Text;
                int teacherID = Convert.ToInt32(supervisor);

                SomerenLogic.Supervisor_Service tchrService = new SomerenLogic.Supervisor_Service();

                if (MessageBox.Show("Are you sure that you wish to remove this supervisor?", "Remove Supervisor", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    tchrService.RemoveSupervisor(teacherID);
                }
                else
                {
                    return;
                }

                Show_NON_SupervisorsList();
                Show_Supervisors();
            }
            catch (Exception)
            {
                //Catches exception and shows an error message detailing what went wrong
                MessageBox.Show("You must SELECT a supervisor", "SomerenApp Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

