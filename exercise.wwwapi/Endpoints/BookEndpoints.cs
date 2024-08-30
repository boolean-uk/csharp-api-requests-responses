using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        public static void ConfigureBookEndpoints(this WebApplication app)
        {
            var books = app.MapGroup("books");
            books.MapPost("/", AddBook);
            books.MapGet("/", GetBooks);
            books.MapGet("/{id}", GetABook);
            books.MapPut("/{id}", UpdateBook);
            books.MapDelete("/{id}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetBooks(IRepository<Book, int> repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddBook(IRepository<Book, int> repository, Book entity)
        {
            Book book = repository.Add(entity);
            return TypedResults.Created("$/books", book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetABook(IRepository<Book, int> repository, int id)
        {
            Book book = repository.GetOne(id);
            return book != null ? TypedResults.Ok(book) : TypedResults.NotFound();
        }
            
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateBook(IRepository<Book, int> repository, int id, Book entity)
        {
            Payload<Book> payload = new Payload<Book>();
            Book book = repository.Update(id, entity);
            return book != null ? TypedResults.Created("$/books", book) : TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteBook(IRepository<Book, int> repository, int id)
        {
            Book book= repository.Delete(id);
            return book != null ? TypedResults.Ok(book) : TypedResults.NotFound();
        }

    }
}
