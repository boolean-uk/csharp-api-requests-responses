using exercise.wwwapi.DTO;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using exercise.wwwapi.Responses;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguageEndpoints(this WebApplication app)
        {
            var languages = app.MapGroup("languages");

            languages.MapGet("/", GetLanguages);
            languages.MapGet("/{id}", GetLanguageById);
            languages.MapPost("/", AddLanguage);
            languages.MapPut("/{name}", UpdateLanguage);
            languages.MapDelete("/{name}", DeleteLanguage);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(IRepository<Language> repository)
        {
            var languages = repository.GetAll();
            var languageResponses = languages.Select(language => new LanguageResponse
            {
                Name = language.Name,
            });
            return Results.Ok(languageResponses);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguageById(IRepository<Language> repository, int id)
        {
            var language = repository.GetById(id);
            if (language == null)
            {
                return Results.NotFound();
            }
            var response = new LanguageResponse
            {
                Name = language.Name,
            };
            return Results.Ok(response);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddLanguage(IRepository<Language> repository, LanguageDto language)
        {
            var newLanguage = new Language
            {
                Name = language.Name,
            };
            repository.Add(newLanguage);
            var response = new LanguageResponse
            {
                Name = newLanguage.Name,
            };
            return Results.Ok(response);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateLanguage(IRepository<Language> repository, string name, LanguageDto language)
        {
            var existingLanguage = repository.GetAll().FirstOrDefault(x => x.Name == name);
            if (existingLanguage == null)
            {
                return Results.NotFound();
            }
            existingLanguage.Name = language.Name;
            repository.Update(existingLanguage);
            var response = new LanguageResponse
            {
                Name = existingLanguage.Name,
            };
            return Results.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteLanguage(IRepository<Language> repository, string name)
        {
            var deleteId = repository.GetAll().FirstOrDefault(x => x.Name == name).Id;
            var deleted = repository.Delete(deleteId);
            if (!deleted)
            {
                return Results.NotFound();
            }
            return Results.Ok(deleted);
        }
    }
}
