namespace exercise.wwwapi.Models
{

    public enum StudentNameQuerry{
        FirstName,
        LastName
    }


    public class Student
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
    }
}
