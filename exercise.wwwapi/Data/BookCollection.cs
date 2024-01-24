using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class BookCollection
    {
        private List<Book> books = new List<Book>();

        public Book Add(string title, int numPages, string author, string genre)
        {
            int id = 1;

            if (books.Count > 0)
                id = books.Last().ID++;

            books.Add(new Book() { ID = id, Title = title, NumPages = numPages, Author = author, Genre = genre });
            return books.Last();
        }

        public List<Book> GetAll()
        {
            return books.ToList();
        }

        public Book? Get(int id)
        {
            return books[id];
        }

        public void Delete(int id)
        {
            books.RemoveAt(id);
        }
    }
}
