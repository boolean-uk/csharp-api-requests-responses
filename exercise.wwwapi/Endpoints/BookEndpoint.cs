using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var books = app.MapGroup("books");
            books.MapGet("/", GetAll);
            books.MapGet("/{id}", Get);
            books.MapPost("/", Add);
            books.MapPut("/{id}", Update);
            books.MapDelete("/{id}", Delete);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAll(IRepository<Book, BookView, int> repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult Get(IRepository<Book, BookView, int> repository, int id)
        {
            var result = repository.Get(id);
            return result != null ? TypedResults.Ok(result) : TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult Add(IRepository<Book, BookView, int> repository, BookView entity)
        {
            var result = repository.Add(entity);
            return result != null ? TypedResults.Created($"https://localhost:7068/students/", result) : TypedResults.BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult Update(IRepository<Book, BookView, int> repository, int id, BookView entity)
        {
            var result = repository.Update(id, entity);
            return result != null ? TypedResults.Created($"https://localhost:7068/students/{id}", result) : TypedResults.BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult Delete(IRepository<Book, BookView, int> repository, int id)
        {
            var result = repository.Delete(id);
            return result != null ? TypedResults.Ok(result) : TypedResults.NotFound();
        }
    }
}
