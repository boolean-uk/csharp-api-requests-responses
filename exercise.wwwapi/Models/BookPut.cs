namespace exercise.wwwapi.Models
{
    public class BookPut
    {
        public Guid? id { get; set; }
        public string? title { get; set; }
        public int numPages { get; set; }
        public string? author { get; set; }
        public string? genre { get; set; }
    }
}
