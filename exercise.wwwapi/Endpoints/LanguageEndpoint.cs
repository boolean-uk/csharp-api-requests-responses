using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        
            public static void ConfigureLanguageEndpoint(this WebApplication app)
            {
                var languageGroup = app.MapGroup("languages");

            languageGroup.MapGet("/", GetLanguages);
            languageGroup.MapGet("/{name}", GetALanguage);
            languageGroup.MapPost("/", Create);
            languageGroup.MapPut("/{name}", Update);
            languageGroup.MapDelete("/{name}", Delete);

            }

            [ProducesResponseType(StatusCodes.Status200OK)]
         
             public static async Task<IResult> GetLanguages(ILanguageRepository repository)
            {
                return TypedResults.Ok(repository.GetList());
            }

         [ProducesResponseType(StatusCodes.Status200OK)]
          public static async Task<IResult> GetALanguage(ILanguageRepository repository,  string input )
         {
         return TypedResults.Ok(repository.Get(input));
         }

        
     [ProducesResponseType(StatusCodes.Status201Created)]

     public static async Task<IResult> Create(ILanguageRepository repository,  Language model)
     {   
         var newLanguage = new Language(model.Name);
         repository.Create(model);
         return TypedResults.Created($"/{newLanguage.Name}", newLanguage);
         }

        
          [ProducesResponseType(StatusCodes.Status201Created)]

          public static async Task<IResult> Update(ILanguageRepository repository, string input)
     {
           Language updated = repository.Update(input);
            return TypedResults.Ok(updated);
        }
        
          [ProducesResponseType(StatusCodes.Status200OK)]
          public static async Task<IResult> Delete(ILanguageRepository repository,  string input)
     {
            Language Deleted = repository.Delete(input);
            return TypedResults.Ok(Deleted);
          }

    }
}
