using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public interface IDatabase<T> where T : DatabaseItem
    {
        public List<T> Data { get; set; }
    }
}
