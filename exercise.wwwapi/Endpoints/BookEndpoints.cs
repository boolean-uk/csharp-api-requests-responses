using exercise.wwwapi.Repositories.Interfaces;
using exercise.wwwapi.Views;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        public static void ConfigureBookEndPoints(this WebApplication app)
        {
            var languages = app.MapGroup("book");
            languages.MapGet("/", GetBooks);
            languages.MapPost("/", CreateBook);
            languages.MapGet("/{name}", GetBook);
            languages.MapPut("/{name}", UpdateBook);
            languages.MapDelete("/{name}", DeleteBook);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteBook(IBookRepository repo, string name)
        {
            if (repo.DeleteBook(name))
                return TypedResults.Ok(true);
            return TypedResults.NotFound(false);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetBook(IBookRepository repo, string name)
        {
            var stud = repo.GetBook(name);
            if (stud != null)
                return TypedResults.Ok(stud);
            return TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateBook(IBookRepository repo, string name, BookView dto)
        {
            var stud = repo.UpdateBook(name, dto);
            if (stud != null)
                return TypedResults.Ok(stud);
            return TypedResults.BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateBook(IBookRepository repo, BookView dto)
        {
            var stud = repo.AddBook(dto);
            if (stud != null)
                return TypedResults.Ok(stud);
            return TypedResults.BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IBookRepository repo)
        {
            return TypedResults.Ok(repo.GetBooks());
        }
    }
}
