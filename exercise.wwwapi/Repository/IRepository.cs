using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        IEnumerable<Student> GetStudents();
        Student AddStudent(Student student);
        Student UpdateStudent(int id, StudentPut studentPut);
        bool DeleteStudent(int id);


    }
}
