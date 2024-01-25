using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public interface IStudentDB
    {
        Student AddToDB(Student student);

        List<Student> GetObjects();
       
        Student UpdateObject(string input);
     

    }
}
