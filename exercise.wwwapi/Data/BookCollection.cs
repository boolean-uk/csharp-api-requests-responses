using exercise.wwwapi.Models;
using System.Runtime.CompilerServices;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private static List<Book> books = new List<Book>()
        {
            new Book("The Art of War", 229, "Some wise chinese guy", "History", 0),
            new Book("The bible", 532, "God", "Fantasy", 1)
        };

        public static Book Add(PayLoadBook payload)
        {
            int newID = -1;
            for(int i = 0; i < books.Count; i++)
            {
                bool represented = false;
                foreach (var b in books)
                {
                    if(b.id == i)
                    {
                        represented = true;
                    }
                }
                if(!represented)
                {
                    newID = i;
                    break;
                }
            }
            if(newID == -1)
            {
                newID = books.Count;
            }
            Book book = new Book(payload.title, payload.numPages, payload.author, payload.genre, newID);
            books.Add(book);

            return book;
        }

        public static Book DeleteBook(int id)
        {
            var book = books.FirstOrDefault(x => x.id == id);
            books.Remove(book);
            return book;
        }

        public static List<Book> GetAll()
        {
            return books.ToList();
        }

        public static Book GetBook(int id)
        {
            var book = books.FirstOrDefault(x => x.id == id);
            return book;
        }

        public static Book UpdateBook(PayLoadBook payload, int id)
        {
            var book = books.FirstOrDefault(x => x.id == id);
            book.title = payload.title;
            book.author = payload.author;
            book.genre = payload.genre;
            book.numPages = payload.numPages;
            return book;
        }
    }
}
