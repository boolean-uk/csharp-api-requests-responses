namespace exercise.wwwapi.Models
{
    // the behaviour of a record is exactly the code above. And the c# framework 
    // helps you with a record to not constantly write all this code. properties and constructor
    // behind the scenes the properties will be created. So this is a property and 
    // a constructor in one.
    public record StudentPostPayload(string FirstName, string LastName);

}
