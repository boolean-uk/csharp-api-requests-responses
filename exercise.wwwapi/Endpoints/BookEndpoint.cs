using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var bookGroup = app.MapGroup("books");

            bookGroup.MapPost("/", AddBook);
            bookGroup.MapGet("/", GetBooks);
            bookGroup.MapGet("/{id}", GetBook);
            bookGroup.MapPut("/{id}", UpdateBook);
            bookGroup.MapDelete("/{id}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IRepository repository)
        {
            return TypedResults.Ok(repository.GetBooks());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBook(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.GetBook(id));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddBook(IRepository repository, BookPost book)
        {
            //validate
            if (book == null)
            {

            }
            var newBook = new Book() { Title = book.Title, Author = book.Author, Genre = book.Genre, NumPages = book.NumPages };
            repository.AddBook(newBook);
            return TypedResults.Created($"/{newBook.Id}", newBook);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateBook(IRepository repository, int id, BookPut book)
        {
            //validate
            if (book == null)
            {

            }
            return TypedResults.Ok(repository.UpdateBook(id, book));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteBook(IRepository repository, int id)
        {
            var result = TypedResults.Ok(repository.GetBook(id));
            repository.DeleteBook(id);
            return result;
        }
    }
}
