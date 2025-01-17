using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using exercise.wwwapi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var books = app.MapGroup("books");

            books.MapGet("/", GetBooks);
            books.MapGet("/{id}", GetBook);
            books.MapPut("/{id}", UpdateBook);
            books.MapPost("/", AddBook);
            books.MapDelete("/{id}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IRepository repository)
        {
            var books = repository.GetBooks();
            return Results.Ok(books);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBook(IRepository repository, int id)
        {
            var book = repository.GetBook(id);
            return Results.Ok(book);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddBook(IRepository repository, BookPost model)
        {
            var books = repository.GetBooks();
            Book book = new Book()
            {
                Id = books.Max(p => p.Id) + 1,
                Title = model.Title,
                NumPages = model.NumPages,
                Author = model.Author,
                Genre = model.Genre,
            };
            repository.AddBook(book);

            return Results.Created("https://localhost:7068/books", book);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> DeleteBook(IRepository repository, int id)
        {
            try
            {
                var model = repository.GetBook(id);
                if (repository.DeleteBook(id)) return Results.Ok(new { When = DateTime.Now, Status = "Deleted", Id = model.Id, Titel = model.Title, NumPages = model.NumPages, Author = model.Author, Genre = model.Genre });
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        public static async Task<IResult> UpdateBook(IRepository repository, int id, BookPut model)
        {
            var target = repository.GetBook(id);
            if (target == null) return TypedResults.NotFound();
            if (model.Title != null) target.Title = model.Title;
            if (model.NumPages != null) target.NumPages = model.NumPages.Value;
            if (model.Author != null) target.Author = model.Author;
            if (model.Genre != null) target.Genre = model.Genre;
            return TypedResults.Ok(target);
        }
    }
}
