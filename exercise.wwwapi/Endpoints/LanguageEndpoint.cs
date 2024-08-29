using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languages = app.MapGroup("languages");
            languages.MapGet("/", GetAll);
            languages.MapGet("/{name}", Get);
            languages.MapPost("/", Add);
            languages.MapPut("/{name}", Update);
            languages.MapDelete("/{name}", Delete);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAll(IRepository<Language, Language, string> repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult Get(IRepository<Language, Language, string> repository, string name)
        {
            var result = repository.Get(name);
            return result != null ? TypedResults.Ok(result) : TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult Add(IRepository<Language, Language, string> repository, Language entity)
        {
            var result = repository.Add(entity);
            return result != null ? TypedResults.Created($"https://localhost:7068/students/", result) : TypedResults.BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult Update(IRepository<Language, Language, string> repository, string name, Language entity)
        {
            var result = repository.Update(name, entity);
            return result != null ? TypedResults.Created($"https://localhost:7068/students/{name}", result) : TypedResults.BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult Delete(IRepository<Language, Language, string> repository, string name)
        {
            var result = repository.Delete(name);
            return result != null ? TypedResults.Ok(result) : TypedResults.NotFound();
        }

    }
}
