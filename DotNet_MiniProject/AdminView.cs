using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet_MiniProject.Models;

namespace DotNet_MiniProject
{
    class AdminView
    {
        public static int menu()
        {
            int userInput;
            do
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("                                          MENU");
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("Press 0 to Exit Application");
                Console.WriteLine("Press 1 to Enter Student Deatils");
                Console.WriteLine("Press 2 to Update Student Deatils");
                Console.WriteLine("Press 3 to Delete Student Deatils");
                Console.WriteLine("Press 4 to Show Student Deatils");
                Console.WriteLine("Press 5 for Back to Main Menu");
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }

        internal static Student createStudent()
        {
            Console.WriteLine("Enter Student name:");
            var studentname = Console.ReadLine();
            DateTime DateOfBirth;
            do
            {
                Console.WriteLine("Enter birthdate:");
            } while (!DateTime.TryParse(Console.ReadLine(), out DateOfBirth));
            Console.WriteLine("Enter Email:");
            var email = Console.ReadLine();
            Console.WriteLine("Enter Location : ");
            var location = Console.ReadLine();
            Console.WriteLine("Enter Gender : ");
            var gender = Console.ReadLine();
            Console.WriteLine("Enter Contact No : ");
            var contactno = Console.ReadLine();
            Student studnt = new Student { StudentName = studentname, DateOfBirth = DateOfBirth, Email = email, Location = location, Gender = gender, ContactNo = contactno };

            return studnt;
        }

        internal static void showStudents(List<Student> students)
        {
            using (var context = new MyDbContext())
            {
                foreach (var s in students)
                {
                    Console.WriteLine(s.ToString());
                }
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
        }

        internal static int studentMenu(List<Student> students)
        {
            int userInput;
            do
            {
                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine($"Press {i} to update/delete student: {students[i].ToString()}");
                }
            } while (!int.TryParse(Console.ReadLine(), out userInput));
            return userInput;
        }
    }
}
