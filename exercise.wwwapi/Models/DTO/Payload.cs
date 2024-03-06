namespace exercise.wwwapi.Models.DTO
{
    public class Payload<T> where T : class
    {
        public string status { get; set; } = "success";
        public T data { get; set; }
    }
}
