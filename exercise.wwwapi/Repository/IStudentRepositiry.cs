using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepositiry
    {
        public List<Student> GetAllStudents();
        public Student AddStudent(StudentPostPayload payload);
        public Student UpdateStudent(string firstname, StudentPutPayload payload);
        public Student? GetStudent(string firstname);
        public bool DeleteStudent(string firstname);

    }
}
