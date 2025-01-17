using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using exercise.wwwapi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languages = app.MapGroup("languages");

           languages.MapPost("/", LanguageCreate);
           languages.MapGet("/{name}", LanguageGet);
           languages.MapGet("/", LanguageGetAll);
           languages.MapPut("/{name}", LanguageUpdate);
           languages.MapDelete("/{name}", LanguageDelete);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> LanguageGetAll(LanguageRepository repository)
        {
            var languages= repository.GetAll();
            return Results.Ok(languages);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> LanguageGet( LanguageRepository repository, string name)
        {
            var language = repository.Get(name);
            return Results.Ok(language);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> LanguageCreate(LanguageRepository repository, LanguagePost entity)

        {
            var language = new Language(entity.name);
            

            repository.Add(language);
            return Results.Ok(repository.GetAll());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> LanguageUpdate(LanguageRepository repository, string name, LanguagePut entity)

        {
            try
            {
               
                repository.Uppdate(name ,entity.newName);
                return Results.Ok(repository.GetAll());
            }
            catch (Exception ex)
            {
                {
                    return TypedResults.Problem(ex.Message);
                }

            }

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> LanguageDelete(LanguageRepository repository, string name)

        {
            try
            {
                if (repository.Get(name) == null)
                {
                    repository.Delete(name);
                    return Results.Ok(repository.GetAll());
                }
                return Results.NotFound();
            }
            catch (Exception e)
            {
                return Results.BadRequest();
            }

        }
    }
}

