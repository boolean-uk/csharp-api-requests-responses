using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;


namespace exercise.wwwapi.Endpoints
{
    public static class BooksEndpoint
    {
        public static void ConfigureBookEndpoint (this WebApplication app)
        {
            var books = app.MapGroup("books");
            books.MapPost("/", CreateBook);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateBook(IBookRepository bookRepository, Book book)
        {
            bookRepository.AddBook(book);
            return TypedResults.Ok(book);
        }
    }
}
