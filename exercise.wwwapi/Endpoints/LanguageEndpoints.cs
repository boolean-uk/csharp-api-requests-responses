using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {

        // Create extended method:

        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {

            // Create route
            var languageGroup = app.MapGroup("languages");
            languageGroup.MapPost("/", CreateLanguage);   
            languageGroup.MapGet("/", GetLanguages);   
            languageGroup.MapGet("/{name}", GetALanguage);
            languageGroup.MapPut("/{name}", UpdateLanguage);
            languageGroup.MapDelete("/{name}", DeleteALanguage);
        }

     
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateLanguage(IRepository repository, LanguagePost inputLanguage)  
        {
            if (inputLanguage == null)
            {
                return Results.NoContent();
            }
            var newLanguage = new Language(inputLanguage.name);
            repository.AddLanguage(newLanguage);

            return TypedResults.Created($"/{newLanguage.name}", newLanguage);
        }

        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages(IRepository repository)   
        {
            var languageList = repository.GetLanguages();
            return languageList != null ? TypedResults.Ok(languageList) : Results.NotFound();
        }

        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetALanguage(IRepository repository, string name)   // GetCars uses inpendecy injections?
        {
            var fillteredLanguage = repository.GetLanguages().FirstOrDefault(lan => lan.name == name);

            return fillteredLanguage != null ? TypedResults.Ok(fillteredLanguage) : Results.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateLanguage(IRepository repository, string name, [FromBody] LanguagePost updatedLanguage)   // GetCars uses inpendecy injections?
        {
            var fillteredLanguage = repository.GetLanguages().FirstOrDefault(lan => lan.name == name);
            if (fillteredLanguage != null)
            {
                fillteredLanguage.name = updatedLanguage.name;
                
                return TypedResults.Created($"/{updatedLanguage.name}", updatedLanguage);   // This printout both first name and last name
            }

            return TypedResults.NotFound();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteALanguage(IRepository repository, string name)   
        {
            var fillteredLanguage = repository.GetLanguages().FirstOrDefault(lan => lan.name == name);
            if (fillteredLanguage != null)
            {
                return TypedResults.Ok(repository.RemoveLanguage(fillteredLanguage));
            }

            return TypedResults.NotFound();
        }

    }
}
