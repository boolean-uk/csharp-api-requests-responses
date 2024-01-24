namespace exercise.wwwapi.Models
{
  public class Student
  {
      public string FirstName { get; set; }
      public string LastName { get; set; }


     public Student() { }
    public Student(String firstName, String lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public String getFirstName()
    {
        return FirstName;
    }

    public String getLastName()
    {
        return LastName;
    }

    public void rename(String firstName, String lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
  }
}
