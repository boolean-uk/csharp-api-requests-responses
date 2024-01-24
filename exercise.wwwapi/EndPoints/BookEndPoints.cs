using exercise.wwwapi.Models.Book;
using exercise.wwwapi.Repository.BookRepositories;
using Microsoft.AspNetCore.Builder;

namespace exercise.wwwapi.EndPoints
{
    public static class BookEndPoints
    {
        public static void ConfigureBookEndpoints(this WebApplication app)
        {
            var bookGroup = app.MapGroup("/books");
            bookGroup.MapGet("/", getAllBooks);
            bookGroup.MapGet("/{_id}", getBookById);
            bookGroup.MapPost("/", AddBook);
            bookGroup.MapPut("/{_id}", UpdateBook);
            bookGroup.MapDelete("({_id}", DeleteBook);
        }

        private static IResult getAllBooks(IBookRepository book)
        {
            return TypedResults.Ok(book.getAllBooks());
        }

        private static IResult getBookById(int _id, IBookRepository book) {
            Book foundBook = book.getBookById(_id);
            return TypedResults.Ok(foundBook);
        }

        private static IResult AddBook(IBookRepository book, BookPostPayload payload)
        {
            Book createdBook = book.AddBook(payload);
            return TypedResults.Created($"/books: ", createdBook);
        }

        private static IResult UpdateBook(int _id, IBookRepository book, BookPutPayload payload) {
            Book updatedBook = book.UpdateBook(_id, payload);
            return TypedResults.Created($"/books/{_id} ", updatedBook);
        }

        private static IResult DeleteBook(int _id, IBookRepository book) {
            book.DeleteBook(_id); return TypedResults.Ok();   
        }
    }
}
