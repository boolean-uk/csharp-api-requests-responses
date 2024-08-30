namespace exercise.wwwapi.Models;

public class PostBook (string title, int numPages, string author, string genre)
{
    public string Title { get; set; } = title;
    public int NumPages { get; set; } = numPages;
    public string Author { get; set; } = author;
    public string Genre { get; set; } = genre;
}