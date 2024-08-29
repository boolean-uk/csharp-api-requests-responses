using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        public List<Student> GetAll()
        {
            return StudentCollection.getAll();
        }

        public Student GetOne(string firstName)
        {
            return StudentCollection.getOne(firstName);
        }
       
        public Student Add(Student student)
        { 
            return StudentCollection.Add(student);
        }

        public Student Update(string firstName, Student student)
        {
            return StudentCollection.Update(firstName, student);
        }

        public Student Delete(string firstName)
        {
            return StudentCollection.Delete(firstName);
        }
    }
}
