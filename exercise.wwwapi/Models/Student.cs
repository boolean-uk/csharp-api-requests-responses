using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.Models
{
    public class Student
    {
      [Key]
      public int Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
    }
}
