using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        public static void ConfigureBookEndpoints(this WebApplication app)
        {
            var bookGroup = app.MapGroup("books");
            bookGroup.MapGet("/{id}" , Get);
            bookGroup.MapGet("/" , GetAllBooks);
            bookGroup.MapPost("/" , CreateBook);
            bookGroup.MapPut("/{id}" , UpdateBook);
            bookGroup.MapDelete("/{id}" , DeleteBook);
        }

        public static IResult Get([FromServices] IBookRepository books , int id)
        {
            return Results.Ok(books.Get(id));
        }

        public static IResult GetAllBooks([FromServices] IBookRepository books)
        {
            return Results.Ok(books.GetAll());
        }

        public static IResult CreateBook([FromServices] IBookRepository books , Book newBookData)
        {
            Book book = books.Add(newBookData);
            return Results.Created($"/books/{book.Id}" , book);
        }

        public static IResult UpdateBook([FromServices] IBookRepository books , int id , Book updatedBookData)
        {
            Book? book = books.Update(id , updatedBookData);
            if(book == null)
            {
                return Results.NotFound($"Book with id {id} not found.");
            }
            return Results.Ok(book);
        }

        public static IResult DeleteBook([FromServices] IBookRepository books , int id)
        {
            Book? book = books.Delete(id);
            if(book == null)
            {
                return Results.NotFound($"Book with id {id} not found.");
            }
            return Results.Ok(book);
        }
    }
}
