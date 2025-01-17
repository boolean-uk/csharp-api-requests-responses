namespace exercise.wwwapi.Models
{
    public interface IBase
    {
        public int Id { get; set; }
    }

    public interface IComplex
    {
        public Guid Id { get; }
    }
}
