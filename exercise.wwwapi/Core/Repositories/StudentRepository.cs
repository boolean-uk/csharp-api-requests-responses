using exercise.wwwapi.Core.Data;
using exercise.wwwapi.Core.Models;

namespace exercise.wwwapi.Core.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentCollection _studentCollection;

        public StudentRepository()
        {
            _studentCollection = new StudentCollection(); // Initialize the student collection
        }

        public Student AddStudent(Student student)
        {
            return _studentCollection.Add(student);
        }

        public Student GetSingleStudent(string firstName)
        {
            return _studentCollection.getAll().FirstOrDefault(student => student.FirstName.Equals(firstName));
        }

        public IEnumerable<Student> GetStudents()
        {
            return _studentCollection.getAll();
        }

        public bool UpdateStudent(string firstName, Student updatedStudent)
        {
            var student = _studentCollection.getAll().FirstOrDefault(student => student.FirstName.Equals(firstName));
            if (student != null)
            {
                student.FirstName = updatedStudent.FirstName;
                student.LastName = updatedStudent.LastName;
                return true;
            }
            return false;
        }

        public bool DeleteStudent(string firstName)
        {
            var student = _studentCollection.getAll().FirstOrDefault(student => student.FirstName.Equals(firstName));
            if (student != null)
            {
                _studentCollection.Remove(student.FirstName);
                return true;
            }
            return false;
        }
    }
}
