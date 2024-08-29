using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoint
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("books");

            students.MapPost("/", CreateBook);
            students.MapGet("/", GetAllBooks);
            students.MapGet("/{id}", GetaBook);
            students.MapPut("/{id}", UpdateBook);
            students.MapDelete("/{id}", DeleteBook);

        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateBook(IRepository<Book> rep, Book book)
        {
            Payload<Book> payload = new Payload<Book>();
            payload.Data = rep.Add(book);

            return TypedResults.Ok(payload);
        }  

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllBooks(IRepository<Book> rep)
        {

            List<Book> books = rep.GetAll();

            return TypedResults.Ok(books);
        } 
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetaBook(IRepository<Book> rep, int id)
        {
            Book book = rep.Get(id.ToString());

            return TypedResults.Ok(book);
        }  
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateBook(IRepository<Book> rep, int id, Book book)
        {
            Payload<Book> payload = new Payload<Book>();
            payload.Data = rep.Update(id.ToString(), book);


            return TypedResults.Ok(payload);
        }  
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteBook(IRepository<Book> rep, int id)
        {
            Book book = rep.Get(id.ToString());
            rep.Delete(id.ToString());
            return TypedResults.Ok(book);
        }
    }
}
