using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Reposity;

namespace exercise.wwwapi.Endpoints
{
    public static class EndpointsBooks
    {
        public static void ConfigueEndPointBooks(this WebApplication app)
        {
            var Books = app.MapGroup("Books");
            Books.MapPost("/", PostBooks);
            Books.MapGet("/", GetAll);
            Books.MapGet("/{Id}", Get);
            Books.MapPut("/{Id}", Update);
            Books.MapDelete("/{Id}", Delete);
        }

        public static IResult PostBooks(IRepository<Book> Books, Book Book)
        {

            Book.Id = BookCollection.getAll().Count+1;
            Books.Add(Book);
            return TypedResults.Created("/", Book);
        }

        public static IResult GetAll(IRepository<Book> Books)
        {
            return TypedResults.Ok(Books.getAll());
        }

        public static IResult Get(IRepository<Book> Books, int Id)
        {
            return TypedResults.Ok(Books.Get(Id));
        }

        public static IResult Update(IRepository<Book> Books, int Id, Book Book)
        {
            return TypedResults.Ok(Books.Update(Id, Book));
        }

        public static IResult Delete(IRepository<Book> Books, int Id)
        {
            return TypedResults.Ok(Books.Delete(Id));
        }
    }
}
