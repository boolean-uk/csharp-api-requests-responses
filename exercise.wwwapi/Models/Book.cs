namespace exercise.wwwapi.Models
{
    public class Book : DatabaseItem
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}
