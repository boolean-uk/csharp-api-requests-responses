using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using request_response.Models;

namespace request_response.Controllers
{
    [ApiController]
    [Route("languages")]
    public class LanguageController : ControllerBase
    {
        public static List<Language> Languages { get; set; } = new List<Language>();
        public LanguageController()
        {
        }

        [HttpPost]
        public async Task<IResult> CreateLanguage(Language language)
        {
            try
            {
                if (language != null)
                {
                    Languages.Add(language);
                    return Results.Created("https://localhost:7241/Languages", language);
                }
                else
                {
                    return Results.Problem("There is nothign to be created");
                }
            } catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IResult> GetLanguages()
        {
            try
            {
                if (Languages.Count != 0)
                {
                    return Results.Ok(Languages);
                }
                else
                {
                    return Results.Problem("There are no languages yet");
                }
            } catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IResult> GetLanguage(string name)
        {
            try
            {
                var language = Languages.FirstOrDefault(x => x.Name == name);
                if (language != null)
                {
                    return Results.Ok(language);
                }
                else
                {
                    return Results.Problem($"There is no language named {name}");
                }
            } catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("{name}")]
        public async Task<IResult> UpadateLanguage(Language language, string name)
        {
            try
            {
                var lang = Languages.FirstOrDefault(x => x.Name == name);
                if (language != null)
                {
                    lang.Name = language.Name;
                    return Results.Ok(lang);
                }
                else
                {
                    return Results.Problem($"There is no language named {name}");
                }
            } catch (Exception ex)
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
                var language = Languages.FirstOrDefault(x => x.Name == name);
                if ( language != null )
                {
                    Languages.Remove(language);
                    return Results.Ok(language);
                }
                else
                {
                    return Results.Problem($"There is no language name {name}");
                }
            } catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

    }
}