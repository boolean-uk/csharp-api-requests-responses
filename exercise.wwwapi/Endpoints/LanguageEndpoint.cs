using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEnpoint(this WebApplication app)
        {
            var languageGroup = app.MapGroup("languages");

            languageGroup.MapGet("/", GetLanguages);
            languageGroup.MapGet("/{name}", GetLanguage);
            languageGroup.MapPost("/", AddLanguage);
            languageGroup.MapPut("/{name}", UpdateLanguage);
            languageGroup.MapDelete("/{name}", DeleteLanguage);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(IRepository<Language> repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguage(IRepository<Language> repository, string name)
        {
            return TypedResults.Ok(repository.Get(name));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddLanguage(IRepository<Language> repository, Language language)
        {
            if (language == null)
            {
                return Results.NotFound($"Language is null");
            }
            repository.Add(language);
            return TypedResults.Created($"/{language.Name}", language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateLanguage(IRepository<Language> repository, string name, Language language)
        {
            if (language == null)
            {
                return Results.NotFound($"Language {name} was not found" );
            }

            return TypedResults.Ok(repository.Update(name, language));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteLanguage(IRepository<Language> repository, string name)
        {
            if(name == null)
            {
                return Results.NotFound($"Language {name} was not found");
            }

            return TypedResults.Ok(repository.Delete(name));
        }
    }
}
