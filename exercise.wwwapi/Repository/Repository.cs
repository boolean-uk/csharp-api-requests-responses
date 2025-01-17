using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        // STUDENT PART
        public Student AddStudent(Student student)
        {
            return StudentCollection.Add(student);
        }

        public bool DeleteStudent(string firstName)
        {
            return StudentCollection.Remove(firstName);
            
        }

        public Student GetStudent(string firstName)
        {
            return StudentCollection.GetStudent(firstName);
        }

        public IEnumerable<Student> GetStudents()
        {
            return StudentCollection.getAll();
        }


        // LANGUAGE PART

        public Language AddLanguage(Language language)
        {
            return LanguageCollection.Add(language);
        }

        public bool DeleteLanguage(string name)
        {
            return LanguageCollection.RemoveLanguage(name);

        }

        public Language GetLanguage(string name)
        {
            return LanguageCollection.GetLanguage(name);
        }

        public IEnumerable<Language> GetLanguages()
        {
            return LanguageCollection.GetLanguages();
        }

        // BOOK PART
        public Book AddBook(Book book)
        {
            return BookCollection.AddBook(book);
        }

        public bool DeleteBook(int id)
        {
            return BookCollection.DeleteBook(id);
        }

        public Book GetBook(int id)
        {
            return BookCollection.GetBook(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return BookCollection.GetBooks();
        }
    }
}
