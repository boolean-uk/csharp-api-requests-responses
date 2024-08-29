using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {

        public static void ConfigureLanguage(this WebApplication app)
        {
            var languages = app.MapGroup("languages");
            languages.MapGet("/language", GetLanguages);
            languages.MapGet("/language/{name}", GetALanguage);
            languages.MapPost("/language", PostLanguage);
            languages.MapDelete("/language/{name}/", DeleteLanguage); //doesn't work after get
            languages.MapPut("/language/{name}", UpdateLanguage);
        }

        private static IResult UpdateLanguage(ILanguageRepository repo, string name, string newName)
        {
            Language language = repo.UpdateLanguage(name, newName);
            return TypedResults.Ok(language);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        private static IResult DeleteLanguage(ILanguageRepository repo, string name)
        {
            LanguageCollection.Delete(name);

            return TypedResults.Ok();
        }


        private static IResult PostLanguage(ILanguageRepository repo, string name)
        {
            Language language = repo.CreateLanguage(name);
            return TypedResults.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static IResult GetLanguages(ILanguageRepository repo)
        {
            return TypedResults.Ok(repo.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static IResult GetALanguage(ILanguageRepository repo, string name)
        {
            return TypedResults.Ok(repo.GetALanguage(name));
        }
    }
}
