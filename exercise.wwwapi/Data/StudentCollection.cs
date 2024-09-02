using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class StudentCollection
    {
        private static List<Student> Students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public static Student Create(Student student)
        {            
            Students.Add(student);
            return student;
        }

        public static List<Student> GetAll()
        {
            return Students.ToList();
        }
        public static Student GetA(string firstname) 
        {
            var student = Students.FirstOrDefault(x => x.FirstName == firstname);
            return student;
        }

        public static Student Delete(string firstname)
        {
            var student = Students.FirstOrDefault(x =>x.FirstName == firstname);
            Students.Remove(student);
            return student;
        }
        public static Student Update(string firstname)
        {
            var student = Students.First();
            Delete(student.FirstName);
            student.FirstName = firstname;
            Create(student);
            return student;
        }
    };


}
