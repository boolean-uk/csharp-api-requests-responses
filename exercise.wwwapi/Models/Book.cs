namespace exercise.wwwapi.Models
{
    public class Book
    {

        public Book(string name, int numPages, string author, string genre)
        {
            Id++;
            Name = name;
            NumPages = numPages;
            Author = author;
            Genre = genre;
        }

        public int GetId()
        {
            return Id;
        }

        public static int Id { get; set; } = 1;
        public string Name { get; set; }
        public int NumPages { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

    }
}
