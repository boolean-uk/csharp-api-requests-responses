using exercise.wwwapi.Data;
using exercise.wwwapi.Models.Student;

namespace exercise.wwwapi.Repository
{
    class StudentRepository : IStudentRepo
    {
        private StudentCollection _students;

        public StudentRepository(StudentCollection students)
        {
            _students = students;
        }

        public Student Add(Student student)
        {
            return _students.Add(student);
        }

        public Student Remove(string firstName)
        {
            return _students.DeleteStudent(firstName);
        }

        public List<Student> GetAll()
        {
            return _students.getAll();
        }

        public Student Get(string firstName)
        {
            return _students.GetAStudent(firstName);
        }

        public Student Update(string firstName, StudentPayload updatePayload)
        {
            return _students.UpdateStudent(firstName, updatePayload);
        }
    }
}
