using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using exercise.wwwapi.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.EndPoints
{
    public static class BookEndpoints
    {
        public static void ConfigureBookEndpoints(this WebApplication app)
        {
            var books = app.MapGroup("books");

            books.MapGet("/", GetAll);
            books.MapPost("/", Add);
            books.MapGet("/{id}", GetOne);
            books.MapDelete("/{id}", Delete);
            books.MapPut("/{id}", Update);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAll(BookRepository repository)
        {
            var bookRepository = repository.GetAll();
            return TypedResults.Ok(bookRepository);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetOne(BookRepository repository, int id)
        {
            var book = repository.GetOne(id);
            return TypedResults.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static Created<Book> Add(BookRepository repository, BookPost book)
        {
            var newBook = repository.Add(book);
            return TypedResults.Created($"/{newBook.Id}", newBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult Delete(BookRepository repository, int id)
        {
            var book = repository.Delete(id);
            return Results.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult Update(BookRepository repository, BookPost book, int id)
        {
            var updatedBook = repository.Update(book, id);
            return TypedResults.Created($"/{updatedBook.Id}", updatedBook);
        }
    }

}
