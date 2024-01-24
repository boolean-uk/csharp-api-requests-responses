using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languageGroup = app.MapGroup("languages");

            languageGroup.MapPost("/", CreateLanguage);
            languageGroup.MapGet("/", GetAllLanguages);
            languageGroup.MapGet("/{name}", GetLanguage);
            languageGroup.MapPut("/{name}", UpdateLanguage);
            languageGroup.MapDelete("/{name}", DeleteLanguage);

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateLanguage(IRepository repository, string name)
        {

            return TypedResults.Created($"/languages/{name}", repository.PostLanguage(name));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllLanguages(IRepository repository)
        {
            return TypedResults.Ok(repository.GetLanguages());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetLanguage(IRepository repository, string name)
        {
            Language? lang = repository.GetSpecificLanguage(name);
            if (lang != null)
            {
                return TypedResults.Ok(lang);
            }
            else
            {
                return TypedResults.NotFound($"Could not find languages with the name of {name}");
            }

        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateLanguage(IRepository repository, string name, string newName)
        {
            Language? lang = repository.UpdateLanguageName(name, newName);
            if (lang != null)
            {
                return TypedResults.Created($"/languages/{newName}", lang);
            }
            else
            {
                return TypedResults.NotFound($"Language with {name} was not found.");
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteLanguage(IRepository repository, string name)
        {
            Language? lang = repository.DeleteLanguage(name);
            if (lang != null)
            {
                return TypedResults.Ok(lang);
            }
            else
            {
                return TypedResults.NotFound($"Could not find language with the name of {name}");
            }
        }

    }
}
