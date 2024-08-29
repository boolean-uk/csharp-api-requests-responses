using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoints(this WebApplication app)
        {
            var students = app.MapGroup("Books");
            students.MapGet("/getAll", getBooks);
            students.MapGet("/get/{title}", getABook);
            students.MapPost("/create", createABook);
            students.MapPut("/edit/{name}", editABook);
            students.MapDelete("/delete/{name}", deleteABook);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult getBooks(IRepository<Book> books)
        {
            var currentBooks = books.getAll();
            return TypedResults.Ok(currentBooks);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult getABook(IRepository<Book> books, string title)
        {
            var book = books.getElementByName(title);
            return TypedResults.Ok(books);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult createABook(IRepository<Book> books, [FromBody] Book book)
        {
            books.createElement(book);
            return TypedResults.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult editABook(IRepository<Book> books,string name, [FromBody] Book book)
        {
            books.updateElement(book);
            return TypedResults.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult deleteABook(IRepository<Book> books, string title)
        {

            books.deleteElement(title);
            return TypedResults.Ok(books.getElementByName(title));
        }
    }
}
