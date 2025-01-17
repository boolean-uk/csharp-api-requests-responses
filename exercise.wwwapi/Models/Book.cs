namespace exercise.wwwapi.Models;

public class Book
{
    public Guid Id { get; private set; }
    public string Title { get; set; }
    public int NumPages { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    
    public Book()
    {
        Id = Guid.NewGuid();
    }
}