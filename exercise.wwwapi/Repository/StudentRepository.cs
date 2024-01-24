using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private IStudentData _studentData;

        public StudentRepository(IStudentData studentData)
        {
            _studentData = studentData;
        }

        public List<Student> GetStudents()
        {
            return _studentData.GetStudents();
        }

        public Student GetStudent(string firstName)
        {
            Student student = _studentData.GetStudent(firstName);

            return student;
        }

    }
}
