using exercise.wwwapi.Models;
using exercise.wwwapi.Models.DTO;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var languageGroup = app.MapGroup("books");
            languageGroup.MapPost("/", CreateBook);
            languageGroup.MapGet("/", GetAllBooks);
            languageGroup.MapGet("/{id}", GetBook);
            languageGroup.MapPut("/{id}", UpdateBook);
            languageGroup.MapDelete("/{id}", DeleteBook);            
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateBook(IBookRepository repository, API_book book)
        {
            Book retrievedBook = repository.Create(book);           
            return TypedResults.Created("books/", book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllBooks(IBookRepository repository)
        {
            return TypedResults.Ok(repository.GetAllBooks());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBook(IBookRepository repository, int id)
        {
            Book book = repository.getBook(id);
            return TypedResults.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateBook(IBookRepository repository, int id, API_book book)
        {
            Book retrievedBook = repository.Update(id, book);
            return TypedResults.Created("books/{name}", retrievedBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteBook(IBookRepository repository, int id)
        {
            return TypedResults.Ok(repository.Delete(id));
        }
    }
}
