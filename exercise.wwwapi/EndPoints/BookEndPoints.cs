using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.EndPoints
{
    public static class BookEndPoints
    {
        public static void ConfigureBookEndpoints(this WebApplication app)
        {
            var taskGroup = app.MapGroup("books");
            taskGroup.MapPost("/", AddBook);
            taskGroup.MapGet("/", GetAllBooks);
            taskGroup.MapGet("/{id}", GetBookWithId);
            taskGroup.MapDelete("/{id}", DeleteBooksWithId);
            taskGroup.MapPut("/{id}", UpdateBookWithId);

            //taskGroup.MapPut("/{id}", UpdateTask);
        }

        public static IResult AddBook(BookPayload bookPayload, IBookRepository bookRepository
            )
        {
            Book book = new Book(bookPayload);
            bookRepository.Add(book);
            string url = "";
            return Results.Created(url, book);
        }

        public static IResult GetAllBooks(IBookRepository bookRepository
            )
        {
            return Results.Ok(bookRepository.GetAll());
        }

        public static IResult GetBookWithId(int Id, IBookRepository bookRepository)
        {
            List<Book> filt = bookRepository.GetAll().Where(book => book.Id == Id).ToList();
            if(filt.Count < 1) { return Results.NotFound(); }
            return Results.Ok(filt);
        }

        public static IResult DeleteBooksWithId(int Id, IBookRepository bookRepository)
        {
            Book? book = bookRepository.GetAll().FirstOrDefault(book => book.Id == Id);

            bool result = bookRepository.Delete(book);

            if (result) { return Results.Ok(book); }
            return Results.NotFound();
        }

        public static IResult UpdateBookWithId(int Id, BookUpdatePayload updateBookData, IBookRepository bookRepository)
        {
            Book? bookToUpdate = bookRepository.GetAll().FirstOrDefault(s => s.Id == Id);

            if (bookToUpdate == null)
            {
                return Results.NotFound($"No book found with Id {Id}");
            }

            bool result = bookToUpdate.UpdateInfo(updateBookData);

            return Results.Ok(bookToUpdate);
        }
    }
}