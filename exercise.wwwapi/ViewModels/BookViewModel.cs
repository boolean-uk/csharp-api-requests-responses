namespace exercise.wwwapi.ViewModels
{
    public record BookPost(string Author, string Title, string Genre, int numPages);
    public record BookPut(string Author, string Title, string Genre, int? numPages);
}
