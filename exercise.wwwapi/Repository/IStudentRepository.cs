using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        public Student CreateAStudent(string firstName, string lastName);

        public List<Student> GetAllStudents();

        public Student? GetAStudent(string firstName);

        public Student? UpdateAStudent(string firstName, StudentUpdateData updateData);

        public Student DeleteAStudent(string firstName);
    }
}
