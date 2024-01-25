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

        public Student AddStudent(Student student)
        {
            return _studentData.AddStudent(student);
        }

        public Student UpdateStudent(string firstName, StudentPut student)
        {
            var foundStudent = _studentData.GetStudent(firstName);
            if(foundStudent == null)
            {
                return null;
            }
            foundStudent.FirstName = student.FirstName;
            foundStudent.LastName = student.LastName;
            return foundStudent;
        }

        public Student DeleteStudent(string firstName)
        {
            return _studentData.DeleteStudent(firstName);
        }
    }
}
