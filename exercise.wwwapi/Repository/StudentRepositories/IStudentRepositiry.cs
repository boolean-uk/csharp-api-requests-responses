using exercise.wwwapi.Models.Student;

namespace exercise.wwwapi.Repository.StudentRepositories
{
    public interface IStudentRepositiry
    {
        public List<Student> GetAllStudents();
        public Student AddStudent(StudentPostPayload payload);
        public Student UpdateStudent(string firstname, StudentPutPayload payload);
        public Student GetStudent(string firstname);
        public bool DeleteStudent(string firstname);

    }
}
