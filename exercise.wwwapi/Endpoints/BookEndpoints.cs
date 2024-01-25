 using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        public static void ConfigureBookEndPoints(this WebApplication app)
        {
            var bookGroup = app.MapGroup("books");

            bookGroup.MapGet("/", GetBooks);
            bookGroup.MapGet("/{id}", GetBook);
            bookGroup.MapPost("/", AddBook);
            bookGroup.MapPut("/{id}", UpdateBook);
            bookGroup.MapDelete("/{id}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IBookRepository repository)
        {
            return TypedResults.Ok(repository.GetBooks());
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetBook(IBookRepository repository, int id)
        {
            Book book = repository.GetBook(id);
            if (book != null)
            {
                return TypedResults.Ok(book);
            }
            else
            {
                return TypedResults.NotFound($"Book with that ID does not exist.");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddBook(IBookRepository repository, BookPost model)
        {
            if (model == null)
            {

            }
            int newId = repository.GetBooks().Max(book => book.Id)+1;

            var newBook = new Book() { Id=newId, Title = model.Title, NumPages = model.NumPages, Author = model.Author, Genre = model.Genre };
            repository.AddBook(newBook);
            return TypedResults.Created($"/{newBook.Id}", newBook);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateBook(IBookRepository repository, int id, BookPut model)
        {
            return TypedResults.Ok(repository.UpdateBook(id, model));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> DeleteBook(IBookRepository repository, int id)
        {
            Book deleteThis = repository.DeleteBook(id);
            if (deleteThis != null)
            {
                return TypedResults.Ok(deleteThis);
            }
            else
            {
                return TypedResults.NotFound($"Book with that ID does not exist.");
            }
        }
    }
}

