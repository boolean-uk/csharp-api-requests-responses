
namespace exercise.wwwapi.Models
{
    public class Book
    {
        private static int _nextId = 1;
        public int Id { get; private set; }
        public string Title { get; set; }
        public int NumPages { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        public Book(string title, int numPages, string author, string genre)
        {
            Id = _nextId++;
            Title = title;
            NumPages = numPages;
            Author = author;
            Genre = genre;
        }

        public Book(BookPayload payload)
        {
            Id = _nextId++;
            Title = payload.title;
            NumPages = payload.numPages;
            Author = payload.author;
            Genre = payload.genre;
        }


        public bool UpdateInfo(BookUpdatePayload payload)
        {

                bool isUpdated = false;

                if (payload.Title != null && Title != payload.Title)
                {
                    Title = payload.Title;
                    isUpdated = true;
                }

                if (payload.NumPages != null && NumPages != payload.NumPages.Value)
                {
                    NumPages = payload.NumPages.Value;
                    isUpdated = true;
                }

                if (payload.Author != null && Author != payload.Author)
                {
                    Author = payload.Author;
                    isUpdated = true;
                }

                if (payload.Genre != null && Genre != payload.Genre)
                {
                    Genre = payload.Genre;
                    isUpdated = true;
                }

                return isUpdated;
            }

        }
    }

