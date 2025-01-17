using exercise.wwwapi.DTO;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoints(this WebApplication app)
        {
            var books = app.MapGroup("books");

            books.MapGet("/", GetBooks);
            books.MapGet("/{id}", GetBookById);
            books.MapPost("/", AddBook);
            books.MapPut("/{id}", UpdateBook);
            books.MapDelete("/{id}", DeleteBook);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IRepository<Book> repository)
        {
            var books = repository.GetAll();
            
            return Results.Ok(books);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBookById(IRepository<Book> repository, int id)
        {
            var book = repository.GetById(id);
            if (book == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(book);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddBook(IRepository<Book> repository, BookDto book)
        {   
            Book newBook = new Book() {
                NumberOfPages = book.NumberOfPages,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
            };
            //Dont really want to have this here either, but without a service layer, and when the exercise tells us to expose the ID, this happened
            repository.Add(newBook);
            Book addedBook = repository.GetAll().Where(x => x.Title == book.Title).FirstOrDefault();
            return Results.Ok(addedBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateBook(IRepository<Book> repository, int id, BookDto book)
        {
            
            
            if (repository.GetById(id) == null)
            {
                return Results.NotFound();
            }
            var updatedBook = new Book()
            {
                Id = id,
                Author = book.Author,
                NumberOfPages = book.NumberOfPages,
                Genre = book.Genre,
                Title = book.Title
            };
            repository.Update(updatedBook);
            return Results.Ok(updatedBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteBook(IRepository<Book> repository, int id)
        {
            var book = repository.GetById(id);
            if (book == null)
            {
                return Results.NotFound();
            }
            repository.Delete(id);
            return Results.Ok(book);
        }
    }
}
