using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoints
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var languageGroup = app.MapGroup("");

            languageGroup.MapPost("/create a language", AddLanguage);
            languageGroup.MapGet("/get all language", GetLanguages);
            languageGroup.MapGet("/get a language{id}", AddLanguage);
            languageGroup.MapPut("/update a language {name}", UpdateLanguage);
            languageGroup.MapDelete("/delete language{id}", DeleteLanguage);
        }




        // add or create a product
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddLanguage([FromServices] IRepository repository, [FromBody] LanguagePost language)
        {
            //validate
            if (language == null)
            {

            }
            var newLanguage = new Language() { Name = language.Name };
            repository.AddLanguage(newLanguage);
            return TypedResults.Created($"/{newLanguage.Name}", newLanguage);
        }



        // get all languages
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguages([FromServices] IRepository repository)
        {
            return TypedResults.Ok(repository.GetLanguages());
        }

        // update a language
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateLanguage([FromServices] IRepository repository, int id, [FromBody] LanguagePut name)
        {
            return TypedResults.Ok(repository.UpdateLanguage(id, name));
        }


        // delete a language
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteLanguage(int id, IRepository repository)
        {
            var languageDeleted = repository.DeleteLanguage(id);
            return TypedResults.Ok(languageDeleted);

        }
    }
}
