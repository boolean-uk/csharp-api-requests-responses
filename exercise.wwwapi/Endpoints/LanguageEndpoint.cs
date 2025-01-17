using exercise.wwwapi.Models;

using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languages = app.MapGroup("languages");
            languages.MapGet("/", GetLanguages);
            languages.MapGet("/{name}", GetLanguage);
            languages.MapPost("/AddLanguage", AddLanguage);
            languages.MapPut("/UpdateLanguage", UpdateLanguage);
            languages.MapDelete("/DeleteLanguage", DeleteLanguage);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetLanguages(IRepository<Language> repository)
        {

            return TypedResults.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetLanguage(IRepository<Language> repository, string name)
        {

            return TypedResults.Ok(repository.Get(name));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddLanguage(IRepository<Language> repository, Language model) {
            
            return TypedResults.Ok(repository.Add(model));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateLanguage(IRepository<Language> repository, Language newModel, string name)
        {
            return TypedResults.Ok(repository.Update(newModel, name));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteLanguage(IRepository<Language> repository, string name)
        {
            return TypedResults.Ok(repository.Delete(name));
        }
    }
}
