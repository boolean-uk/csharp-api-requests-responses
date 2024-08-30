namespace exercise.wwwapi
{
    public class Payload<T> where T : class
    {
        public DateTime date { get; set; } = DateTime.Now;

        public T data { get; set; }


    }
}
