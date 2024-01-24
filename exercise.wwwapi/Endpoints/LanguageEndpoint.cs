using exercise.wwwapi.DTOs;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languageGroup = app.MapGroup("languages");

            languageGroup.MapGet("/", GetLanguages);
            languageGroup.MapGet("/{id}", GetLanguage);
            languageGroup.MapDelete("/{id}", DeleteLanguage);
            languageGroup.MapPut("/{id}", PutLanguage);
            languageGroup.MapPost("/", AddLanguage);
        }

        public static IResult GetLanguages(IRepository<Language> languages)
        {
            return TypedResults.Ok(languages.GetAll());
        }

        public static IResult GetLanguage(IRepository<Language> languages, string id)
        {
            try
            {
                Language language = languages.GetById(id);
                return TypedResults.Ok(language);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        public static IResult DeleteLanguage(IRepository<Language> languages, string id)
        {
            try
            {
                Language language = languages.DeleteById(id);
                return TypedResults.Ok(language);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        public static IResult AddLanguage(IRepository<Language> languages, AddLanguageDTO languageDTO)
        {
            Language language = new(languageDTO.Name);
            languages.Add(language);
            return TypedResults.Created(nameof(GetLanguage), language);
        }

        public static IResult PutLanguage(IRepository<Language> languages, string id, AddLanguageDTO languageDTO)
        {
            try
            {
                Language language = languages.GetById(id);
                language.Name = languageDTO.Name;
                return TypedResults.Ok(language);
            } catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }
    }
}
