using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("languages");
            students.MapPost("/", CreateLanguage);
            //students.MapGet("/", GetAllLanguage);
            //students.MapGet("/{name}", GetLanguage);
            //students.MapPut("/{name}", UpdateLanguage);
            //students.MapDelete("/{name}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateLanguage(ILanguageRepository languageRepository, Language language)
        {
            languageRepository.AddLanguage(language);
            return TypedResults.Ok(language);
        }
    }
}
