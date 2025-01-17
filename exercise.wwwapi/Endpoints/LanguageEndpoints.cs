using System.Runtime.CompilerServices;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguage( this WebApplication app)
        {
            var lang = app.MapGroup("languages");
            lang.MapPost("/", AddLanguage);
            lang.MapGet("/", GetLanguages);
            lang.MapGet("/{name}", GetLanguageByName);
            lang.MapPut("/{old}", UpdateLanguage);
            lang.MapDelete("/{name}", DeleteLanguage);

        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddLanguage(ILanguageRepository repo, Language language)
        {
            try
            {
                repo.AddLanguage(language);
                return TypedResults.Ok();
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex);
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(ILanguageRepository repo)
        {
            try
            {
                var languages = repo.GetAllLanguages();
                return TypedResults.Ok(languages);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetLanguageByName(ILanguageRepository repo, string name)
        {

            var language = repo.GetLanguageByName(name);
            if (language != null)
            {
                return TypedResults.Ok(language);
            }
            else
            {
                return TypedResults.NotFound();
            }

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateLanguage(ILanguageRepository repo, string old, string newName)
        {

            var language = repo.UpdateLanguageInfo(old, newName);

            if (language != null)
            {
                return TypedResults.Ok(language);
            }
            else
            {
                return TypedResults.NotFound();
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteLanguage(ILanguageRepository repo, string name)
        {

            var language = repo.DeleteLanguage(name);
            if (language != null)
            {
                return TypedResults.Ok(language);
            }
            else
            {
                return TypedResults.NotFound();
            }

        }
    }
}

