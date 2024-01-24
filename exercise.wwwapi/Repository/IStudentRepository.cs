using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        public List<Student> getAll();

        public Student Add(Student student);

        public Student getAStudent(string firstName);

        public Student updateStudent(string firstName, string newfirstname, string LastName);

        public Student deleteAStudent(string firstName);
    }
}