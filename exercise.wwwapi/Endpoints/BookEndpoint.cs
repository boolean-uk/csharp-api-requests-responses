using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
namespace exercise.wwwapi.Endpoints

{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var bookGroup = app.MapGroup("books");
            bookGroup.MapGet("/", GetBooks);
            bookGroup.MapPost("/", AddBook);
            bookGroup.MapGet("/{id}", GetBookById);
            bookGroup.MapPut("/{id}", UpdateBookById);
            bookGroup.MapDelete("/{id}", DeleteBookById);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async static Task<IResult> GetBooks(IRepository repository)
        {
            return TypedResults.Ok(repository.GetBooks());
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async static Task<IResult> AddBook(IRepository repository, BookPost bookPost)
        {
            repository.AddBook(bookPost);
            return TypedResults.Created($"{bookPost.title}");
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async static Task<IResult> GetBookById(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.GetBookById(id));
        }
        public async static Task<IResult> UpdateBookById(IRepository repository, int id, BookPut bookPut)
        {
            return TypedResults.Ok(repository.UpdateBook(id, bookPut));
        }
        public async static Task<IResult> DeleteBookById(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.DeleteBookById(id));  
        }
    }

}

