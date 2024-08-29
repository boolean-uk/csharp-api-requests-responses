using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndPoint
    {
        private static LanguageCollection languageCollection = new LanguageCollection();

        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languages = app.MapGroup("languages");
            languages.MapGet("/", GetAllLanguages);
            languages.MapGet("/{name}", GetOneLanguage);
            languages.MapPost("/", CreateLanguage);
            languages.MapPut("/{name}", UpdateLanguage);
            languages.MapDelete("/{name}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllLanguages()
        {
            return TypedResults.Ok(languageCollection.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetOneLanguage(string name)
        {
            Language language = languageCollection.GetALanguage(name);
            if(language == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateLanguage(string name)
        {
            Language language = new Language(name);
            languageCollection.Add(language);
            return TypedResults.Created("", language);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult UpdateLanguage(string name, string newName)
        {
            Language lToBeUpdated = languageCollection.GetALanguage(name);
            if (lToBeUpdated == null)
            {
                return TypedResults.NotFound();
            }
            lToBeUpdated.name = newName;
            return TypedResults.Created(name, lToBeUpdated);
        }

        public static IResult DeleteLanguage(string name)
        {
            Language lToBeRemoved = languageCollection.GetALanguage(name);
            if (lToBeRemoved == null)
            {
                return TypedResults.NotFound();
            }
            languageCollection.Remove(lToBeRemoved);
            return TypedResults.Ok(lToBeRemoved);
        }


    }
}
