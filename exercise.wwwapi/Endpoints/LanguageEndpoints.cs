using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languageGroup = app.MapGroup("languages");

            languageGroup.MapGet("/", GetLanguages);
            languageGroup.MapPost("/", AddLanguage);
            languageGroup.MapGet("/{name}", GetLanguage);
            languageGroup.MapPut("/{name}", UpdateLanguage);
            languageGroup.MapDelete("/delete/{name}", DeleteLanguage);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(LanguageCollection languageCollection)
        {
            return TypedResults.Ok(languageCollection.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddLanguage(LanguageCollection languageCollection, Language language)
        {
            var newLanguage = new Language(name: language.name);
            languageCollection.Add(newLanguage);
            return TypedResults.Created("/", newLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguage(LanguageCollection languageCollection, string name)
        {
            return TypedResults.Ok(languageCollection.GetLanguage(name));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]

        public static async Task<IResult> UpdateLanguage(LanguageCollection languageCollection, string name)
        {
            return TypedResults.Ok(languageCollection.UpdateLanguage(name));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]

        public static async Task<IResult> DeleteLanguage(LanguageCollection languageCollection, string name)
        {
            return TypedResults.Ok(languageCollection.DeleteLanguage(name));
        }
    }

}

