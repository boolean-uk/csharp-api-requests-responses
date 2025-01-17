using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using exercise.wwwapi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoints(this WebApplication app)
        {
            var languages = app.MapGroup("languages");

            languages.MapGet("/", GetAll);
            languages.MapGet("/{name}", GetLanguage);
            languages.MapPost("/", AddLanguage);
            languages.MapDelete("/{name}", RemoveLanguage);
            languages.MapPut("/{name}", UpdateLanguage);


        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository<Language> rep)
        {
            var languages = rep.GetAll();
            return Results.Ok(rep.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetLanguage(IRepository<Language> rep, string name)
        {
            try
            {
                Language language = rep.GetEntity(name);

                if (language == null) return Results.NotFound();

                return Results.Ok(language);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddLanguage(IRepository<Language> rep, PostLanguage model)
        {
            try
            {
                Language language = new Language(model.Name);
               
                rep.AddEntity(language);
                return Results.Ok(language);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }

        }

        // Returns the deletetd student
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> RemoveLanguage(IRepository<Language> rep, string firstname)
        {

            try
            {
                Language student = rep.RemoveEntity(firstname);

                if (student == null) return Results.NotFound();

                return Results.Ok(student);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateLanguage(IRepository<Language> rep, string name, PutLanguage model)
        {
            try
            {
                Language language = rep.GetEntity(name);

                if (language == null) return Results.NotFound();
                if (model.Name != null) language.Name = model.Name;

                return Results.Ok(language);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }


    }
}
