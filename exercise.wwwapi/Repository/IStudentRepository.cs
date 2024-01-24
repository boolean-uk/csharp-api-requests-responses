using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();

        public Student AddStudent(string firstName, string lastName);

        public Student? GetStudent(int id);

        public Student? UpdateStudent(Student student, StudentUpdatePayload updateData);

        public List<Student> DeleteStudent(int id);
    }
}
