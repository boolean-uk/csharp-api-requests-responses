using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguageEndpoints(this WebApplication app)
        {
            var languageGroup = app.MapGroup("languages");
            languageGroup.MapGet("/" , GetAllLanguages);
            languageGroup.MapPost("/" , CreateLanguage);
            languageGroup.MapPut("/{name}" , UpdateLanguage);
            languageGroup.MapDelete("/{name}" , DeleteLanguage);
        }

        public static IResult GetAllLanguages([FromServices] ILanguageRepository languages)
        {
            return Results.Ok(languages.GetAll());
        }

        public static IResult CreateLanguage([FromServices] ILanguageRepository languages , Language newLanguageData)
        {
            Language language = languages.Add(newLanguageData);
            return Results.Created($"/languages/{language.Name}" , language);
        }

        public static IResult UpdateLanguage([FromServices] ILanguageRepository languages , string name , Language updatedLanguageData)
        {
            Language? language = languages.Update(name , updatedLanguageData);
            if(language == null)
            {
                return Results.NotFound($"Language with name {name} not found.");
            }
            return Results.Ok(language);
        }

        public static IResult DeleteLanguage([FromServices] ILanguageRepository languages , string name)
        {
            Language? language = languages.Delete(name);
            if(language == null)
            {
                return Results.NotFound($"Language with name {name} not found.");
            }
            return Results.Ok(language);
        }
    }
}
