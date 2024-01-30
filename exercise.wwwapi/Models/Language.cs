using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.Models
{
    public class Language
    {
        [Key] public int id { get; set; }
        public string name { get; set; }   
    }
}
