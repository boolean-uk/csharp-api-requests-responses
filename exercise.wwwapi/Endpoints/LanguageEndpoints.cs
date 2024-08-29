using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguageEndpoints(this WebApplication app)
        {
            var students = app.MapGroup("languages");
            students.MapGet("", GetStudents);
            students.MapGet("/{name}", GetStudent);
            students.MapPost("", Add);
            students.MapPut("/{name}", Update);
            students.MapDelete("/{name}", Delete);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetStudents(IRepo<Language> langRepository)
        {
            return TypedResults.Ok(langRepository.getAll());
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult Add(IRepo<Language> langRepository, Language language)
        {
            langRepository.Add(language);

            return TypedResults.Created();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetStudent(IRepo<Language> langRepository, string name)
        {
            Language language = langRepository.Get(name);
            if (language == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult Update(IRepo<Language> langRepository, Language language, string name)
        {
            Language oldlanguage = langRepository.Get(name);
            if (oldlanguage == null)
            {
                return TypedResults.NotFound();
            }
            if (language == null)
            {
                return TypedResults.BadRequest();
            }

            langRepository.Update(language, name);
            return TypedResults.Created();
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult Delete(IRepo<Language> langRepository, string name)
        {
            Language language = langRepository.Get(name);
            if (language == null)
            {
                return TypedResults.NotFound();
            }

            langRepository.Delete(name);

            return TypedResults.Ok();
        }


    }
}
