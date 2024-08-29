using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        public static void ConfigureBookEndPoints(this WebApplication app)
        {
            var students = app.MapGroup("books");
            students.MapGet("", GetAll);
            students.MapGet("/{id}", GetBook);
            students.MapPost("", Add);
            students.MapPut("/{id}", Update);
            students.MapDelete("/{id}", Delete);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAll(IRepo<Book, Guid> bookRepo)
        {
            return TypedResults.Ok(bookRepo.getAll());
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult Add(IRepo<Book, Guid> bookRepo, Book book)
        {
            bookRepo.Add(book);

            return TypedResults.Created();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetBook(IRepo<Book, Guid> bookRepo, Guid id)
        {
            Book book = bookRepo.Get(id);
            if (book == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult Update(IRepo<Book, Guid> bookRepo, Book book, Guid id)
        {
            Book oldBook = bookRepo.Get(id);
            if (oldBook == null)
            {
                return TypedResults.NotFound();
            }
            if (book == null)
            {
                return TypedResults.BadRequest();
            }

            bookRepo.Update(book, id);
            return TypedResults.Created();
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult Delete(IRepo<Book, Guid> bookRepo, Guid id)
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
