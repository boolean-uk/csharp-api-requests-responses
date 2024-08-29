using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndPoint
    {
        private static BookCollection _books = new BookCollection();
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
        public static IResult GetAllBooks()
        {
            return TypedResults.Ok(_books.GetBooks());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetABook(int id)
        {
            Book book = _books.GetABook(id);
            if(book == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddBook(string title, int numPages, string author, string genre)
        {
            Book bookToBeAdded = new Book(_books.IdIterator, title, numPages, author, genre);
            _books.IdIterator += 1;
            _books.AddBook(bookToBeAdded);
            return TypedResults.Created("", bookToBeAdded);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult UpdateBook(int id, string title, int numPages, string author, string genre)
        {
            Book bookToBeUpdated = _books.GetABook(id);
            if(bookToBeUpdated == null)
            {
                return TypedResults.NotFound();
            }
            bookToBeUpdated.Title = title;
            bookToBeUpdated.NumPages = numPages;
            bookToBeUpdated.Author = author;
            bookToBeUpdated.Genre = genre;

            return TypedResults.Created("", bookToBeUpdated);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult DeleteBook(int id)
        {
            Book bookToBeDeleted = _books.GetABook(id);
            if(bookToBeDeleted == null)
            {
                return TypedResults.NotFound();
            }
            _books.RemoveBook(bookToBeDeleted);
            return TypedResults.Ok(bookToBeDeleted);
        }
    }
}
