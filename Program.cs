using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherRecordSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nTeacher Record System");
                Console.WriteLine("1.Add Teacher");
                Console.WriteLine("2.Display Teachers");
                Console.WriteLine("3.Update Teacher");
                Console.WriteLine("4.Exit");
                Console.WriteLine("Select an option:");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddTeacher();
                        break;
                    case 2:
                        DisplayTeachers();
                        break;
                    case 3:
                        UpdateTeacher();
                        break;
                    case 4:
                        running = false;
                        break;
                }
            }
        }

        private static void AddTeacher()
        {
            Console.Write("Enter Teacher ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Teacher Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Class and Section: ");
            string classAndSection = Console.ReadLine();

            Teacher teacher = new Teacher(id, name, classAndSection);
            FileOperations.AddTeacher(teacher);
        }

        private static void DisplayTeachers()
        {
            List<Teacher> teachers = FileOperations.ReadTeachers();
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"{teacher.ID}, {teacher.Name}, {teacher.ClassAndSection}");
            }
        }

        private static void UpdateTeacher()
        {
            Console.Write("Enter the ID of the teacher to update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Updated Teacher Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Updated Class and Section: ");
            string classAndSection = Console.ReadLine();

            Teacher updatedTeacher = new Teacher(id, name, classAndSection);
            FileOperations.UpdateTeacher(id, updatedTeacher);
        }
    }
}


   
