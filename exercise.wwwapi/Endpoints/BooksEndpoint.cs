using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    public static class BooksEndpoint
    {
        public static void ConfigureBooksEndpoint(this WebApplication app)
        {
            var bookGroup = app.MapGroup("books");
            bookGroup.MapGet("/", GetBooks);
            bookGroup.MapPost("/", PostBook);
            bookGroup.MapGet("/{id}", GetBook);
            bookGroup.MapPut("/{id}", UpdateBook);
            bookGroup.MapDelete("/{id}", DeleteBook);
        }

        public static async Task<IResult> GetBooks(IRepository repository)
        {
            return TypedResults.Ok(repository.GetBooks());
        }

        public static async Task<IResult> PostBook(IRepository repository, Book book)
        {
            return TypedResults.Created("", repository.AddBook(book));
        }

        public static async Task<IResult> GetBook(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.GetBook(id));
        }

        public static async Task<IResult> UpdateBook(IRepository repository, int id, Book book)
        {
            return TypedResults.Ok(repository.UpdateBook(id, book));
        }

        public static async Task<IResult> DeleteBook(IRepository repository, int id)
        {
            repository.DeleteBook(id);
            return TypedResults.Ok();
        }
    }
}
