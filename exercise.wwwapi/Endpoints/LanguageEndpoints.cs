using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguageEndpoints(this WebApplication app)
        {
            var languages = app.MapGroup("languages");
            languages.MapPost("", CreateLanguage);
            languages.MapGet("", GetAllLanguages);
            languages.MapGet("/{name}", GetALanguage);
            languages.MapPut("/{name}", UpdateLanguage);
            languages.MapDelete("/{name}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static IResult CreateLanguage(ILanguageRepository languageRepository, Language language) 
        {
            languageRepository.AddLanguage(language);

            return TypedResults.Created();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static IResult GetAllLanguages(ILanguageRepository languageRepository)
        {
            return TypedResults.Ok(languageRepository.GetAllLanguages());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static IResult GetALanguage(ILanguageRepository languageRepository, string name)
        {
            Language language = languageRepository.GetALanguage(name);

            if (language == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static IResult UpdateLanguage(ILanguageRepository languageRepository, string name, Language newLanguage)
        {
            Language oldLanguage = languageRepository.GetALanguage(name);

            if (oldLanguage == null)
            {
                return TypedResults.NotFound(); 
            }

            if (newLanguage == null)
            {
                return TypedResults.BadRequest();
            }

            languageRepository.UpdateLanguaget(name, newLanguage);

            return TypedResults.Created();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static IResult DeleteLanguage(ILanguageRepository languageRepository, string name)
        {
            Language language = languageRepository.GetALanguage(name);

            if (language == null) { return TypedResults.NotFound(); }

            languageRepository.DeleteLanguage(name);

            return TypedResults.Ok();
        }
    }
}
