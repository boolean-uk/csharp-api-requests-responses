namespace exercise.wwwapi.Models
{
    public class InternalBook
    {
        private static int nextId = 1;
        public int Id { get; set; }
        public string Title { get; set; }
        public int NumPages { get; set; }
        public string Author { get; set; }
        public string Genre {  get; set; }

        public InternalBook(string title, int numPages, string author, string genre)
        {
            Id = nextId++;
            Title = title;
            NumPages = numPages;
            Author = author;
            Genre = genre;
        }
    }
}
