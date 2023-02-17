using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AnropaDB.Models;
using System.Threading;

namespace AnropaDB
{
    public static class User
    {
        public static void Menu()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("1.Show all students.");
            Console.WriteLine("2.Show students in particular class.");
            Console.WriteLine("3.Add new staff member.");
            Console.WriteLine("4.Show all teachers");
            Console.WriteLine("5.Show information about students");
            Console.WriteLine("6.Show Courses");
            Console.WriteLine("7.Log Out");
            Console.WriteLine("Choose: ");
            int choice;
            bool parseSuccess;
            parseSuccess = int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    ShowStudents();
                    break;
                case 2:
                    Console.Clear();
                    ShowClassAndStudents();
                    break;
                case 3:
                    Console.Clear();
                    AddNewStaff();
                    break;
                case 4:
                    Console.Clear();
                    ShowTeachers();
                    break;
                case 5:
                    Console.Clear();
                    ShowInformationAboutAllStudents();
                    break;
                case 6:
                    ShowCourses();
                    break;
                case 7:
                    Thread.Sleep(200);
                    break;
                default:
                    Console.WriteLine("Invalid choice!Please write a number between 1-3");
                    break;
            }
        }
        public static void ShowStudents()
        {
            SchoolDbContext context = new SchoolDbContext();
            Console.WriteLine("1.Order students by first name");
            Console.WriteLine("2.Order students by last name");
            Console.WriteLine("Choose: ");
            int userChoice;
            bool parse;
            parse = int.TryParse(Console.ReadLine(), out userChoice);
            if (userChoice == 1 || userChoice == 2)
            {
                Console.WriteLine("Sort by: ");
                Console.WriteLine("1.Ascending");
                Console.WriteLine("2.Descending");
                int userChoice2;
                bool parse2;
                parse2 = int.TryParse(Console.ReadLine(), out userChoice2);
                Console.Clear();
                if (userChoice == 1 && userChoice2 == 1)
                {
                    var Student = from student in context.Student
                                  where student.StudentId > 0
                                  orderby student.Fname ascending
                                  select student;
                    foreach (var item in Student)
                    {
                        Console.WriteLine("{0} {1} ", item.Fname, item.Lname);
                    }
                }
                else if (userChoice == 1 && userChoice2 == 2)
                {
                    var Student = from student in context.Student
                                  where student.StudentId > 0
                                  orderby student.Fname descending
                                  select student;
                    foreach (var item in Student)
                    {
                        Console.WriteLine("{0} {1} ", item.Fname, item.Lname);
                    }
                }
                if (userChoice == 2 && userChoice2 == 1)
                {
                    var Student = from student in context.Student
                                  where student.StudentId > 0
                                  orderby student.Lname ascending
                                  select student;
                    foreach (var item in Student)
                    {
                        Console.WriteLine("{0} {1} ", item.Lname, item.Fname);
                    }
                }
                else if (userChoice == 2 && userChoice2 == 2)
                {
                    var Student = from student in context.Student
                                  where student.StudentId > 0
                                  orderby student.Lname descending
                                  select student;
                    foreach (var item in Student)
                    {
                        Console.WriteLine("{0} {1} ", item.Lname, item.Fname);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again!");
            }
            Console.WriteLine("Press a key to return to login menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        public static void ShowClassAndStudents()
        {
            SchoolDbContext context = new SchoolDbContext();
            var Class = context.Class
                        .Where(x => x.ClassId > 0)
                        .OrderBy(x => x.ClassId);
            foreach (var item in Class)
            {
                Console.WriteLine($"ID: {item.ClassId} Class: {item.ClassName}");
            }
            Console.WriteLine("From which class do you want to see information");
            bool parsesucces;
            int classChoice;
            if (parsesucces = int.TryParse(Console.ReadLine(), out classChoice))
            {
                var ClassStudent = context.Student
                    .Where(x => x.ClassId == classChoice);
                foreach (var item in ClassStudent)
                {
                    Console.WriteLine($"Student: {item.Fname} {item.Lname} with ID: {item.StudentId} ");
                }

            }
            Console.WriteLine("Press a key to return to login menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        public static void AddNewStaff()
        {
            SchoolDbContext context = new SchoolDbContext();
            bool staffparse;
            Console.WriteLine("Staff Id: ");
            int staffidChoice;
            staffparse = int.TryParse(Console.ReadLine(), out staffidChoice);

            Console.WriteLine("Name: ");
            string Fname = Console.ReadLine();
            Console.WriteLine("Last name: ");
            string Lname = Console.ReadLine();
            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Role: ");
            string Role = Console.ReadLine();

            var staff = new Staff()
            {
                StaffId = staffidChoice,
                Fname = Fname,
                Lname = Lname,
                Email = email,
                Role = Role
            };
            context.Staff.Add(staff);
            context.SaveChanges();
            Console.WriteLine("Staff member successfully added");

            foreach (var item in context.Staff)
            {
                Console.WriteLine("{0} {1} {2} {3} ", item.Fname, item.Lname, item.Email, item.Role);
            }
            Console.WriteLine("Press a key to return to login menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        public static void ShowTeachers()
        {
            SchoolDbContext context = new SchoolDbContext();
            var Staff = from staff in context.Staff
                        where staff.Role == "Teacher"
                        select staff;
            foreach (var item in Staff)
            {
                Console.WriteLine($"{item.Fname} {item.Lname} {item.Role}");
            }
            Console.WriteLine("Press a key to return to login menu");
            Console.ReadKey();
            Console.Clear();
            Menu();


        }
        public static void ShowInformationAboutAllStudents()
        {
            SchoolDbContext context = new SchoolDbContext();

            var student = (from grd in context.Grade

                           join stu in context.Student
                           on grd.StudentId equals stu.StudentId
                           join cls in context.Class
                           on stu.ClassId equals cls.ClassId
                           join crs in context.Course
                           on grd.CourseId equals crs.CourseId
                           select new
                           {
                               studentName = stu.Fname,
                               studentLName = stu.Lname,
                               sclass = cls.ClassName,
                               scourse = crs.CourseName,
                               sgrade = grd.Grades

                           }).ToList();
            foreach (var item in student)
            {
                Console.WriteLine($" Student: {item.studentName} {item.studentLName}Class:  {item.sclass},       Course: {item.scourse}          Grade:{item.sgrade}");
            }
            Console.ReadLine();
            Console.WriteLine("Press a key to return to login menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        public static void ShowCourses()
        {
            SchoolDbContext context = new SchoolDbContext();
            var course = from Course in context.Course
                         where Course.CourseId > 0
                         orderby Course.CourseName
                         select Course;
            foreach (var item in course)
            {
                Console.WriteLine($"Course Name: {item.CourseName}");
            }
            Console.WriteLine("Press a key to return to login menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
    }
}
