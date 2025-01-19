using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {

        void Add(Student student);
        List<Student> GetAll();
        Student GetStudent(string firstName);
        Student UpdateStudent(string firstname, string newFirstName, string newLastName);
        Student DeleteStudent(string firstname);

    }

}
