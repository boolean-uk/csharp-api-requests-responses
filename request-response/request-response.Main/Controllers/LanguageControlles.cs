using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using request_response.Models;
using System.ComponentModel.DataAnnotations;

namespace request_response.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LanguageController : ControllerBase
    {
        private static List<Language> languages = new List<Language>();
        public LanguageController()
        {
        }
        [HttpPost]
        [Route("/languages")]
        public async Task<IResult> createLanguage([Required] string name)
        {
            try
            {
                Language language = new Language(name);
                languages.Add(language);
                return Results.Created("ok", language);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("/languages/{name}")]
        public async Task<IResult> getALanguage([Required] string name)
        {
            try
            {
                foreach (Language language in languages)
                {
                    if (language.name.Equals(name))
                    {
                        return Results.Ok(language);
                    }
                }
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("/languages")]
        public async Task<IResult> getAllLanguages()
        {
            try
            {
                if (languages.Count() != 0)
                {
                    return Results.Ok(languages);
                }

                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

        [HttpPut]
        [Route("/languages/{name}")]
        public async Task<IResult> updateALanguage([Required] string name)
        {
            try
            {
                foreach (Language language in languages)
                {
                    if (language.name.Equals(name))
                    {
                        language.name = "updated";
                        return Results.Ok(language);
                    }
                }
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/languages/{name}")]
        public async Task<IResult> DeleteALanguage([Required] string name)
        {
            try
            {
                foreach (Language language in languages)
                {
                    if (language.name.Equals(name))
                    {
                        languages.Remove(language);
                        return Results.Ok();
                    }
                }
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}