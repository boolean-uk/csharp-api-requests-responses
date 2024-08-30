using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {

        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var books = app.MapGroup("books");
            books.MapGet("/GetAll", GetAllBooks);
            books.MapPost("/CreateBook",CreateBook);
            books.MapGet("/GetBook", GetBook);
            books.MapPut("/UpdateBook", UpdateBook);
            books.MapDelete("/DeleteBook", DeleteBook);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllBooks(IBook<Book> repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateBook(IBook<Book> repository, Book book)
        {
            return TypedResults.Ok(repository.Add(book));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetBook(IBook<Book> repository, int id)
        {
            return TypedResults.Ok(repository.Get(id));
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateBook(IBook<Book> repository, Book newBook, int id)
        {
            return TypedResults.Ok(repository.Update(newBook, id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteBook(IBook<Book> repository, int id)
        {
            return TypedResults.Ok(repository.Delete(id));
        }
    }
}
