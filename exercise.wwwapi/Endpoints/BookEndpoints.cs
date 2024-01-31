using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var bookGroup = app.MapGroup("Book");

            bookGroup.MapGet("/books", GetBooks);
            bookGroup.MapGet("/{id}", GetBook);
            bookGroup.MapDelete("/{id}", DeleteBook);
            bookGroup.MapPost("/{id}", CreateBook);
            bookGroup.MapPut("/{id}", UpdateBook);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IBookRepository bookRepository)
        {
            return TypedResults.Ok(bookRepository.GetBooks());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBook(IBookRepository bookRepository, int id)
        {
            return TypedResults.Ok(bookRepository.GetBook(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteBook(IBookRepository bookRepository, int id)
        {
            return TypedResults.Ok(bookRepository.DeleteBook(id));
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateBook(IBookRepository bookRepository,string title, string author, string genre, int numPage)
        {
            return TypedResults.Ok(bookRepository.CreateBook(title, author, genre, numPage));
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateBook(IBookRepository bookRepository, int id, string title, string author, string genre, int numPage)
        {
            return TypedResults.Ok(bookRepository.UpdateBook(id, title, author, genre, numPage));
        }
    }
}
