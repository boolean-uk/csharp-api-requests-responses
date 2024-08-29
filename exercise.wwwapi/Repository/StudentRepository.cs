using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IRepository<Student, string>
    {   
        public Student Add(Student entity)
        {
            StudentCollection.Add(entity);
            return entity;
        }

        public Student Delete(string firstname)
        {
            return StudentCollection.Delete(firstname);
        }

        public Student Get(string firstname)
        {
            return StudentCollection.Get(firstname);
        }

        public List<Student> GetAll()
        {
            return StudentCollection.getAll();
        }

        public Student Update(string firstname, Student updated)
        {
            return StudentCollection.Update(firstname, updated);
        }
    }
}