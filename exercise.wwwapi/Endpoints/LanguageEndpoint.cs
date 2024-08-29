using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
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
            languages.MapPost("/", Create);
            languages.MapPut("/{name}", Update);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAll(IRepository<Language> repository)
        {
            Payload<List<Language>> payload = new Payload<List<Language>>();
            payload.data = repository.GetAll();
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult Get(IRepository<Language> repository, string name)
        {
            Payload<Language> payload = new Payload<Language>();
            payload.data = repository.Get(name);

            if (payload.data == null)
            {
                return TypedResults.NotFound($"Language {name} not found.");
            }

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult Create(IRepository<Language> repository, Language model)
        {
            Payload<Language> payload = new Payload<Language>();
            payload.data = repository.Add(model);
            if (payload.data == null)
            {
                return TypedResults.BadRequest($"Language {model.Name} already exists.");
            }
            return TypedResults.Created($"https://localhost:7068/language/{payload.data.Name}", payload.data);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult Update(IRepository<Language> repository, string name, Language model)
        {
            Payload<Language> payload = new Payload<Language>();
            payload.data = repository.Update(name, model);
            if (payload.data == null)
            {
                return TypedResults.NotFound($"Language {name} not found.");
            }
            return TypedResults.Created($"https://localhost:7068/students/{payload.data.Name}", payload.data);
        }
    }
}
