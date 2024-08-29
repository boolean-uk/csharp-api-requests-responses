namespace exercise.wwwapi.Models
{
    public interface IRepository<T> where T : class
    {

        T getElementByName(string name);

        IEnumerable<T> getAll();

        T createElement(T element);

        T deleteElement(string name);

        T updateElement(T element);
    }
}
