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

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddBook(IRepository repository, Book model) 
        {
            var bookToAdd = new Book() { Author = model.Author, Genre = model.Genre, NumPages = model.NumPages, Title = model.Title };
            repository.AddBook(bookToAdd);
            return TypedResults.Ok(bookToAdd);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IRepository repository) 
        {
            return TypedResults.Ok(repository.GetBooks());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBook(IRepository repository, int id) 
        {
            var book = repository.GetBook(id);
            return TypedResults.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateBook(IRepository repository, int id, string newTitle, string newAuthor, string newGenre, int newNumPages) 
        {
            var book = repository.UpdateBook(id, newTitle, newAuthor, newGenre, newNumPages);
            return TypedResults.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteBook(IRepository repository, int id) 
        {
            var book = repository.DeleteBook(id);
            return TypedResults.Ok(book);
        }
    }
}
