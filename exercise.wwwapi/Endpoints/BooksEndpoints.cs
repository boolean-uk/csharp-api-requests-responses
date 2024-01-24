using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;

namespace exercise.wwwapi.Endpoints
{
    public static class BooksEndpoints
    {
        public static IResult CreateBook(BooksRepository books, string title, int numPages, string author, string genre)
        {
            Books newBook = books.CreateBook(title, numPages, author, genre);

            return Results.Created($"/CreateBook/{newBook}", newBook);
        }

        public static IResult GetAllBooks(BooksRepository books)
        {
            var allbooks = books.getAllBooks();
            return Results.Ok(allbooks);
        }

        public static IResult GetASingleBook(BooksRepository books, int id)
        {
            var book = books.getAllBooks().Find(b => b.id==id);
            if (book != null)
            {
                return TypedResults.Ok(book);
            }
            else
            {
                return Results.NotFound($"book with id {id} not found");
            }
        }

        public static IResult UpdateBook(BooksRepository books, int id, string title, int numPages, string author, string genre)
        {
            var book = books.getAllBooks().Find(b => b.id == id);
            if (book != null)
            {
                book.title = title;
                book.author = author;
                book.genre = genre;
                book.numPages = numPages;

                return Results.Created($"/UpdatedBook/{book}", book);
            }
            else
            {
                return Results.NotFound($"book with id {id} not found");
            }
        }

        public static IResult DeleteBook(BooksRepository books, int id)
        {
            var book = books.getAllBooks().Find(b => b.id == id);

            if (book != null)
            {
                books.RemoveBook(id);

                return TypedResults.Ok(book);
            }
            else
            {
                return Results.NotFound($"Book with id {id} not found");
            }
        }

    }
}
