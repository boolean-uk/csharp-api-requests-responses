using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {

        public static void ConfigureBooks(this WebApplication app)
        {
            var book = app.MapGroup("books");

            book.MapPost("/", AddBook);
            book.MapGet("/", GetBooks);
            book.MapGet("/{id}", GetBookById);
            book.MapPut("/{id}", UpdateBookById);
            book.MapDelete("/{id}", DeleteBook);

        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddBook(IBookRepository repo, Book book)
        {
            try
            {
                repo.AddBook(book);
                return TypedResults.Ok();
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex);
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IBookRepository repo)
        {
            try
            {
                var books = repo.GetAllBooks();
                return TypedResults.Ok(books);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetBookById(IBookRepository repo, int id)
        {

            var book = repo.GetBook(id);
            if (book != null)
            {
                return TypedResults.Ok(book);
            }
            else
            {
                return TypedResults.NotFound();
            }

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateBookById(IBookRepository repo, int id, string title, int numpages, string author, string genre)
        {

            var book = repo.UpdateBook(id, title, numpages, author, genre);

            if (book != null)
            {
                return TypedResults.Ok(book);
            }
            else
            {
                return TypedResults.NotFound();
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteBook(IBookRepository repo, int id)
        {

            var book = repo.DeleteBook(id);
            if (book != null)
            {
                return TypedResults.Ok(book);
            }
            else
            {
                return TypedResults.NotFound();
            }

        }
    }
}