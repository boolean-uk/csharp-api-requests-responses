using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints.cs
{
    public static class BookEndpoint
    {
        // Extension method to configure the /books endpoint
        public static void ConfigureBookEndpoint(this WebApplication app)
        {
            // Create a group for endpoints related to books
            var bookGroup = app.MapGroup("books");

            // Map the GET request to /books
            bookGroup.MapGet("/", GetBooks);

            // Map the POST request to /books
            bookGroup.MapPost("/", CreateBook);

            // Map the GET request to retrieve a single book by ID
            bookGroup.MapGet("/{id}", GetBook);

            // Map the PUT request to update a book by ID
            bookGroup.MapPut("/{id}", UpdateBook);

            // Map the DELETE request to delete a book by ID
            bookGroup.MapDelete("/{id}", DeleteBook);
        }


        // Handler for the GET request to /books
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetBooks(IRepository repository)
        {
            // Return a 200 OK response with the list of books
            return TypedResults.Ok(repository.GetBooks());
        }

        // Handler for the POST request to /books
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateBook(IRepository repository, Book book)
        {
            // Add the book to the repository
            var addedBook = repository.AddBook(book);

            // Return a 201 Created response with the added book's details
            return TypedResults.Created($"/books/{addedBook.Id}", addedBook);
        }

        // Handler for the GET request to retrieve a single book by ID
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetBook(IRepository repository, int id)
        {
            // Retrieve the book with the provided ID from the repository
            var book = repository.GetBook(id);

            // Check if the book was found
            if (book == null)
            {
                // If not found, return a 404 Not Found response with an error message
                return TypedResults.NotFound($"Book with ID '{id}' not found.");
            }

            // If found, return a 200 OK response with the book details
            return TypedResults.Ok(book);
        }

        // Handler for the PUT request to update a book by ID
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateBook(IRepository repository, int id, Book updatedBook)
        {
            // Attempt to update the book by ID
            var result = repository.UpdateBook(id, updatedBook);

            // Check if the book was found and updated
            if (result == null)
            {
                // If not found, return a 404 Not Found response with an error message
                return TypedResults.NotFound($"Book with ID '{id}' not found.");
            }

            // If found and updated, return a 201 Created response with the updated book details
            return TypedResults.Created($"/books/{result.Id}", result);
        }

        // Handler for the DELETE request to delete a book by ID
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteBook(IRepository repository, int id)
        {
            // Attempt to delete the book by ID
            var result = repository.DeleteBook(id);

            // Check if the book was found and deleted
            if (result == null)
            {
                // If not found, return a 404 Not Found response with an error message
                return TypedResults.NotFound($"Book with ID '{id}' not found.");
            }

            // If found and deleted, return a 200 OK response with the deleted book details
            return TypedResults.Ok(result);
        }
    }
}
