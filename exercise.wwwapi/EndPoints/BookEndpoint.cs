using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.EndPoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var books = app.MapGroup("books");
            books.MapGet("/", GetAllBooks);
            books.MapGet("/{id}", GetSingleBook);
            books.MapPost("/", CreateBook);
            books.MapPut("/{id}", UpdateBook);
            books.MapDelete("/{id}", DeleteBook);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllBooks(BookRepository repository)
        {

            return TypedResults.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetSingleBook(BookRepository repository, int id)
        {

            return TypedResults.Ok(repository.Get(id));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateBook(BookRepository repository, Book book)
        {
            return TypedResults.Ok(repository.Create(book));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]

        public static IResult UpdateBook(BookRepository repository, Book book, int id)
        {

            return TypedResults.Ok(repository.Update(id, book));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteBook(BookRepository repository, int id)
        {

            return TypedResults.Ok(repository.Delete(id));

        }
    }
    }
