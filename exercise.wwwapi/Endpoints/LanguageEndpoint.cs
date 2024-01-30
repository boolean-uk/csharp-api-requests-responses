using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;





namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
       public static void ConfigureLanguageEndpoints(this WebApplication app)
        {
            var languageGroup = app.MapGroup("languages");

            languageGroup.MapGet("/", GetLanguages);
            languageGroup.MapGet("/{name}", GetLanguage);
            languageGroup.MapPost("/", AddLanguage);
            languageGroup.MapPut("/{name}", UpdateLanguage);
            languageGroup.MapDelete("/{name}", DeleteLanguage);
            
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(IRepo<Language> language)
        {
            var languages = language.GetAll();
            return TypedResults.Ok(languages);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguage(IRepo<Language> language, string name)
        {
            return TypedResults.Ok(language.GetSingle(x => x.name == name));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult>AddLanguage(IRepo<Language> language, LanguagePost codelanguage)
        {
            if(language.GetAll().Any(x => x.name.Equals(codelanguage.name, StringComparison.OrdinalIgnoreCase)))
            {
                return Results.BadRequest("Language with provided name already exists");
            }

            var entity = new Language() { name = codelanguage.name };
            language.Add(entity);
            return TypedResults.Created($"/{entity.name}", entity);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateLanguage(IRepo<Language> language, string oldlanguage, LanguagePut newlanguage)
        {
            if(!language.GetAll().Any(x => x.name == oldlanguage))
            {
                return TypedResults.NotFound("Language not found");
            }
            var entity = language.GetSingle(x => x.name == oldlanguage);

            if(newlanguage.name != null)
            {
                if (language.GetAll().Any(x => x.name == newlanguage.name))
                {
                    return Results.BadRequest("Language already exists in the list");
                }
            }
            entity.name = newlanguage.name != null ? newlanguage.name : entity.name;

            language.Update(entity);

            return TypedResults.Created($"/{entity.name}", entity);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteLanguage(IRepo<Language> language, string name)
        {
            if(!language.GetAll().Any(y => y.name == name))
            {
                return TypedResults.NotFound("Language not found");
            }    
            var entity = language.Remove(x => x.name == name);
            return entity != null ? TypedResults.Ok(entity) : TypedResults.NotFound();
        }
    }
}
