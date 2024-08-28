using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguageEndpoints(this WebApplication App)
        {
            var LanguageGroup = App.MapGroup("languages");
            LanguageGroup.MapPost("/", AddLanguage);
            LanguageGroup.MapGet ("/", GetAllLanguages);
            LanguageGroup.MapGet("/{name}", GetLanguage);
            LanguageGroup.MapPut("/{name}", UpdateLanguage);
            LanguageGroup.MapDelete("/{name}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddLanguage(ILanguageRepository repository, Language language)
        {
            repository.Create(language);

            return TypedResults.Created($"/languages/{language.Name}", language);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllLanguages(ILanguageRepository repository)
        {
            var languages = repository.GetAll();

            return TypedResults.Ok(languages);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetLanguage(ILanguageRepository repository, string name)
        {
            var language = repository.Get(name);

            return TypedResults.Ok(language);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateLanguage(ILanguageRepository repository, string name, Language language)
        {
            var updatedLanguage = repository.Update(name, language);

            return TypedResults.Created($"/languages/{name}", updatedLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteLanguage(ILanguageRepository repository, string name)
        {
            var deletedLanguage = repository.Delete(name);

            return TypedResults.Ok(deletedLanguage);
        }


    }
}
