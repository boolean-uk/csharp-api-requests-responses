using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndPoint
    {
        public static void ConfigureBookEndPoints(this WebApplication app)
        {
            var books = app.MapGroup("books");
            books.MapGet("/", GetAllBooks);
            books.MapGet("/{id}", GetABook);
            books.MapPost("/", AddBook);
            books.MapPut("/{id}", UpdateBook);
            books.MapDelete("/{id}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllBooks(IBookRepository repo)
        {
            return TypedResults.Ok(repo.GetBooks());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetABook(IBookRepository repo, int id)
        {
            Book book = repo.GetABook(id);
            if(book == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddBook(IBookRepository repo, string title, int numPages, string author, string genre)
        {
            Book bookToBeAdded = new Book(repo.IncreaseId(), title, numPages, author, genre);
            repo.AddBook(bookToBeAdded);
            return TypedResults.Created("", bookToBeAdded);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult UpdateBook(IBookRepository repository, int id, string title, int numPages, string author, string genre)
        {
            Book bookToBeUpdated = repository.UpdateBook(id, title, numPages, author, genre);
            if(bookToBeUpdated == null)
            {
                TypedResults.NotFound();
            }

            return TypedResults.Created("", bookToBeUpdated);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult DeleteBook(IBookRepository repo, int id)
        {
            Book bookToBeDeleted = repo.GetABook(id);
            if(bookToBeDeleted == null)
            {
                return TypedResults.NotFound();
            }
            repo.RemoveBook(bookToBeDeleted);
            return TypedResults.Ok(bookToBeDeleted);
        }
    }
}
