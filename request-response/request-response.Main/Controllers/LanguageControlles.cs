using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using request_response.Models;
using System.Linq.Expressions;

namespace request_response.Controllers
{
    [ApiController]
    [Route("Languages")]
    public class LanguageController : ControllerBase
    {
        private static List<Language> _languages = new List<Language>();
        public LanguageController()
        {
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> AddLanguage(Language language)
        {
            try
            {
                if (language == null) return Results.Problem();
                _languages.Add(language);
                return Results.Created("https://localhost:7241/Language", language);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        [HttpGet]
        [Route("")]
        public async Task<IResult> SeeAllLanguages()
        {
            try
            {
                return Results.Ok(_languages);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IResult> SeeALanguage(string name)
        {
            // check is name in somewhere in _languages
            //return that name
            try
            {
                if (_languages.Any(x => x.Name == name))
                {
                    var i = _languages.SingleOrDefault(x => x.Name == name);

                    return Results.Ok(i);
                }
                else
                {
                    return Results.NotFound();
                }
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        [HttpPut]
        [Route("{name}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> ChangeAName(string name, string? newName)
        {
            try
            {
                if (_languages.Any(x => x.Name == name))
                {
                    var i = _languages.FirstOrDefault(x => x.Name == name);
                    if (i != null)
                    {
                        if (!string.IsNullOrEmpty(newName))
                        {
                            i.Name = newName;
                        }
                        return Results.Created($"https://localhost:7241/Language{i.Name}", i);
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
        [Route("{name}")]
        public async Task<IResult> DeleteLanguage(string name)
        {
            try
            {
                if (_languages.Any(x => x.Name == name))
                {
                    var i = _languages.FirstOrDefault(x => x.Name == name);
                    if (i !=null)
                    {
                        _languages.Remove(i);
                        return Results.Ok(i);
                    }
                    else
                    {
                        return Results.NotFound();
                    }
                }
                return Results.NotFound();
            }
                catch (Exception ex){
                return Results.Problem(ex.Message);
            }
        }
    }
}