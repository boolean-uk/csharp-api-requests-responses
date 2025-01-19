using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;


namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var language = app.MapGroup("languages");

            language.MapGet("/", GetAll);
            language.MapGet("/{name}", GetLanguage);
            language.MapPost("/", AddLanguage);
            language.MapDelete("/{name}", DeleteLanguage);
            language.MapPut("/{oldName}", UpdateLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository2 repository)
        {
            try
            {
                var languages = repository.GetAllLanguages();
                return TypedResults.Ok(languages);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetLanguage(IRepository2 repository, string name)
        {

            var language = repository.GetLanguage(name);
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
        public static async Task<IResult> AddLanguage(IRepository2 repository, Language language)
        {

            if (language != null)
            {
                repository.AddLanguage(language);
                return TypedResults.Ok(language);
            }
            else
            {
                return TypedResults.NotFound();
            }


        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteLanguage(IRepository2 repository, string name)
        {

            var language = repository.DeleteLanguage(name);
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
        public static async Task<IResult> UpdateLanguage(IRepository2 repository, string oldName, string newName)
        {

            var language = repository.UpdateLanguage(oldName, newName);

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
