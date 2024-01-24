using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();

        public Student AddStudent(string firstName, string lastName);

        public Student? GetStudent(string firstName);

        public Student? DeleteStudent(string firstName);

        public Student? UpdateStudent(StudentUpdatePayload updateData);
    }
}
