using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        public static void ConfigureBooksEndpoint(this WebApplication app)
        {
            var books = app.MapGroup("books");

            books.MapGet("/", GetAllBooks);
            books.MapPost("/", CreateBook);
            books.MapGet("/{id}", GetSingleBook);
            books.MapPut("/{id}", EditSingleBook);
            books.MapDelete("/{id}", DeleteSingleBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetAllBooks(IBook repository)
        {
            return Results.Ok(repository.GetBooks());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> CreateBook(IBook repository, BookViewModel model)
        {
            Book book = new Book(model.title, model.numPages, model.author, model.genre);
            repository.CreateBook(book);
            return Results.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetSingleBook(IBook repository, int id)
        {
            return Results.Ok(repository.GetBook(id));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> EditSingleBook(IBook repository, BookViewModel updatedBook, int id)
        {
            Book book = repository.GetBook(id);
            book.title = updatedBook.title;
            book.author = updatedBook.author;
            book.genre = updatedBook.genre;
            book.numPages = updatedBook.numPages;
            return Results.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> DeleteSingleBook(IBook repository, int id)
        {
            try
            {
                Book book = repository.GetBook(id);
                if (repository.DeleteBook(id) != null)
                {
                    return Results.Ok(book);
                }
                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
