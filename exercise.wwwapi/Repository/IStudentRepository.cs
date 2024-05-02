
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository

{
    // the interface with all off the methods for data access
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();
        public Student AddStudent(string firstName, string lastName);
        public Student? GetStudent(string firstName);
        public Student? UpdateStudent(string firstName, StudentUpdatePayload updateStudent);
        public Student DeleteStudent(string firstName);
    }
}
