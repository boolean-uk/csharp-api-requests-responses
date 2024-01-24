namespace exercise.wwwapi.Models
{
    public class CreateBook
    {
        public string Title { get; set; }
        public int NumPages { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        public Book ToBook(int id)
        {
            return new Book()
            {
                Id = id,
                Title = Title,
                NumPages = NumPages,
                Author = Author,
                Genre = Genre
            };

        }
    }
}
