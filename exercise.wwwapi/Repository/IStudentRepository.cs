using exercise.wwwapi.Models;
namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();
        
        public Student? GetStudent(string name); 

        public Student AddStudent(string firstName, string lastName);

        public Student? UpdateStudent(string name, StudentUpdatePayload studentUpdatePayload);

        public Student? DeleteStudent(string name);

    }
}