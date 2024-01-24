using exercise.wwwapi.Models;
using exercise.wwwapi.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;

namespace exercise.wwwapi.Repository
{
    public interface IBookRepository
    {
        Book Create(API_book book);
        List<Book> GetAllBooks();
        Book getBook(int id);

        Book Update(int id, API_book book);
        Book Delete(int id);
    }
}
