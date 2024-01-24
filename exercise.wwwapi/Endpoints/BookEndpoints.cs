using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    public class BookEndpoints
    {
        public static IResult GetAllBooks (BookRepository bookRepo)
        {
            var books = bookRepo.GetAllBooks();
            return TypedResults.Ok(books);
        }
        public static IResult AddBook(BookRepository bookRepo, string title, int numPages, string author, string genre)
        {
            Book newBook = bookRepo.AddBook(title,numPages, author, genre);
            return TypedResults.Created($"/books{newBook.id}", newBook);
        }

        public static IResult UpdateBook(BookRepository bookRepo, int id, BookUpdatePayload updateData)
        {
            try
            {
                Book? book = bookRepo.UpdateBook(id, updateData);
                if(book == null)
                {
                    return Results.NotFound($"Book with id {id} not found");
                }
                return Results.Created($"Book with id {id} updated", book);
            }
            catch(Exception e)
            {
                return Results.BadRequest(e.Message);
            }


        }

        public static IResult GetBook(BookRepository bookRepo, int id)
        {
            Book? book = bookRepo.GetBook(id);

            if(book == null)
            {
                return Results.NotFound($"Book with id {id} not found");
            }

            return TypedResults.Ok(book);
        }

        public static IResult DeleteBook(BookRepository books, int id)
        {
            Book? book = books.GetBook(id);

            if(book == null)
            {
                return Results.NotFound($"Book with id {id} not found");
            }

            return TypedResults.Ok(books.RemoveBook(id));
        }

    }
}
