using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public interface IRepository
    {
        public void CreateStudent(Student student);
        Student GetStudent(string firstname);
        IEnumerable<Student> GetStudents();
        public void UpdateStudent(string firstname, string newFirstName, string newLastName);
        void DeleteStudent(string firstname);

    }
}
