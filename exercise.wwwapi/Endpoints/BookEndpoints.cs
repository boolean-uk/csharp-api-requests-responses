using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        public static void ConfigureBookEndpoints(this WebApplication App)
        {
            var LanguageGroup = App.MapGroup("books");
            LanguageGroup.MapPost("/", AddBook);
            LanguageGroup.MapGet("/", GetAllBooks);
            LanguageGroup.MapGet("/{id}", GetBook);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddBook(IBookRepository repository, BookDTO book)
        {
            var createdBook = repository.Create(book);

            return TypedResults.Created($"/books/{createdBook.Id}", book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllBooks(IBookRepository repository)
        {
            var books = repository.GetAll();

            return TypedResults.Ok(books);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetBook(IBookRepository repository, int id)
        {
            var book = repository.Get(id);

            return TypedResults.Ok(book);
        }
    }
}
