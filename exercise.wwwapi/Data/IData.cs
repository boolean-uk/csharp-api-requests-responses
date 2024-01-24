using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public interface IData
    {

        public IEnumerable<Object> getAll();


        public Object Remove(Object _object);

        public Object Add(Object _object);
    }
}
