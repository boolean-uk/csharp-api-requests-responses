using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        public Student AddStudent(Student student);

        public IEnumerable<Student> GetStudents();

        public Student GetAStudent(string firstname);

        public Student UpdateStudent(string firstname, Student student);
        
        public Student DeleteAStudent(string firstname);

        public Language AddLanguage(Language language);

        public IEnumerable<Language> GetLanguage();

        public Language GetALanguage(string name);

        public Language UpdateALanguage(string name, Language language);

        public Language DeleteALanguage(string name);
    }
}
