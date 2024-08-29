using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        public static void ConfigureBookEndpoints(this WebApplication app)
        {
            var books = app.MapGroup("books");
            books.MapPost("", CreateBook);
            books.MapGet("", GetAllBooks);
            books.MapGet("/{id:guid}", GetABook);
            books.MapPut("/{id:guid}", UpdateBook);
            books.MapDelete("/{id:guid}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static IResult CreateBook(IRepo<Book> bookRepo, Book book)
        {
            if (book == null)
            {
                return TypedResults.BadRequest();
            }

            bookRepo.Add(book);
            return TypedResults.Created();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        private static IResult GetAllBooks(IRepo<Book> bookRepo)
        {
            return TypedResults.Ok(bookRepo.GetAll());

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static IResult GetABook(IRepo<Book> bookRepo, Guid id)
        {
            Book book = bookRepo.Get(id);

            if (book == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static IResult UpdateBook(IRepo<Book> bookRepo, Guid id, Book newValues)
        {
            Book book = bookRepo.Get(id);

            if (book == null)
            {
                return TypedResults.NotFound();
            }

            if (newValues == null)
            {
                return TypedResults.BadRequest();
            }

            bookRepo.Update(id, newValues); 

            return TypedResults.Created();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static IResult DeleteBook(IRepo<Book> bookRepo, Guid id)
        {
            Book book = bookRepo.Get(id);

            if (book == null)
            {
                return TypedResults.NotFound();
            }

           bookRepo.Delete(id);

            return TypedResults.Ok();
        }

    }
}
