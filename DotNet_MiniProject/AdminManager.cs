using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet_MiniProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet_MiniProject
{
    class AdminManager
    {
        public static string getUserName()
        {
            StudentAccount studentAccount;
            string userName;
            do
            {
                Console.WriteLine("Enter Username : ");
                userName = Console.ReadLine();
                using (var context = new MyDbContext())
                {
                    studentAccount = context.studentAccounts.SingleOrDefault(s => s.UserName.Equals(userName));
                }
            } while (studentAccount == null);
            return userName;
        }

        public static Student getPassword(string userName)
        {
            string password;
            Student student;
            do
            {
                Console.WriteLine("Please insert password");
                password = Console.ReadLine();

                using (var context = new MyDbContext())
                {
                    student = context.students.SingleOrDefault(s => s.StudentAccount.Password.Equals(password) && s.StudentAccount.UserName.Equals(userName));
                }
            } while (student == null);
            return student;
        }

        public static void createStudent(Student studnt)
        {
            using (var context = new MyDbContext())
            {
                context.students.Add(studnt);
                context.SaveChanges();
                Console.WriteLine("Added Student Successfully !");
            }
        }

        internal static List<Student> getStudents()
        {
            List<Student> students;
            using (var context = new MyDbContext())
            {
                students = context.students.ToList();
            }
            return students;
        }

        internal static void updateStudent(Student student)
        {
            Console.WriteLine("Update Student name:");
            var studentname = Console.ReadLine();
            DateTime DateOfBirth;
            do
            {
                Console.WriteLine("Update birthdate:");
            } while (!DateTime.TryParse(Console.ReadLine(), out DateOfBirth));
            Console.WriteLine("Update Email:");
            var email = Console.ReadLine();
            Console.WriteLine("Update Location : ");
            var location = Console.ReadLine();
            Console.WriteLine("Update Gender : ");
            var gender = Console.ReadLine();
            Console.WriteLine("Update Contact No : ");
            var contactno = Console.ReadLine();

            using (var context = new MyDbContext())
            {
                student = context.students.SingleOrDefault(c => c.StudentID == student.StudentID);
                student.StudentName = studentname;
                student.DateOfBirth = DateOfBirth;
                student.Email = email;
                student.Location = location;
                student.Gender = gender;
                student.ContactNo = contactno;
                context.SaveChanges();
                Console.WriteLine("Data Updateded Successfully !");
            }
        }

        internal static void deleteStudent(Student student)
        {
            using (var context = new MyDbContext())
            {
                context.Entry(student).State = EntityState.Unchanged;
                context.studentAccounts.Remove(context.studentAccounts.SingleOrDefault(sa => sa.StudentID == student.StudentID));
                context.students.Remove(student);
                context.SaveChanges();
                Console.WriteLine("Deleted Student Successfully !");
            }
        }
    }
}
