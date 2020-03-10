using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Student_Service
    {
        Student_DAO student_db = new Student_DAO();

        public List<Student> GetStudents()
        {
            try
            {
                List<Student> students = student_db.Db_Get_All_Students();
                return students;
            }
            catch (Exception e)
            {
                string txt = e.Message;
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Student> students = new List<Student>();
                DateTime dt1 = new DateTime(1991 - 06 - 17);
                Student a = new Student(646052, "Mo", "Abou DAher", new DateTime(1991 - 06 - 17));
                students.Add(a);

                DateTime dt2 = new DateTime(1998 - 09 - 29);
                Student b = new Student(648956, "Tamanna", "Abbas", new DateTime(1998 - 09 - 29));
                students.Add(b);

                DateTime dt3 = new DateTime(2000 - 07 - 11);
                Student c = new Student(656552, "Dewi", "Becu", new DateTime(2000 - 07 - 11));
                students.Add(c);


                return students;
                //throw new Exception("Someren couldn't connect to the database");
            }

        }
    }
}

