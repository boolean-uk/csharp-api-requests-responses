namespace exercise.wwwapi.Models
{
    public class Student : IDatabaseItem
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
