using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        private List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public Student Add(Student student)
        {            
            _students.Add(student);

            return student;
        }

        public List<Student> getAll()
        {
            return _students.ToList();
        }

        //New method to replace the name of student
        public Student replaceStudent(string firstname, string newFirstname, string newLastName) 
        {
            foreach (var student in _students) 
            {
                if (student.FirstName == firstname)
                {
                    student.FirstName = newFirstname;
                    student.LastName = newLastName;
                    return student;
                }

            }
            return null;
        }
    };


}
