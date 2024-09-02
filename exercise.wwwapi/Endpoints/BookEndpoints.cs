using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        public static void ConfigureBookEndpoints(this WebApplication app)
        {
            var books = app.MapGroup("books");
            books.MapGet("/", GetAll);
            books.MapGet("/{id}", GetA);
            books.MapPost("/{book}", Create);
            books.MapPut("/{book}", Update);
            books.MapDelete("/{id}", Delete);

        }

        private static IResult GetAll(BookRepository repo) => TypedResults.Ok(repo.GetAll());

        private static IResult GetA(BookRepository repo, int id) => TypedResults.Ok(repo.GetA(id));

        private static IResult Create(BookRepository repo, Book book) => TypedResults.Created("", repo.Create(book));

        private static IResult Update(BookRepository repo, Book book) => TypedResults.Created("", repo.Update(book));

        private static IResult Delete(BookRepository repo, int id) => TypedResults.Ok(repo.Delete(id));
    }
}
