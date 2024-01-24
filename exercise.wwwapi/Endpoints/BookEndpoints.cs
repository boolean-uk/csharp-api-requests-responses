using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        // Create extended method:

        public static void ConfigureBookEndpoint(this WebApplication app)
        {

            // Create route
            var bookGroup = app.MapGroup("books");
            bookGroup.MapPost("/", CreateBook);
            bookGroup.MapGet("/", GetBooks);
            bookGroup.MapGet("/{id}", GetABook);
            bookGroup.MapPut("/{id}", UpdateBook);
            bookGroup.MapDelete("/{id}", DeleteABook);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateBook(IRepository repository, BookPost inputBook)
        {
            if (inputBook == null)
            {
                return Results.NoContent();
            }
            var newBook = new Book() {title = inputBook.title, numPages = inputBook.numPages, author = inputBook.author, genre = inputBook.genre };
            repository.AddBook(newBook);

            return TypedResults.Created($"/{newBook.title}", newBook);  //If only title: return TypedResults.Created($"/{newBook.title}", new { title = newBook.title }); OR newBook.title?
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IRepository repository)
        {
            var bookList = repository.GetBooks();
            return bookList != null ? TypedResults.Ok(bookList) : Results.NotFound();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetABook(IRepository repository, int id)   // GetCars uses inpendecy injections?
        {
            var fillteredBook = repository.GetBooks().FirstOrDefault(book=> book.id == id);

            return fillteredBook != null ? TypedResults.Ok(fillteredBook) : Results.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateBook(IRepository repository, int id, [FromBody] BookPost updatedBook)   // GetCars uses inpendecy injections?
        {
            var fillteredBook = repository.GetBooks().FirstOrDefault(book => book.id == id);
            if (fillteredBook != null)
            {
                fillteredBook.title = updatedBook.title;
                fillteredBook.author = updatedBook.author;
                fillteredBook.numPages = updatedBook.numPages;  
                fillteredBook.genre = updatedBook.genre;

                return TypedResults.Created($"/{updatedBook.title}", updatedBook);   // This printout both first name and last name
            }

            return TypedResults.NotFound();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteABook(IRepository repository, int id)
        {
            var fillteredBook = repository.GetBooks().FirstOrDefault(book => book.id == id);
            if (fillteredBook != null)
            {
                return TypedResults.Ok(repository.RemoveBook(fillteredBook));
            }

            return TypedResults.NotFound();
        }
    }
}
