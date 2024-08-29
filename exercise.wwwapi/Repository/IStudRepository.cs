using exercise.wwwapi.Models;




// LEGACY CODE, NOT USED
namespace exercise.wwwapi.Repository
{
    public interface IStudRepository
    {
        List<Student> getAll();
        Student Add(Student student);

        Student Update(Student student, string firstname);

        void Delete(string firstname);

        Student Get(string firstname);

    }
}
