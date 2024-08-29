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
        public static IResult GetAll(IBookRepo bookRepo)
        {
            return TypedResults.Ok(bookRepo.getAll());
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult Add(IBookRepo bookRepo, Book book)
        {
            bookRepo.Add(book);

            return TypedResults.Created();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetBook(IBookRepo bookRepo, Guid id)
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
        public static IResult Update(IBookRepo bookRepo, Book book, Guid id)
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
        public static IResult Delete(IBookRepo bookRepo, Guid id)
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
