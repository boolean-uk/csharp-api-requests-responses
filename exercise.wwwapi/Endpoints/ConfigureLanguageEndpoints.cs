using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using exercise.wwwapi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class ConfigureLanguageEndpoints
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var counters = app.MapGroup("languages");

            counters.MapGet("/", GetLanguages);
            counters.MapGet("/find/{name}", GetLanguageByName);
            counters.MapGet("/{id}", GetLanguage);
            counters.MapPost("/", PostLanguage);
            counters.MapPut("/{id}", PutLanguage);
            counters.MapDelete("/{id}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(IGenericRepository<Language> repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetLanguage(IGenericRepository<Language> repository, int id)
        {
            try
            {
                return TypedResults.Ok(repository.Get(id));
            }
            catch (ArgumentException ex)
            {
                return TypedResults.NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetLanguageByName(IGenericRepository<Language> repository, string name)
        {
            try
            {
                return TypedResults.Ok(repository.Get((language) => language.Name.ToLower() == name.ToLower()));
            }
            catch (ArgumentException ex)
            {
                return TypedResults.NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> PostLanguage(IGenericRepository<Language> repository, LanguagePost entity)
        {
            Language Language = repository.Add(new Language { Name = entity.Name });
            return TypedResults.Created("", Language);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> PutLanguage(IGenericRepository<Language> repository, int id, LanguagePut entity) 
        {
            Language Language = repository.Update(id, new Language { Name = entity.Name });
            return TypedResults.Created("", Language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteLanguage(IGenericRepository<Language> repository, int id)
        {
            try
            {
                Language Language = repository.Get(id);
                return TypedResults.Ok(new { Deleted = repository.Delete(id), Name = $"{Language.Name}" });
            }
            catch (ArgumentException ex)
            {
                return TypedResults.NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
