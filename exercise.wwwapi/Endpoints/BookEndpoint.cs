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
            books.MapGet("/", GetAllBooks);
            books.MapGet("/{id}", GetBook);
            books.MapPost("/", CreateBook);
            books.MapPut("/{id}", UpdateBook);
            books.MapDelete("/{id}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllBooks(IRepository<Book, int> repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateBook(IRepository<Book, int> repository, Book book)
        {
            Book b = repository.Add(book);
            return TypedResults.Created("/", b);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetBook(IRepository<Book, int> repository, int id)
        {
            Book b = repository.Get(id);
            return b != null ? TypedResults.Ok(b) : TypedResults.NotFound($"Book with id: {id} was not found");
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult UpdateBook(IRepository<Book, int> repository, int id, Book book)
        {
            Book b = repository.Update(id, book);
            return b != null ? TypedResults.Created("/", b) : TypedResults.NotFound($"Book with id: {id} was not found");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult DeleteBook(IRepository<Book, int> repository, int id)
        {
            Book b = repository.Delete(id);
            return b != null ? TypedResults.Ok(b) : TypedResults.NotFound($"Book with id: {id} was not found");
        }
    }
}
