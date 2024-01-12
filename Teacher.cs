using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherRecordSystem
{
    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ClassAndSection { get; set; }

        public Teacher(int id, string name, string classAndSection)
        {
            ID = id;
            Name = name;
            ClassAndSection = classAndSection;
        }

        public override string ToString()
        {
            return $"{ID},{Name},{ClassAndSection}";
        }
    }

    public static class FileOperations
    {
        private static string filePath = "C:\\Users\\lenovo\\OneDrive\\Desktop\\Project 5\\Teachers.txt";

        public static void AddTeacher(Teacher teacher)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(teacher.ToString());
            }
        }

        public static List<Teacher> ReadTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var data = line.Split(',');
                        teachers.Add(new Teacher(int.Parse(data[0]), data[1], data[2]));
                    }
                }
            }
            return teachers;
        }

        public static void UpdateTeacher(int id, Teacher updatedTeacher)
        {
            List<Teacher> teachers = ReadTeachers();
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var teacher in teachers)
                {
                    if (teacher.ID == id)
                        sw.WriteLine(updatedTeacher.ToString());
                    else
                        sw.WriteLine(teacher.ToString());
                }
            }
        }
    }
}

