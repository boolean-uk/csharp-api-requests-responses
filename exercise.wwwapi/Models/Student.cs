namespace exercise.wwwapi.Models
{
    public class Student
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      

      public bool Equals(Student s)
    {
      return FirstName == s.FirstName; //Search criteria for the exercise
    }

    public void Update(Student s)
    {
      FirstName = s.FirstName;
      LastName = s.LastName;
    }
    }

    
}
