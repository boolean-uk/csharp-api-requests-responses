
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        public Student AddEntity(Student entity)
        {
            StudentCollection.Add(entity);
            return entity;
        }

        public Student GetAEntity(string firstName)
        {
            //var result = StudentCollection.getAll().FirstOrDefault(x => x.FirstName == firstName);
            var result = StudentCollection.GetA(firstName);
            return result;
        }

        public List<Student> GetEntities()
        {
            return StudentCollection.getAll();
        }

        public Student ChangeAnEntity(Student entity, string search)
        {
            var result = StudentCollection.Change(search, entity);
            return result;
        }
        public string DeleteAnEntity(string search)
        {
            return StudentCollection.Delete(search);
        }
    }


}
