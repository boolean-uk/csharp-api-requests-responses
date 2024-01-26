using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints.cs
{
    public static class LanguageEndpoint
    {
        //Extension method to configure the /languages endpoint
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            // Create a group for endpoints related to languages
            var languageGroup = app.MapGroup("languages");

            // Map the GET request to /languages
            languageGroup.MapGet("/", GetLanguages);

            // Map the POST request to /languages
            languageGroup.MapPost("/", AddLanguage);

            // Map the GET request to retrieve a single language by name
            languageGroup.MapGet("/{name}", GetLanguage);

            // Map the PUT request to update a language by name
            languageGroup.MapPut("/{name}", UpdateLanguage);

            // Map the DELETE request to delete a language by name
            languageGroup.MapDelete("/{name}", DeleteLanguage);
        }

        // Handler for the GET request to /languages
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(IRepository repository)
        {
            // Return a 200 OK response with the list of languages
            return TypedResults.Ok(repository.GetLanguages());
        }

        // Handler for the POST request to /languages
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddLanguage(IRepository repository, Language language)
        {
            // Add the language to the repository
            var addedLanguage = repository.AddLanguage(language);

            // Return a 201 Created response with the added language's details
            return TypedResults.Created($"/languages/{addedLanguage.Name}", addedLanguage);
        }

        // Handler for the GET request to retrieve a single language by name
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetLanguage(IRepository repository, string name)
        {
            // Retrieve the language with the provided name from the repository
            var language = repository.GetLanguage(name);

            // Check if the language was found
            if (language == null)
            {
                // If not found, return a 404 Not Found response with an error message
                return TypedResults.NotFound($"Language with name '{name}' not found.");
            }

            // If found, return a 200 OK response with the language details
            return TypedResults.Ok(language);
        }

        // Handler for the PUT request to update a language by name
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateLanguage(IRepository repository, string name, Language updatedLanguage)
        {
            // Attempt to update the language by name
            var result = repository.UpdateLanguage(name, updatedLanguage);

            // Check if the language was found and updated
            if (result == null)
            {
                // If not found, return a 404 Not Found response with an error message
                return TypedResults.NotFound($"Language with name '{name}' not found.");
            }

            // If found and updated, return a 201 Created response with the updated language details
            return TypedResults.Created($"/languages/{result.Name}", result);
        }

        // Handler for the DELETE request to delete a language by name
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteLanguage(IRepository repository, string name)
        {
            // Attempt to delete the language by name
            var result = repository.DeleteLanguage(name);

            // Check if the language was found and deleted
            if (result == null)
            {
                // If not found, return a 404 Not Found response with an error message
                return TypedResults.NotFound($"Language with name '{name}' not found.");
            }

            // If found and deleted, return a 200 OK response with the deleted language details
            return TypedResults.Ok(result);
        }
    }
}

