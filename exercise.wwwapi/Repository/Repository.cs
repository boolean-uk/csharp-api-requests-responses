using exercise.wwwapi.Data;
using exercise.wwwapi.Models;


namespace exercise.wwwapi.Repository
{
    public class Repository<T> : IRepository<T> where T : Student
    {
        private StudentCollection _studentCollection;

        public Repository(StudentCollection studentCollection)
        {
            _studentCollection = studentCollection;
        }

        public T AddEntity(T entity)
        {
            _studentCollection.Add(entity);
            return entity;
        }

        public T DeleteEntity(string name)
        {
            return (T)_studentCollection.Delete(name);
        }

        public List<T> GetCollection()
        {
           
            return _studentCollection.getAll().Cast<T>().ToList();
       
           
        }

        public T GetEntity(string name)
        {
            return (T)_studentCollection.GetStudent(name);
        }

        public T UpdateEntity(string name,string newfirstname,string newlastname)
        {
            return (T)_studentCollection.UpdateStudent(name, newfirstname, newlastname);
        }

        public T UpdateEntity(string name, string newnname)
        {
            throw new NotImplementedException();
        }
    }
}
