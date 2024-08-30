using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        private List<Student> Students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public Student Add(Student student)
        {            
            Students.Add(student);

            return student;
        }

        public List<Student> GetAll()
        {
            return Students.ToList();
        }
        public Student GetA(string firstname) 
        {
            var student = Students.FirstOrDefault(x => x.FirstName == firstname);
            return student;
        }

        public Student Delete(string firstname)
        {
            var student = Students.FirstOrDefault(x =>x.FirstName == firstname);
            Students.Remove(student);
            return student;
        }
        public Student Update(string firstname)
        {
            var student = Students.First();
            Students.Remove(student);
            student.FirstName = firstname;
            Students.Add(student);
            return student;
        }
    };


}
