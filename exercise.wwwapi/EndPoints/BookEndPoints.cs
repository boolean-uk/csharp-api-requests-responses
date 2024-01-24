using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.EndPoints
{
    public static class BookEndPoints
    {
        public static void BookEndPointConfig(this WebApplication app)
        {
            var bookGroup = app.MapGroup("books");

            bookGroup.MapPost("/CreateNewBook", CreateABook);
            bookGroup.MapGet("/GetAllBooks", GetAllBooks);
            bookGroup.MapGet("/GetABook{Id}", GetABook);
            bookGroup.MapPut("/UpdateABook{Id}", UpdateABook);
            bookGroup.MapDelete("/DeleteABook{Id}", DeleteABook);
        }

        public static IResult CreateABook(IBookRepository books, BookPostPayload newBookData)
        {
            Book book = books.CreateABook(newBookData);
            return TypedResults.Ok(book);
        }

        public static IResult GetAllBooks(IBookRepository books)
        {
            return TypedResults.Ok(books.GetAllBooks());
        }

        public static IResult GetABook(IBookRepository books, int id)
        {
            return TypedResults.Ok(books.GetABook(id));
        }

        public static IResult UpdateABook(IBookRepository books, int id, BookUpdateData updateData)
        {

            return TypedResults.Ok(books.UpdateABook(id, updateData));
        }
        public static IResult DeleteABook(IBookRepository books, int id)
        {
            return TypedResults.Ok(books.DeleteABook(id));
        }
    }

}
