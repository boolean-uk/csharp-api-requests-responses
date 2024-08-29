﻿namespace exercise.wwwapi.Models
{
    public class Book
    {
        public string title { get; set; }
        public int numPages { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public int id { get; set; }

        public Book(string title, int numPages, string author, string genre)
        {
            this.title = title;
            this.numPages = numPages;
            this.author = author;
            this.genre = genre;
        }

         public Book(string title, int numPages, string author, string genre, int id)
        {
            this.title = title;
            this.numPages = numPages;
            this.author = author;
            this.genre = genre;
            this.id = id;
        }
}
}
