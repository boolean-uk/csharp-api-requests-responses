using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class BookRepository : IBookRepository
    {
        public List<Book> GetAllBooks() 
        {
            return BooksCollection.Books;
        }

        public Book GetABook(string Title)
        {
            return BooksCollection.Books.FirstOrDefault(x => x.Title == Title);
        }

        public Book PostABook(string title, int numPages, string author, string genre)
        {
           return BooksCollection.AddBook(new Book(title,numPages,author,genre));
        }

        public Book UppdateBook(string title, string newtitle, int? newnumPages, string newauthor, string newgenre)
        {
            Book B = BooksCollection.Books.FirstOrDefault(x => x.Title.Equals(title));
            if (newtitle is not null)
            {
                B.Title = newtitle;
            }
            if (newnumPages is not null)
            {
                B.NumPages = (int)newnumPages;
            }
            if (newauthor is not null)
            {
                B.Author = newauthor;
            }
            if (newgenre is not null)
            {
                B.Genre = newgenre;
            }

            return B;

        }

        public Book DeleteBook(string title)
        {
            Book B = BooksCollection.Books.FirstOrDefault(x => x.Title.Equals(title));
            return BooksCollection.RemoveBook(B);
        }
    }
}
