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

            studentGroup.MapGet("/", GetLanguages);
            studentGroup.MapGet("/{name}", GetLanguage);
            studentGroup.MapPost("/", CreateLanguage);
            studentGroup.MapPut("/{name}", UpdateLanguage);
            studentGroup.MapDelete("/", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(ILanguageRepository repository)
        {
            return TypedResults.Ok(repository.GetLanguages());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateLanguage(ILanguageRepository repository, Language language)
        {
            if (!language.Name.Any())
            {
                return Results.BadRequest("Missing some data");
            }
            repository.AddLanguage(language);
            return TypedResults.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetLanguage(ILanguageRepository repository, string name)
        {
            var language = repository.GetLanguages().First(s => s.Name.ToLower() == name.ToLower());

            if (language != null) return TypedResults.Ok(language);
            return Results.NotFound($"Language: {name} not found!");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateLanguage(ILanguageRepository repository, string name, Language newLanguage)
        {
            var language = repository.GetLanguages().FirstOrDefault(s => s.Name.ToLower() == name.ToLower());

            if (language == null) return Results.NotFound($"Language: {name} not found!");
            if (!language.Name.Any()) return Results.BadRequest("Missing some data");

            language.Update(newLanguage.Name);
            return TypedResults.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteLanguage(ILanguageRepository repository, string name)
        {
            var language = repository.GetLanguages().First(s => s.Name.ToLower() == name.ToLower());

            if (language == null) return Results.NotFound($"Language: {name} not found!");

            repository.DeleteLanguage(language);
            return TypedResults.Ok(language);

        }
    }
}
