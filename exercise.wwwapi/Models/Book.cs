namespace exercise.wwwapi.Models
{
    public class Book
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; } 
        public string Genre { get; set; }
        public int numPages { get; set; }

        public Book Update(BookPut book)
        {
            this.Title = book.Title;
            this.Author = book.Author;  
            this.Genre = book.Genre;
            this.numPages = book.numPages;
            return this;
        }

    }
}
