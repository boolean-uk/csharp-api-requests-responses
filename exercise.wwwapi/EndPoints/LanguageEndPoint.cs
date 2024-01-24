using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.EndPoints
{
    public static class LanguageEndPoint
    {
        public static void ConfigureLanguageEndPoint(this WebApplication app)
        {
            var LanguageGroup = app.MapGroup("/languages");
            LanguageGroup.MapGet("/", GetAllLanguages);
            LanguageGroup.MapPost("/", AddLanguage);
            LanguageGroup.MapGet("/{name}", GetLanguage);
            LanguageGroup.MapDelete("/{name}", DeleteLanguage);
            LanguageGroup.MapPut("/{name}", UpdateLanguage);
        }

        public static IResult GetAllLanguages(ILanguageRepository languageRepository)
        {
            try
            {
                return Results.Ok(languageRepository.GetAllLanguages());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static IResult AddLanguage(ILanguageRepository languageRepository, string name)
        {
            try
            {
                Language language = languageRepository.AddLanguage(name);
                return Results.Created($"/languages/{language.name}", language);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    
        public static IResult GetLanguage(ILanguageRepository languageRepository, string name)
        {
            try
            {
                Language? language = languageRepository.GetLanguage(name);
                if (language == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(language);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static IResult DeleteLanguage(ILanguageRepository languageRepository, string name)
        {
            try
            {
                Language? language = languageRepository.GetLanguage(name);
                if (language == null)
                {
                    return Results.NotFound();
                }

                languageRepository.DeleteLanguage(name);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static IResult UpdateLanguage(ILanguageRepository languageRepository, string name, LanguageUpdatePayload languageUpdatePayload)
        {
            try
            {
                Language? language = languageRepository.GetLanguage(name);
                if (language == null)
                {
                    return Results.NotFound();
                }

                languageRepository.UpdateLanguage(name, languageUpdatePayload);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        
    }
}