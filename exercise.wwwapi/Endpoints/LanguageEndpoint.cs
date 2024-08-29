using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
    
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("Languages");
            students.MapGet("/getAll", getLanguages);
            students.MapGet("/get/{name}", getALanguage);
            students.MapPost("/create", createALanguage);
            students.MapPut("/edit/{name}", editALanguage);
            students.MapDelete("/delete/{name}", deleteALanguage);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult getLanguages(IRepository<Language> languages)
        {
            var currentLanguages = languages.getAll();
            return TypedResults.Ok(currentLanguages);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult getALanguage(IRepository<Language> languages, string name)
        {
            var language = languages.getElementByName(name);
            return TypedResults.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult createALanguage(IRepository<Language> languages, string name, [FromBody] Language language)
        {
            languages.createElement(language);
            return TypedResults.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult editALanguage(IRepository<Language> languages, [FromBody] Language language)
        {
            languages.updateElement(language);
            return TypedResults.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult deleteALanguage(IRepository<Language> languages, string name)
        {

            languages.deleteElement(name);
            return TypedResults.Ok(languages.getElementByName(name));
        }



    }

}

