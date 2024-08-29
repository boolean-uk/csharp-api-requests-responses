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

            students.MapPost("/", AddLanguage);
            students.MapGet("/", GetAllLanguages);
            students.MapGet("/{name}", GetaLanguage);
            students.MapPut("/{name}", UpdateLanguage);
            students.MapDelete("/{name}", DeleteLanguage);

        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddLanguage(IRepository<Language> rep, Language language)
        {
            Payload<Language> payload = new Payload<Language>();
            payload.Data = rep.Add(language);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllLanguages(IRepository<Language> rep)
        {
            List<Language> languages = new List<Language>();
            languages = rep.GetAll();

            return TypedResults.Ok(languages);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetaLanguage(IRepository<Language> rep, string name)
        {
            Language language = new Language(name);
            language = rep.Get(name);

            return TypedResults.Ok(language);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateLanguage(IRepository<Language> rep, string name, Language language)
        {
            Payload<Language> payload = new Payload<Language>();
            payload.Data = rep.Update(name, language);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteLanguage(IRepository<Language> rep, string name)
        {

            Language student = new Language(name);
            student = rep.Delete(name);

            return TypedResults.Ok(student);
        }
    }
}
