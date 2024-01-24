using exercise.wwwapi.Models;
using System.Collections.Immutable;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private List<Books> books = new List<Books>(){
            new Books("Nathan", 20, "King", "thriller",1 ),
            new Books("title1", 10, "author1", "genre1",2)        };

        private int _nextid = 2;

        public Books Create(string title, int numPages, string author, string genre)
        {
            _nextid++;
            Books newBook = new Books(title, numPages, author, genre, _nextid );
            books.Add(newBook);
            return newBook;
        }
        

        public List<Books> getAll()
        {
            return books.ToList();
        }

        
        public Books Remove(int id)
        {
            var book = books.Find(books => books.id == id);
            books.Remove(book);
            return book;
        }
        

    }
}
