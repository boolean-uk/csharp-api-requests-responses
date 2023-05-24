using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using request_response.Models;

namespace request_response.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LanguageController : ControllerBase
    {
        public static List<Language> _languages = new List<Language>();
        public LanguageController()
        {
            if (_languages.Count == 0)
            {
                Language language1 = new Language();
                language1.Name = "English";

                Language language2 = new Language();
                language2.Name = "Dutch";

                _languages.Add(language1);
                _languages.Add(language2);
            }
        }


        [HttpPost]
        public IActionResult Create(Language language)
        {
            try
            {
                if (language == null)
                {
                    return BadRequest("Language info is not provided");
                }
                _languages.Add(language);
                return Ok(language);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_languages);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{name}")]

        public IActionResult Get(string name)
        {
            try
            {
                var language = _languages.Where(x => x.Name == name).FirstOrDefault();
                return language != null ? Ok(language) : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{name}")]

        public IActionResult Put(Language language)
        {
            try
            {
                if (_languages.Any(x => x.Name == language.Name))
                {
                    var l = _languages.SingleOrDefault(x => x.Name == language.Name);
                    if (l != null)
                    {
                        l.Name = language.Name;
                        return Ok(l);
                    }
                    return BadRequest();
                }
                else return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{name}")]

        public IActionResult Delete(string name)
        {
            try
            {
                if (_languages.Any(x => x.Name == name))
                {
                    _languages.RemoveAll(x => x.Name == name);
                    return Ok();
                }
                else return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}