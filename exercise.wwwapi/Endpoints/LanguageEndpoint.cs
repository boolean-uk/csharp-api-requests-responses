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

            studentGroup.MapGet("", GetLanguage);
            studentGroup.MapPost("", CreateLanguage);
            studentGroup.MapGet("/{name}", FindLanguage);
            studentGroup.MapPut("/{name}", UpdateLanguage);
            studentGroup.MapDelete("/{name}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetLanguage(IRepository repository)
        {
            if (repository.GetAllLanguages().Count() == 0) return TypedResults.NotFound();
            return TypedResults.Ok(repository.GetAllLanguages());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateLanguage(IRepository repository, String name)
        {
            if(!name.Any()) return TypedResults.BadRequest();
            Language language = repository.CreateLanguage(name);
            return TypedResults.Created($"https://localhost:7068/students/{name}", language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> FindLanguage(IRepository repository, string name)
        {
            Language language = repository.FindLanguage(name);
            return language == null ? TypedResults.NotFound() : TypedResults.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateLanguage(IRepository repository, string name, Language language)
        {
            Language newLanguage = repository.FindLanguage(name);
            if (newLanguage == null) return TypedResults.NotFound();
            if (!name.Any()) return TypedResults.BadRequest();
            repository.updateLanguage(newLanguage, language.Name);
            return TypedResults.Ok(newLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteLanguage(IRepository repository, string name)
        {
            Language language = repository.FindLanguage(name);
            if ( language == null) return TypedResults.NotFound();
            repository.removeLanguage(name);
            return TypedResults.Ok(language);
        }

    }
}
