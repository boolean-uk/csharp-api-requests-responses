using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        public Student AddStudent(Student student);

        public List<Student> GetAllStudents();
        public Student GetAStudent(string firstName);
        public Student UpdateStudent(string firstName, StudentUpdatePayload updatePayload);
        public Student DeleteStudent(string firstName);
    }
}
