using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private StudentCollection _studentCollection;
        private LanguageCollection _languageCollection;
        private BookCollection _bookCollection;

        public Repository(StudentCollection studentCollection, LanguageCollection languageCollection, BookCollection bookCollection)
        {
            _studentCollection = studentCollection;
            _languageCollection = languageCollection;
            _bookCollection = bookCollection;
        }

        public List<Student> GetStudents()
        {
            return _studentCollection.getAll();
        }

        public Student AddStudent(Student student) 
        {
            return _studentCollection.Add(student);
        }
        
        public Student GetStudent(string name)
        {
            return _studentCollection.Get(name);
        }

        public Student UpdateStudent(string name, Student student)
        {
            return _studentCollection.Update(name, student);
        }

        public void DeleteStudent(string name)
        {
            _studentCollection.Delete(name);
        }



        public List<Language> GetLanguages()
        {
            return _languageCollection.getAll();
        }
        public Language AddLanguage(Language language)
        {
            return _languageCollection.Add(language);
        }

        public Language GetLanguage(string name)
        {
            return _languageCollection.Get(name);
        }

        public Language UpdateLanguage(string name, Language language)
        {
            return _languageCollection.Update(name, language);
        }

        public void DeleteLanguage(string name)
        {
            _languageCollection.Delete(name);
        }



        public List<Book> GetBooks()
        {
            return _bookCollection.getAll();
        }
        public Book AddBook(Book book)
        {
            return _bookCollection.Add(book);
        }

        public Book GetBook(int id)
        {
            return _bookCollection.Get(id);
        }

        public Book UpdateBook(int id, Book book)
        {
            return _bookCollection.Update(id, book);
        }

        public void DeleteBook(int id)
        {
            _bookCollection.Delete(id);
        }
    }
}
