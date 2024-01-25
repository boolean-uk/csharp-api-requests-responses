using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {

        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var BookGroup = app.MapGroup("books");

            BookGroup.MapGet("/", GetBooks);
            BookGroup.MapGet("/{id}", GetABook);
            BookGroup.MapPost("/", Register);
            BookGroup.MapPut("/{id}", Update);
            BookGroup.MapDelete("/{id}", Delete);


        }

        [ProducesResponseType(StatusCodes.Status200OK)]

        public static async Task<IResult> GetBooks(IBookRepository repository)
        {
            return TypedResults.Ok(repository.GetList());
        }

        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetABook(IBookRepository repository, int input)
        {
            return TypedResults.Ok(repository.Get(input));
        }


        [ProducesResponseType(StatusCodes.Status201Created)]

        public static async Task<IResult> Register(IBookRepository repository, BookPost model)
        {
            Book book = repository.Create(model);
            return TypedResults.Created($"/{book.Id}", book);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]

        public static async Task<IResult> Update(IBookRepository repository, int id ,BookPost model)
        {
            Book updated = repository.Update(id,model);
            return TypedResults.Created($"/{updated.Id}", updated);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Delete(IBookRepository repository, int input)
        {
            Book Deleted = repository.Delete(input);
            return TypedResults.Ok(Deleted);
        }

    }
}
