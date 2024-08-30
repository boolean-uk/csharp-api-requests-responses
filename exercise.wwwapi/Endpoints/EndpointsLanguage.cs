using exercise.wwwapi.Models;
using exercise.wwwapi.Reposity;
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Reposity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class EndpointsLanguage
    {
        public static void ConfigueEndPointLanguages(this WebApplication app)
        {
            var languages = app.MapGroup("languages");
            languages.MapPost("/", PostLanguages);
            languages.MapGet("/", GetAll);
            languages.MapGet("/{Name}", Get);
            languages.MapPut("/{Name}", Update);
            languages.MapDelete("/{Name}", Delete);
        }

        public static IResult PostLanguages(IRepository<Language> languages, Language language)
        {
            languages.Add(language);
            return TypedResults.Created("/", language);
        }

        public static IResult GetAll(IRepository<Language> languages)
        {
            return TypedResults.Ok(languages.getAll());
        }

        public static IResult Get(IRepository<Language> languages, string Name)
        {
            return TypedResults.Ok(languages.Get(Name));
        }

        public static IResult Update(IRepository<Language> languages, string Name, Language language)
        {
            return TypedResults.Ok(languages.Update(Name, language));
        }

        public static IResult Delete(IRepository<Language> languages, string Name)
        {
            return TypedResults.Ok(languages.Delete(Name));
        }
    }
}
