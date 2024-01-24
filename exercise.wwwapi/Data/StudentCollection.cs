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

        public List<Student> GetAllStudents()
        {
            return _students.ToList();
        }

        public Student GetStudent(string firstName)
        {
            return _students.FirstOrDefault(t => t.FirstName == firstName);
        }

        public Student UpdateStudent(string nameToUpdate, Student newValues)
        {
            var stud = GetStudent(nameToUpdate);
            stud.FirstName = newValues.FirstName;
            stud.LastName = newValues.LastName;

            return stud;
        }

        public Student RemoveStudent(string firstName, string lastName)
        {
            Student studToRemove = new Student();
            foreach(var student in _students)
            {
                if(student.FirstName == firstName && student.LastName == lastName)
                {
                    studToRemove = student;
                    break;
                }
            }
            _students.Remove(studToRemove);

            return studToRemove;
        }

    };


}
