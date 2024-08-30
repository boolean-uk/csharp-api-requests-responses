using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languages = app.MapGroup("languages");
            languages.MapPost("/", CreateLanguage);
            languages.MapGet("/", GetAllLanguages);
            languages.MapGet("/{languagename}", GetLanguage);
            languages.MapPut("/{languagename}", UpdateLanguage);
            languages.MapDelete("/{languagename}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateLanguage(ILanguageRepository languageRepository, Language language)
        {
            languageRepository.AddLanguage(language);
            return TypedResults.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllLanguages(ILanguageRepository languageRepository) 
        {
            return TypedResults.Ok(languageRepository.GetAllLanguages());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetLanguage(ILanguageRepository languageRepository, string languagename)
        {
            return TypedResults.Ok(languageRepository.GetLanguage(languagename));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateLanguage(ILanguageRepository languageRepository, string languagename, Language language)
        {
            return TypedResults.Ok(languageRepository.UpdateLanguage(languagename, language));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteLanguage(ILanguageRepository languageRepository, string languagename) 
        {
            return TypedResults.Ok(languageRepository.DeleteLanguage(languagename));
        }
    }
}
