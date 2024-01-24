using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    class StudentRepository : IStudentRepository
    {
        private StudentCollection _students;

        public StudentRepository(StudentCollection students)
        {
            _students = students;
        }

        public Student AddStudent(Student student)
        {
            return _students.Add(student);
        }

        public Student DeleteStudent(string firstName)
        {
            return _students.DeleteStudent(firstName);
        }

        public List<Student> GetAllStudents()
        {
            return _students.getAll();
        }

        public Student GetAStudent(string firstName)
        {
            return _students.GetAStudent(firstName);
        }

        public Student UpdateStudent(string firstName, StudentUpdatePayload updatePayload)
        {
            return _students.UpdateStudent(firstName, updatePayload);
        }
    }
}
