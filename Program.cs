using System;
using System.Collections.Generic;
using System.IO;

namespace MiniProject
{

    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Grade { get; set; }

        public override string ToString()
        {
            return $"{Name}, Age: {Age}, Grade: {Grade}";
        }
    }

    class Program
    {
        static void Main()
        {
            List<Student> students = new List<Student>();


            string filePath = "C:\\Users\\venka\\OneDrive\\Desktop\\simplIlearn\\Day-19";
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        string name = parts[0].Trim();
                        int age = int.Parse(parts[1].Trim());
                        string grade = parts[2].Trim();

                        students.Add(new Student { Name = name, Age = age, Grade = grade });
                    }
                }
            }
            else
            {
                Console.WriteLine("Student data file not found!");
                return;
            }

            
            students.Sort((s1, s2) => string.Compare(s1.Name, s2.Name));

            
            Console.WriteLine("All Students:");
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }

            
            Console.Write("Enter the name of the student to search: ");
            string searchName = Console.ReadLine();

            List<Student> searchResults = students.FindAll(s => s.Name.ToLower().Contains(searchName.ToLower()));

            if (searchResults.Count > 0)
            {
                Console.WriteLine("Search Results:");
                foreach (Student student in searchResults)
                {
                    Console.WriteLine(student);
                }
            }
            else
            {
                Console.WriteLine("No students found with the given name.");
            }
            Console.ReadKey();
        }
    }
}

