using exercise.wwwapi.DTOs;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var bookGroup = app.MapGroup("books");

            bookGroup.MapGet("/", GetBooks);
            bookGroup.MapGet("/{id}", GetBook);
            bookGroup.MapPut("/{id}", PutBook);
            bookGroup.MapDelete("/{id}", DeleteBook);
            bookGroup.MapPost("/", AddBook);
        }

        public static IResult GetBooks(IRepository<Book> books)
        {
            return TypedResults.Ok(books.GetAll());
        }

        public static IResult GetBook(IRepository<Book> books, string id)
        {
            try
            {
                Book book = books.GetById(id);
                return TypedResults.Ok(book);
            } catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        public static IResult AddBook(IRepository<Book> books, AddBookDTO addBook)
        {
            Book book = new()
            {
                Author = addBook.Author,
                Title = addBook.Title,
                Genre = addBook.Genre,
                Pages = addBook.Pages,
            };
            books.Add(book);
            return TypedResults.Ok(book);
        }

        public static IResult DeleteBook(IRepository<Book> books, string id)
        {
            try
            {
                return TypedResults.Ok(books.DeleteById(id));
            } catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        public static IResult PutBook(IRepository<Book> books, AddBookDTO addBookDTO, string id)
        {
            try
            {
                Book book = books.GetById(id);
                book.Author = addBookDTO.Author;
                book.Title = addBookDTO.Title;
                book.Pages = addBookDTO.Pages;
                book.Genre = addBookDTO.Genre;
                return TypedResults.Ok(book);
            } catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }
    }
}
