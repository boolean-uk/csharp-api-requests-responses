using exercise.wwwapi.Models;

namespace exercise.wwwapi.Interfaces
{
    public interface IStudentRepository
    {
        public Student AddStudent(Student student);

        public List<Student> GetAllStudents();

        public Student GetAStudent(string firstname);

        public Student UpdateStudent(string firstname, Student studentValues);

        public void DeleteStudent(string firstname);
    }
}
