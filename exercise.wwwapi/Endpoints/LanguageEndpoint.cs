using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using exercise.wwwapi.Models;
using exercise.wwwapi.Models.DTO;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languageGroup = app.MapGroup("languages");

            languageGroup.MapGet("/", GetLanguages); //get all
            languageGroup.MapGet("/{provideName}", GetALanguage); //get a 
            languageGroup.MapPost("/{providedName}", AddLanguage); //add
            languageGroup.MapDelete("/{providedName}", DeleteLanguage); //delete
            languageGroup.MapPut("/{providedName}", UpdateLanguage); //update
        }

        //get all
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(IRepository<Language> languageRepository) 
        {
            var results = await languageRepository.Get();
            Payload<IEnumerable<Language>> payload = new Payload<IEnumerable<Language>>();
            payload.data = results;
            return Results.Ok(payload);
        }


        //get a
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetALanguage(IRepository<Language> repository, string providedName) 
        {
            var languages = await repository.Get();
            if (languages.Any(x => x.name.Equals(providedName, StringComparison.OrdinalIgnoreCase)))
            {
                var language = languages.Where(x => x.name.Equals(providedName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                return Results.Ok(language);
            }
            else
            {
                return Results.NotFound("Language not found");
            }
        }


        //add
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddLanguage(IRepository<Language> repository, LanguagePost lan) 
        {
            var languages = await repository.Get();

            if (languages.Any(x => x.name.Equals(lan.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return Results.BadRequest("Language with provided name already exists");
            }
            int id = languages.Max(x => x.Id) + 1;
            var entity = new Language() { Id = id, name = lan.Name };
            repository.Insert(entity);
            return TypedResults.Created($"/{entity}");
        }


        //delete
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> DeleteLanguage(IRepository<Language> repository, string lan) 
        {
            var languages = await repository.Get();
            if (languages.Any(x => x.name.Equals(lan, StringComparison.OrdinalIgnoreCase)))
            {
                var language = languages.Where(x => x.name.Equals(lan, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                var id = language.Id;
                repository.Delete(id);
                return Results.Ok("Language deleted: " + language.name);
            }
            return Results.BadRequest("Language can't be deleted");
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateLanguage(IRepository<Language> repository, string lan, LanguagePut newLanguage)
        {
            var languages = await repository.Get();

            if (languages.Any(x => x.name.Equals(lan, StringComparison.OrdinalIgnoreCase)))
            {

                var language = languages.Where(x => x.name.Equals(lan, StringComparison.OrdinalIgnoreCase)).First();
                if (languages.Any(x => x.name.Equals(newLanguage.Name, StringComparison.OrdinalIgnoreCase)))

                {
                    return Results.BadRequest("Language with this name already exists.");
                }
                var oldname = language.name;
                language.name = newLanguage.Name;
                repository.Update(language);
                return TypedResults.Created($"/{language}");
            }
            return Results.BadRequest("Language can't be updated");
        }
    }
}
