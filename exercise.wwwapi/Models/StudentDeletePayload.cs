namespace exercise.wwwapi.Models
{
    // Why to add the StudentId here? 
    public record StudentDeletePayload(string FirstName, string LastName, int StudentId);
}
