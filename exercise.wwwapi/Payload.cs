using exercise.wwwapi.Models;

namespace exercise.wwwapi
{
    public class Payload<T> where T : class
    {
        public T data { get; set; }
    }
}
