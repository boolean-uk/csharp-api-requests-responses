using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        public static void configureBookEndpoints(this WebApplication app)
        {
            var bookGroup = app.MapGroup("books");

            //Get
            bookGroup.MapGet("/getAll", GetBooks);

            //Post
            bookGroup.MapPost("/create", CreateBook);
        }

        public static IResult GetBooks(IBookRepository bookRepository)
        {
            return TypedResults.Ok(bookRepository.GetBooks());
        }

        public static IResult CreateBook(IBookRepository bookRepository, string title, int numPages, string author, string genre)
        {
            var book = bookRepository.AddBook(title, numPages, author, genre);
            return TypedResults.Created("/created", book);
        }
    }
}
