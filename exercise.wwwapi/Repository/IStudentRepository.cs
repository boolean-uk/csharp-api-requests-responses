

using exercise.wwwapi.Models;
using exercise.wwwapi.Models.Payload;


namespace exercise.wwwapi.Repository {

    public interface IStudentRepository {

        public List<Student> GetAllStudents();
        public Student AddStudent(string FirstName, string LastName);

        public Student? GetStudent(string FirstName);

        public Student? DeleteStudent(string FirstName);
        public Student? UpdateStudent(string FirstName, StudentUpdatePayload updatePayload);
    }
}