namespace exercise.wwwapi.Models
{
    public class Book : IComplex
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; set; }
        public int NumPages { get; set; }  
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}
