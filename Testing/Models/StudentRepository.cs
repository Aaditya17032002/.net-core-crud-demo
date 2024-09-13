using System.Collections.Generic;
using System.Linq;

namespace Testing.Models
{
    public class StudentRepository : IStudentRepository
    {
        private static List<Student> students = new List<Student>()
        {
            new() { StudentId = 101, Name = "Rohit Sharma", Branch = "CSE", Section = "A", Gender = "Male" },
            new() { StudentId = 102, Name = "Virat Kohli", Branch = "ETC", Section = "B", Gender = "Male" },
            new() { StudentId = 103, Name = "Smriti Mandana", Branch = "CSE", Section = "A", Gender = "Female" },
            new() { StudentId = 104, Name = "Shubham Gill", Branch = "CSE", Section = "A", Gender = "Male" },
            new() { StudentId = 105, Name = "Sara Tendulakar", Branch = "ETC", Section = "B", Gender = "Female" }
        };

        private List<Student> DataSource()
        {
            return students;
        }

        public Student GetStudentById(int studentId)
        {
            return students.FirstOrDefault(e => e.StudentId == studentId) ?? new Student();
        }

        public IEnumerable<Student> GetAllStudentByBranch(string branch)
        {
            return DataSource().Where(e => e.Branch == branch).ToList();
        }
        public Student CreateStudent(string name, string branch, string section, string gender)
        {
            int newId = students.Max(e => e.StudentId) + 1;
            Student newStudent = new Student
            {
                StudentId = newId,
                Name = name,
                Branch = branch,
                Section = section,
                Gender = gender
            };
            students.Add(newStudent);

            return newStudent;
        }

        public Student? UpdateStudentNameById(int studentId, string newName, string newBranch)
        {
            var student = DataSource().FirstOrDefault(e => e.StudentId == studentId);

            if (student != null)
            {
                student.Name = newName;
                student.Branch = newBranch;
                return student;
            }

            return null;
        }

        public bool DeleteStudentById(int studentId)
        {
            var student = DataSource().FirstOrDefault(e => e.StudentId == studentId);

            if (student != null)
            {
                students.Remove(student);
                return true; 
            }

            return false;
        }
    }
}
