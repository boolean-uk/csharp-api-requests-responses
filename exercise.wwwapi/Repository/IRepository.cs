using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T> where T : class
    {
        List<T> GetClasses();
        T AddClass(T entity);

        T GetClass(string firstName);

        T UpdateClass(T newClass, string firstName);

        T DeleteClass(string firstName);

    }
}
