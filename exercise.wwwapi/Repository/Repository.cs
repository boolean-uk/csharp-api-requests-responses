using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    //public class Repository<T> : IRepository<T>
        public class Repository : IRepository
    {
        // private IData _dataBase;
        private StudentCollection _studentDB;
        private LanguageCollection _languageDB;
        private BookCollection _bookDB;

        /*   public Repository(T t)
           {
               if (t is Student) {
                   _dataBase = new StudentCollection();
               }
               else if (t is Language)
                   {
                       _dataBase = new LanguageCollection();
                   }

           }

           public T Add(T t)
           {
               return _dataBase.Add(t);
           }

           public IEnumerable<T> Get()
           {
               throw new NotImplementedException();
           }

           public T Remove(T t)
           {
               throw new NotImplementedException();
           }*/

        //-----------------------------------------------------------------------------

        // Inject the database:
        public Repository(LanguageCollection languageDB, StudentCollection studentDB, BookCollection bookDB)
        {
            _studentDB = studentDB;
            _languageDB = languageDB;
            _bookDB = bookDB;
        }

        public Student AddStudent(Student student)
        {
            return _studentDB.Add(student);

        }

        public IEnumerable<Student> GetStudents()
        {
            return _studentDB.getAll();
        }

        public Student Remove(Student student)
        {
            return _studentDB.Remove(student);
        }


        //-----------------------------------------------------------------------------

       /* public Repository(LanguageCollection languageDB)
        {
            _languageDB = languageDB;
        }
*/
        public IEnumerable<Language> GetLanguages()
        {
            return _languageDB.getAll();
        }

        public Language AddLanguage(Language language)
        {
            return _languageDB.Add(language);
        }

        public Language RemoveLanguage(Language language)
        {
            return _languageDB.Remove(language);
        }

        //-----------------------------------------------------------------------------

        public IEnumerable<Book> GetBooks()
        {
            return _bookDB.getAll();
        }

        public Book AddBook(Book book)
        {
            return _bookDB.Add(book);
        }

        public Book RemoveBook(Book book)
        {
            return _bookDB.Remove(book);
        }



    }
}
