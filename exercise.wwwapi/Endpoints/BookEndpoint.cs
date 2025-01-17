using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var books = app.MapGroup("Books");

            books.MapGet("/", GetBooks);
            books.MapGet("/{id}", GetBook);
            books.MapPost("/", AddBook);
            books.MapPut("/{id}", UpdateBook);
            books.MapDelete("/{id}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IBookRepository repository)
        {
            var books = repository.GetBooks();
            return Results.Ok(books);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetBook(IBookRepository repository, int id)
        {
            var book = repository.GetBook(id);
            if (book == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(book);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddBook(IBookRepository repository, Book book)
        {
            Book newBook = new Book()
            {
                Author = book.Author,
                Genre = book.Genre,
                numPages = book.numPages,
                Title = book.Title
            };

            repository.AddBook(newBook);
            return Results.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateBook(IBookRepository repository, int id, Book book)
        {
            try
            {
                var existingBook = repository.GetBook(id);
                if (existingBook == null)
                {
                    return Results.NotFound();
                }

                var updatedBook = repository.UpdateBook(id, book);
                if (updatedBook == null)
                {
                    return Results.BadRequest();
                }
                return Results.Ok(new
                {
                    when = DateTime.Now,
                    status = "Updated",
                    oldBook = existingBook,
                    updatedBook = updatedBook
                });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> DeleteBook(IBookRepository repository, int id)
        {
            try
            {
                var bookToDelete = repository.GetBook(id);
                if (repository.Delete(id)) return Results.Ok(new { when = DateTime.Now, status = "Deleted", ID = bookToDelete.Id });
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
