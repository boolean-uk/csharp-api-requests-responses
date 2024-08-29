using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        List<Book> GetClasses();
        Book AddClass(PayLoadBook payload);

        Book GetClass(int id);

        Book UpdateClass(PayLoadBook payload, int id);

        Book DeleteClass(int id);

    }
}
