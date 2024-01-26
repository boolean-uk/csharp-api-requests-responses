
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    public static class BookEndpoints
    {
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            var bookGroup = app.MapGroup("");

            bookGroup.MapPost("/create a book", AddBook);
            bookGroup.MapGet("/get all book", GetBooks);
            bookGroup.MapGet("/get a book{Title}", AddBook);
            bookGroup.MapPut("/update a book {Title}", UpdateBook);
            bookGroup.MapDelete("/delete book{id}", DeleteBook);
        }



        // get all books

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks([FromServices] IRepository repository)
        {
            return TypedResults.Ok(repository.GetBooks());
        }



        // create a book or add a book
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddBook([FromServices] IRepository repository, [FromBody] BookPost book)
        {
            //validate
            if (book == null)
            {

            }
            var newBook = new Book() { Title = book.Title ,Author = book.Author,nunmPages = book.numPages, Gnre = book.Gnre};
            repository.AddBook(newBook);
            return TypedResults.Created($"/{newBook.Title}", newBook);
        }


        // update a book
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateBook([FromServices] IRepository repository, int id, [FromBody] BookPut title)
        {
            return TypedResults.Ok(repository.UpdateBook(id, title));
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteBook(int id, IRepository repository)
        {
            var bookDeleted = repository.DeleteBook(id);
            return TypedResults.Ok(bookDeleted);



        }
    }
}
