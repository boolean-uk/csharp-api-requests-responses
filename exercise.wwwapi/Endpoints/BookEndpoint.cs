using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using System.Xml.Linq;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoints(this WebApplication app)
        {
            var bookGroup = app.MapGroup("books");
            bookGroup.MapGet("/GetAllBoosk", GetAllBooks);
            bookGroup.MapGet("/GetBook", GetBook);
            bookGroup.MapPost("/CreateBook", CreateBook);
            bookGroup.MapPut("/UpdateBook{id}", UpdateBook);
            bookGroup.MapDelete("/RemoveBook{id}", RemoveBook);
        }
        public static IResult GetAllBooks(IBookRepository books)
        {
            return TypedResults.Ok(books.GetAllBooks());
        }
        public static IResult GetBook(IBookRepository books, int id)
        {
            return TypedResults.Ok(books.GetBook(id));
        }
        public static IResult CreateBook(IBookRepository books, BookPostPayload newBookData)
        {
            try
            {
                Book book = books.AddBook(newBookData.title, newBookData.numPages, newBookData.author, newBookData.genre);
                if (newBookData.title == null)
                {
                    return TypedResults.NotFound($"You must enter a title.");
                }
                if (newBookData.numPages == 0)
                {
                    return TypedResults.NotFound($"A book can not have no pages.");
                }
                if (newBookData.author == null)
                {
                    return TypedResults.NotFound($"Book must have an author.");
                }
                if (newBookData.genre == null)
                {
                    return TypedResults.NotFound($"Book must have a genre.");
                }
                return TypedResults.Created($"/book{book.Title}", book);
            }
            catch (Exception e)
            {
                return TypedResults.NotFound(e.Message);
            }
        }
        public static IResult UpdateBook(IBookRepository books, int id, BookUpdatePayload updateData)
        {
            try
            {
                Book? book = books.UpdateBook(id, updateData);
                if (book == null)
                {
                    return TypedResults.NotFound($"Book with {book.Title} not found.");
                }
                return TypedResults.Created($"/books{book.Title}", book);
            }
            catch (Exception e)
            {
                return TypedResults.BadRequest(e.Message);
            }
        }
        public static IResult RemoveBook(IBookRepository books, int id)
        {
            return TypedResults.Ok(books.RemoveBook(id));
        }
    }
}
