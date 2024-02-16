namespace exercise.wwwapi.Models
{
    public class Book
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public int? NumPages { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        private static int counter = 0;
        public Book(string title, int numPages, string author, string genre)
        {
            this.Id = counter++;
            this.Title = title;
            this.NumPages = numPages;
            this.Author = author;
            this.Genre = genre;
        }
    }
}
