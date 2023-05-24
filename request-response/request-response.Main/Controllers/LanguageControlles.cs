using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using request_response.Models;

namespace request_response.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LanguageController : ControllerBase
    {
        public static List<Language> Languages = new List<Language>();
        public LanguageController()
        {
        }
    }
}