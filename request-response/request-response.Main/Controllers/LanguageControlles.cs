using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using request_response.Models;

namespace request_response.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LanguageController : ControllerBase
    {
        private static List<Language> _languages = new List<Language>();
        public LanguageController()
        {
        }

        [HttpPost]
        [Route("")]
        public async Task<IResult> PostLanguage(Language language)
        {
            try
            {
                if (language == null) return Results.Problem();
                _languages.Add(language);
                return Results.Ok(language);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("")]
        public async Task<IResult> GetLanguage()
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
        [Route("{programminglanguage}")]
        public async Task<IResult> GetLanguage(string programminglanguage)
        {
            try
            {
                var language = _languages.Where(x => x.ProgrammingLanguage == programminglanguage).FirstOrDefault();
                return Results.Ok(language);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("{programminglanguage}")]
        public async Task<IResult> ChangeLanguage(string programminglanguage, string? newprogramminglanguage)
        {
            try
            {
                if (_languages.Any(x => x.ProgrammingLanguage == programminglanguage))
                {
                    var changeProgrammingLanguage = _languages.SingleOrDefault(x => x.ProgrammingLanguage == programminglanguage);
                    if (changeProgrammingLanguage != null)
                    {
                        if (!string.IsNullOrEmpty(newprogramminglanguage))
                        {
                            changeProgrammingLanguage.ProgrammingLanguage = newprogramminglanguage;
                        }
                        return Results.Ok(changeProgrammingLanguage);
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
        [Route("{programminglanguage}")]
        public async Task<IResult> DeleteLanguage(string programminglanguage)
        {
            try
            {
                if (_languages.Any(x => x.ProgrammingLanguage == programminglanguage))
                {
                    var deleteProgrammingLanguage = _languages.SingleOrDefault(x => x.ProgrammingLanguage == programminglanguage);
                    _languages.Remove(deleteProgrammingLanguage);
                    return Results.Ok(deleteProgrammingLanguage);
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
    }
}