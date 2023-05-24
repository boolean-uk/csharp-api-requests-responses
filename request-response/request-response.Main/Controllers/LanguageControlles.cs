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
        public List<Language> languages = new List<Language>();
        public LanguageController()
        {
        }

        [HttpPost]
        [Route("/languages")]
        public async Task<IResult> AddLanguage([Required] string name)
        {
            try
            {
                Language language = new Language() { Name = name };
                languages.Add(language);
                return Results.Created("Valid", language);
            }
            catch (Exception ex) 
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IResult> GetAllLanguages()
        {
            try
            {
                if (languages.Count > 0)
                {
                    return Results.Ok(languages);
                }
                return Results.NoContent();
            }
            catch (Exception ex) 
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("/languages/{name}")]
        public async Task<IResult> GetLanguageByName([Required] string name)
        {
            try
            {
                foreach (Language i in languages)
                {
                    if (i.Name == name)
                    {
                        return Results.Ok(i);
                    }
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
        public async Task<IResult> UpdateLanguageName([Required] string name, [Required] string newName)
        {
            try
            {
                foreach (Language i in languages)
                {
                    if (i.Name == name)
                    {
                        i.Name = newName;
                        return Results.Ok(i);
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
        public async Task<IResult> DeleteLanguage([Required] string name)
        {
            try
            {
                foreach (Language i in languages)
                {
                    if (i.Name == name)
                    {
                        languages.Remove(i);
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