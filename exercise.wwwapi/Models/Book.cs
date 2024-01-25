namespace exercise.wwwapi.Models
{
    public class Book
    {
        private static int _id;
        
        public Book(string name, int numPages, string author, string genre)
        {
            Name = name;
            NumPages = numPages;
            Author = author;
            Genre = genre;
            Id = _id++;
        }

        public int Id { get; }
        public string Name { get; set; }
        public int NumPages { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }


    }
}
