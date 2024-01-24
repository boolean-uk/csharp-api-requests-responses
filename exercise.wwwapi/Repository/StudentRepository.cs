using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private StudentCollection _students;

            public StudentRepository(StudentCollection students)
            {
                _students = students;
            }

            public List<Student> GetAllStudents()
            {
                return _students.getAll();
            }

            public Student AddStudent(StudentPostPayload studentData)
            {
                Student student = new Student();
                student.FirstName = studentData.FirstName;
                student.LastName = studentData.LastName;
                return _students.Add(student);
            }

        public Student? GetStudent(string firstName)
        {
            return _students.Get(firstName);
        }

        public Student ChangeStudent(string firstName, StudentPostPayload studentData)
        {
            return _students.Change(firstName, studentData);
        }

        public Student DeleteStudent(string firstName)
        {
            return _students.Delete(firstName);
        }
        
    }
}
