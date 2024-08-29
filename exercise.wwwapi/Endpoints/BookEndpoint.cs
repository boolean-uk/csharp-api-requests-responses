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
            books.MapPost("/", CreateBook);
            books.MapGet("/", GetAllBooks);
            books.MapGet("/{id}", GetABook);
            books.MapPut("/{id}", UpdateBook);
            books.MapDelete("/{id}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateBook(IBookRepository repository, Book book)
        {
            var result = repository.CreateABook(book);
            return result != null ? TypedResults.Created($"https://localhost:7068/books", result) : TypedResults.BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllBooks(IBookRepository repository)
        {
            return TypedResults.Ok(repository.GetAllBooks());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetABook(IBookRepository repository, int id)
        {
            if (repository.GetABook(id) != null)
            {
                return TypedResults.Ok(repository.GetABook(id));
            }
            return TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult UpdateBook(IBookRepository repository, int id, string newTitle, int newNumPages, string newAuthor, string newGenre)
        {

            if (repository.GetABook(id) != null)
            {
                var result = repository.UpdateBook(id, newTitle, newNumPages, newAuthor, newGenre);
                return result != null ? TypedResults.Created($"https://localhost:7068/books", result) : TypedResults.BadRequest();
            }
            return TypedResults.NotFound();

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult DeleteBook(IBookRepository repository, int id)
        {
            if (repository.GetABook(id) != null)
            {
                return TypedResults.Ok(repository.DeleteBook(id));
            }
            return TypedResults.NotFound();

        }

    }
}
