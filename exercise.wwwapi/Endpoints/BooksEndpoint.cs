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
            books.MapGet("/", GetAllBooks);
            books.MapGet("/{id}", GetBook);
            books.MapPut("/{id}", UpdateBook);
            books.MapDelete("/{id}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateBook(IBookRepository bookRepository, Book book)
        {
            bookRepository.AddBook(book);
            return TypedResults.Ok(book);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllBooks(IBookRepository bookRepository)
        {
            return TypedResults.Ok(bookRepository.GetAllBooks());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetBook(IBookRepository bookRepository, int id) 
        {
            return TypedResults.Ok(bookRepository.GetBook(id));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateBook(IBookRepository bookRepository, int id, Book book)
        {
            return TypedResults.Ok(bookRepository.UpdateBook(id, book));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteBook(IBookRepository bookRepository, int id)
        {
            return TypedResults.Ok(bookRepository.DeleteBook(id));
        }
    }
}
