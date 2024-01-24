using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("languages");

            studentGroup.MapPost("/", AddLanguage);

            studentGroup.MapGet("/", GetLanguages);

            studentGroup.MapGet("/{Name}", GetLanguage);

            studentGroup.MapPut("/{Name}", UpdateLanguage);

            studentGroup.MapDelete("/{Name}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(IRepository repository)
        {
            return TypedResults.Ok(repository.GetLanguages());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguage(IRepository repository, string name)
        {
            var language = repository.GetLanguage(name);

            if (language == null)
            {
                return TypedResults.NotFound($"Language with name {name} was not found");
            }

            return TypedResults.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddLanguage(IRepository repository, string name)
        {
            return TypedResults.Created(name, repository.AddLanguage(name));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateLanguage(IRepository repository, string oldName, string newName)
        {
            var updatedLanguage = repository.UpdateLanguage(oldName, newName);

            if (updatedLanguage == null)
            {
                return TypedResults.NotFound($"Language with name {oldName} was not found");
            }

            return TypedResults.Created(newName, updatedLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteLanguage(IRepository repository, string name)
        {
            var deletedLanguage = repository.DeleteLanguage(name);

            if (deletedLanguage == null)
            {
                return TypedResults.NotFound($"Language with name {name} was not found");
            }

            return TypedResults.Ok(deletedLanguage);
        }
    }
}
