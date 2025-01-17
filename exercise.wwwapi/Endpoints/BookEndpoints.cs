using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

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
            LanguageGroup.MapPut("/{id}", UpdateBook);
            LanguageGroup.MapDelete("/{id}", DeleteBook);
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

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateBook(IBookRepository repository, int id, BookDTO bookDTO)
        {
            var updatedBook = repository.Update(id, bookDTO);

            return TypedResults.Created($"/books/{id}", updatedBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteBook(IBookRepository repository, int id)
        {
            var book = repository.Delete(id);

            return TypedResults.Ok(book);
        }

    }
}
