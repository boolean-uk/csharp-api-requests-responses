namespace exercise.wwwapi.ViewModels
{
    public record StudentPost(string FirstName, string LastName);
    public record StudentPut(string? FirstName, string? LastName);
}
