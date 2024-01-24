using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();
        public Student AddStudent(StudentPostPayload studentData);

        public Student? GetStudent(string firstName);
        public Student ChangeStudent(string firstName, StudentPostPayload studentData);

        public Student DeleteStudent(string firstName);
    }
}
