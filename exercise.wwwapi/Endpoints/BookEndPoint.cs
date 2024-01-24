using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndPoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var dataGroup = app.MapGroup("book");

            dataGroup.MapPost("/create", CreateBook);
            dataGroup.MapGet("/getAll", GetAllBooks);
            dataGroup.MapGet("/get{id}", GetBook);
            dataGroup.MapPut("/update/{id}", UpdateBook);
            dataGroup.MapDelete("/delete{id}", DeleteBook);

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateBook(IRepository repository, Book book)
        {
            return TypedResults.Ok(repository.createBook(book));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> GetAllBooks(IRepository repository)
        {
            return TypedResults.Ok(repository.getAllBooks());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> GetBook(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.getBook(id));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateBook(IRepository repository, int id, Book book)
        {
            return TypedResults.Ok(repository.updateBook(id, book));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> DeleteBook(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.deleteBook(id));
        }
    }
}
