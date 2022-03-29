using System;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using DotNet_MiniProject.Models;

namespace DotNet_MiniProject
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (MainView.login())
            {
                case (int)User.Exit:

                    Environment.Exit(0);
                    break;

                case (int)User.Registration:
                    {
                        StudentManager.registerStudent();
                        break;
                    }

                case (int)User.Student:

                    string studentUserName = StudentManager.getUserName();

                    Student student = StudentManager.getPassword(studentUserName);

                    do
                    {
                        START:
                        switch (StudentView.menu())
                        {
                            case (int)StudentQuery.Exit:

                                Environment.Exit(0);
                                break;

                           

                            case (int)StudentQuery.EnterDetails:

                                //var newCourses = StudentManager.createStudent(student);
                                //if (newCourses.Count != 0)
                                //{
                                //    var enrollInput = StudentView.enrollMenu(newCourses);
                                //    var newCourseID = newCourses[enrollInput].Id;
                                //    StudentManager.enrollStudent(student, newCourseID);
                                //}
                                //else StudentView.enrollFail();
                                //break;

                                StudentManager.createStudent(StudentView.createStudent());
                                break;

                            case (int)StudentQuery.Update:
                                {
                                    var students = StudentManager.getStudents();
                                    var studentInput = StudentView.studentMenu(students);
                                    StudentManager.updateStudent(students[studentInput]);
                                }
                                break;

                            case (int)StudentQuery.Delete:
                                {
                                    var students = StudentManager.getStudents();
                                    var studentInput = StudentView.studentMenu(students);
                                    StudentManager.deleteStudent(students[studentInput]);
                                }
                                break;

                            case (int)StudentQuery.Show:
                                {
                                    StudentView.showStudents(StudentManager.getStudents());
                                }
                                break;

                            case (int)StudentQuery.MainMenu:
                                {
                                    goto START;
                                }
                                break;
                                //case (int)StudentQuery.Schedule:

                                //    var currentCourses = StudentManager.getCurrentCourses(student);
                                //    StudentView.showSchedule(currentCourses);
                                //    break;

                                //case (int)StudentQuery.SubmissionDates:

                                //    var currentAssignments = StudentManager.getCurrentAssignments(student);
                                //    StudentView.showSubmissionDates(currentAssignments);
                                //    break;
                        }
                    } while (true);
                    case (int) User.Admin:
                    string adminName = AdminManager.getUserName();
                    AdminManager.getPassword(adminName);

                    do
                    {
                    START:
                        switch (AdminView.menu())
                        {
                            case (int)AdminQuery.Exit:

                                Environment.Exit(0);
                                break;



                            case (int)AdminQuery.EnterDetails:
                                AdminManager.createStudent(AdminView.createStudent());
                                break;


                            case (int)AdminQuery.Update:
                                {
                                    var students = AdminManager.getStudents();
                                    var studentInput = AdminView.studentMenu(students);
                                    AdminManager.updateStudent(students[studentInput]);
                                }
                                break;

                            case (int)AdminQuery.Delete:
                                {
                                    AdminView.showStudents(AdminManager.getStudents());
                                }
                                break;
                            case (int)AdminQuery.MainMenu:
                                goto START;
                                break;
                        }
                    } while (true);

                    break;
            }

        }

    }
    class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = RUSHIKESHC-VD\\SQL2017; Database =StudentManagement; User ID = sa; Password = cybage@123456");

        }


        
        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses{ get; set; }
        public DbSet<Role> roles { get; set; }
        //public DbSet<Teacher> teachers { get; set; }
        public DbSet<StudentAccount> studentAccounts { get; set; }
        //public DbSet<Admin> dmins { get; set; }

    }

    internal enum User
    { Exit, Registration, Student, Admin }
    internal enum StudentQuery
    { Exit, EnterDetails, Update, Delete, Show, MainMenu }
   
    internal enum AdminQuery
    { Exit, EnterDetails, Update, Delete, Show, MainMenu }
}
