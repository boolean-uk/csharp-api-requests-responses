using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        public List<Student> GetStudents();
        public Student AddStudent(StudentCreatePayload studentData);

        public Student GetStudent(string firstName);

        public Student UpdateStudent(string firstName, StudentUpdatePayload updateData);

        public Student DeleteStudent(string firstName);
    }
}
