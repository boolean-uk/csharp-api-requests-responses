namespace exercise.wwwapi
{
    public class Payload<T> where T : class
    {
        public T Data { get; set; } // should return firstname and lastname

    }
}
