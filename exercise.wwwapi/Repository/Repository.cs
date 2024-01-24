using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataCollection _dataCollection = new DataCollection();

        public Repository(DataCollection dataCollection) {
            _dataCollection = dataCollection;
        }


        public IEnumerable<Student> getStudentCollections()
        {
            return _dataCollection.getAllStudents();
        }

        public Language createLanguage(string name)
        {
            return _dataCollection.CreateLanguage(name);
        }

        public IEnumerable<Language> getLanguageCollections()
        {
            return _dataCollection.getLanguages();
        }

        public Language getLanguage(string name)
        {
            Language lang = _dataCollection.getLanguages().Find(x => x.name == name);
            if(lang != null)
            {
                return lang;
            }
            return null;
        }

        public Language updateLanguage(string name, string newName)
        {
            Language lang = _dataCollection.getLanguages().Find(x => x.name == name);
            if (lang != null)
            {
                lang.name = newName;
                return lang;
            }
            return null;
        }

        public Language deleteLanguage(string name)
        {
            return _dataCollection.DeleteLanguage(name);
        }

        public Book createBook(Book book)
        {
            return _dataCollection.CreateBook(book);
        }

        public IEnumerable<Book> getAllBooks()
        {
            return _dataCollection.getAllBooks();
        }

        public Book getBook(int id)
        {
            return _dataCollection._books.Find(x => x.GetId() == id);
        }

        public Book updateBook(int id, Book book)
        {
            Book oldBook = getBook(id);

            if (book.Name != null) oldBook.Name = book.Name;
            if (book.Author != null) oldBook.Author = book.Author;
            if (book.NumPages != null) oldBook.NumPages = book.NumPages;
            if (book.Genre != null) oldBook.Genre = book.Genre;

            return oldBook;
            
        }

        public Book deleteBook(int id)
        {
            Book toDelete = getBook(id);
            if (toDelete == null)
                return null;

            _dataCollection._books.Remove(toDelete);
            return toDelete;
        }

        public IEnumerable<Student> getStudent(string firstName)
        {
            return _dataCollection.getAllStudents().Where(x=> x.FirstName == firstName);
        }

        public Student addStudent(string firstName, string lastName)
        {
            return _dataCollection.AddStudent(new Student(firstName, lastName));
        }

        public Student updateStudent(string firstName, string newFirstName, string newLastName)
        {
            Student temp = _dataCollection.getAllStudents().FirstOrDefault(x=>x.FirstName == firstName);
            temp.FirstName = newFirstName; temp.LastName = newLastName;
            return temp;
        }

        public Student deleteStudent(string firstName)
        {
            return _dataCollection.DeleteStudent(firstName);
        }
    }
}
