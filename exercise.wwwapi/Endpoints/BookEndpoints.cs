using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        public static void ConfigureBookEndpoints(this WebApplication app)
        {
            var LanguageGroup = app.MapGroup("books");

            LanguageGroup.MapPost("/add", AddBook);
            LanguageGroup.MapGet("/all", GetAllBooks);
            LanguageGroup.MapGet("/get", GetBookById);
            LanguageGroup.MapPut("/update", UpdateBook);
            LanguageGroup.MapDelete("/delete", DeleteBook);

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddBook(IRepository repository, Book book)
        {
            return TypedResults.Created($"New book: ", repository.AddBook(book));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllBooks(IRepository repository)
        {
            return TypedResults.Ok(repository.GetAllBooks());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBookById(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.GetBook(id));
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateBook(IRepository repository, int id, Book book)
        {
            return TypedResults.Created($"Updated book: ", repository.UpdateBook(id, book));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteBook(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.DeleteBook(id));
        }
    }
}
