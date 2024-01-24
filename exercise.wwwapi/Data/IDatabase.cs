using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public interface IDatabase<T>
    {
        public IEnumerable<T> Data { get; set; }
    }
}
