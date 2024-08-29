using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class BookCollection
    {
        private static List<Book> _books = new List<Book>()
        {
            new Book(1, "A Game of Thrones", 780, "George R.R. Martin", "Fantasy"),
            new Book(2, "The lord of the rings", 1137, "J.R.R Tolkion", "Fantasy")
        };

        public static Book Add(Book entity)
        {
            var entityExists = _books.FirstOrDefault(x => x.Title.Equals(entity.Title));
            if (entityExists is not null)
            {
                return null;
            }
            entity.Id = _books.Max(x => x.Id) + 1;
            _books.Add(entity);
            return entity;
        }

        public static List<Book> GetAll()
        {
            return _books.ToList();
        }

        public static Book Get(int id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }

        public static Book Update(int id, Book entity)
        {
            var index = _books.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return null;
            }

            _books[index] = entity;
            return entity;
        }

        public static Book Delete(int id)
        {
            var foundEntity = _books.FirstOrDefault(x => x.Id == id);
            if (foundEntity is null)
            {
                return null;
            }

            _books.Remove(foundEntity);
            return foundEntity;
        }
    }
}
