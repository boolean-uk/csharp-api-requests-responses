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

        public List<Student> GetStudents()
        {
            return _students.Students; 
        }

        public Student AddStudent(StudentCreatePayload studentData)
        {
            return _students.AddStudent(studentData);
        }

        public Student GetStudent(string firstName)
        {
            return _students.GetStudent(firstName);
        }

        public Student UpdateStudent(string firstName, StudentUpdatePayload updateData)
        {
            return _students.UpdateStudent(firstName, updateData);
        }

        public Student DeleteStudent(string firstName)
        {
            return _students.DeleteStudent(firstName);
        }
    }
}
