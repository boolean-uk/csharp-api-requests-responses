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
        public Student CreateAStudent(string firstName, string lastName)
        {
            Student student = new Student() { FirstName = firstName, LastName = lastName };
            _students.Add(student);
            
            return student;
        }

        public Student DeleteAStudent(string firstName)
        {
            Student student = GetAStudent(firstName);
            
            _students.Remove(student);


            return student;
        }

        public List<Student> GetAllStudents()
        {
            return _students.getAll();
        }

        public Student GetAStudent(string firstName)
        {
            Student student = _students.GetStudent(firstName);

            if (student == null)
            {
                return null;
            }
            return student;
        }

        public Student UpdateAStudent(string firstName, StudentUpdateData updateData)
        {
            Student student = DeleteAStudent(firstName);

            student.FirstName = updateData.firstName; 
            student.LastName = updateData.lastName;

            _students.Add(student);

            return student;
        }
    }
}
