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

            books.MapGet("/", GetAll);
            books.MapGet("/{id}", GetOne);
            books.MapPost("/", AddBook);
            books.MapDelete("/{id}", DeleteBook);
            books.MapPut("/{id}", UpdateBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IBookRepository<Book> repository)
        {
            var books = repository.GetAll();
            return Results.Ok(books);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOne(IBookRepository<Book> repository, int id)
        {
            var book = repository.GetOne(id);
            return Results.Ok(book);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddBook(IBookRepository<Book> repository, BookPost model)
        {
            Book book = new Book()
            {
                Title = model.Title,
                NumPages = model.NumPages,
                Author = model.Author,
                Genre = model.Genre
            };
            repository.Add(book);

            return Results.Created($"https://localhost:7010/pets/{book.Id}", book);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteBook(IBookRepository<Book> repository, int id)
        {
            try
            {
                var model = repository.GetOne(id);
                if (repository.Delete(id)) return Results.Ok(new { When = DateTime.Now, Status = "Deleted", Title = model.Title, NumPages = model.NumPages, Author = model.Author, Genre = model.Genre });
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateBook(IBookRepository<Book> repository, int id, BookPut model)
        {
            try
            {
                var target = repository.GetOne(id);
                if (target == null) return Results.NotFound();
                if (model.Title != null) target.Title = model.Title;
                if (model.NumPages != null) target.NumPages = model.NumPages;
                if (model.Author != null) target.Author = model.Author;
                if (model.Genre != null) target.Genre = model.Genre;
                return Results.Ok(target);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
