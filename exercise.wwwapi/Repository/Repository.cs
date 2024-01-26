using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataCollection _studentDatabase;
        public Repository(DataCollection studentDatabase)
        {
            _studentDatabase = studentDatabase;
        }
      

        // add or create a student
        public Student AddStudent(Student student)
        {
            return _studentDatabase.AddStudent(student);
        }

        // get all students
        public IEnumerable<Student> GetStudents()
        {
            return _studentDatabase.GetStudents();
        }

        // update a student
        public Student UpdateStudent(int id, StudentPut studentPut)
        {
            var found = _studentDatabase.GetStudent(id, out Student student);
            if (!found)
            {
                return null;
            }
            student.FirstName = studentPut.FirstName;
            student.LastName = studentPut.LastName;
            return student;
        }

        // delete a student
        public bool DeleteStudent(int id)
        {
            return _studentDatabase.DeleteStudent(id);
        }

        //*****************************************************
        //Languate models
        //*****************************************************


        /*
        private DataCollection _languageDatabase;
        public Repository(DataCollection languageDatabase)
        {
            _languageDatabase = languageDatabase;
        }
        */


        // add or create a language
        public Language AddLanguage(Language language)
        {
            return _studentDatabase.AddLanguage(language);
        }

        // get languages
        public IEnumerable<Language> GetLanguages()
        {
            return _studentDatabase.GetLanguages();    
        }

        public Language UpdateLanguage(int id, LanguagePut languagePut)
        {
            var found = _studentDatabase.GetLanguage(id, out Language language);
            if (!found)
            {
                return null;
            }
            language.Name= languagePut.Name;
            return language;
        }

        public bool DeleteLanguage(int id) => _studentDatabase.DeleteLanguage(id);




        //***********************************
        public IEnumerable<Book> GetBooks()
        {
            return _studentDatabase.GetBooks();
        }

        public Book AddBook(Book book)
        {
            return _studentDatabase.AddBook(book);
        }

        public Book UpdateBook(int id, BookPut bookPut)
         {
            var found = _studentDatabase.GetBook(id, out Book book);
            if (!found)
            {
                return null;
            }
            book.Title= bookPut.Title;
            book.Author= bookPut.Author;
            book.nunmPages = bookPut.numPages;
            book.Gnre = bookPut.Gnre;
            return book;
        }

    public bool DeleteBook(int id) => _studentDatabase.DeleteBook(id);

        //************************************************************************

    }


}

