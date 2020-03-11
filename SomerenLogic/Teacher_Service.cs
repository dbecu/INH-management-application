using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;
using SomerenDAL;

namespace SomerenLogic
{
    public class Teacher_Service
    {
        Teacher_DAO teacher_db = new Teacher_DAO();

        public List<Teacher> GetTeachers()
        {
            try
            {
                List<Teacher> teacher = teacher_db.Db_Get_All_Teachers();
                return teacher;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Teacher> teachers = new List<Teacher>();

                Teacher t1 = new Teacher(); //creating teacher object 1
                t1.FirstName = "Test";
                t1.LastName = "Teacher1";
                t1.Number = 564546;
                teachers.Add(t1);

                Teacher t2 = new Teacher(); //creating teacher object 2
                t2.FirstName = "Test";
                t2.LastName = "Teacher2";
                t2.Number = 459745;
                teachers.Add(t2);

                return teachers; //adding objects to the list
                //throw new Exception("Someren couldn't connect to the database");

            }

        }
    }
}