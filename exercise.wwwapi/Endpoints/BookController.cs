using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace exercise.wwwapi.Endpoints
{
    [ApiController]
    [Route("books")]
    public static class BookController
    {
        public static void ConfigureBookController(this WebApplication app)
        {
            var books = app.MapGroup("books");
            books.MapGet("/", GetAll);
            books.MapGet("/{id}", GetBook);
            books.MapPost("/", AddBook);
            books.MapPut("/", UpdateBook);
            books.MapDelete("/", DeleteBook);
        }

        private static IResult DeleteBook(IBookRepository repository, int id)
        {
            return TypedResults.Ok(repository.DeleteBook(id));
        }

        private static IResult UpdateBook(IBookRepository repository, int id, Book book)
        {
            return TypedResults.Ok(repository.UpdateBook(id, book));
        }

        private static IResult AddBook(IBookRepository repository, Book book)
        {
            return TypedResults.Ok(repository.AddBook(book));
        }

        private static IResult GetBook(IBookRepository repository, int id)
        {
            return TypedResults.Ok(repository.GetBook(id));
        }

        private static IResult GetAll(IBookRepository repository)
        {
            return TypedResults.Ok(repository.GetBooks());
        }
    }
}
