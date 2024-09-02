
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class StudentRepository
    {
        public Student GetA(string firstName)
        {
            return StudentCollection.GetA(firstName);
        }

        public List<Student> GetAll()
        {
            return StudentCollection.GetAll();
        }

        public Student Create(Student student) 
        {
            return StudentCollection.Create(student);
        }

        public Student Update(string firstName)
        {
            return StudentCollection.Update(firstName);
        }

        public Student Delete(string firstName)
        {
            return StudentCollection.Delete(firstName);
        }
    }
}
