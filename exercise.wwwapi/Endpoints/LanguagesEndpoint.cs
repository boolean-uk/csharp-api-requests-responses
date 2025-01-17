using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguagesEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("languages");

            students.MapPost("/", AddLanguage);
            students.MapGet("/", GetLanguages);
            students.MapGet("/{name}", GetLanguage);
            students.MapPut("/{name}", UpdateLanguage);
            students.MapDelete("/{name}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddLanguage(ILanguageRepository repository, Language language)
        {
            repository.Add(language);

            return TypedResults.Created($"https://localhost:7068/students/{language.Name}", language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(ILanguageRepository repository)
        {
            return Results.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguage(ILanguageRepository repository, string name)
        {
            return Results.Ok(repository.Get(name));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateLanguage(ILanguageRepository repository, string name, Language language)
        {
            repository.Update(name, language);

            return Results.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteLanguage(ILanguageRepository repository, string name)
        {
            repository.Delete(name);

            return Results.Ok();
        }
    }
}
