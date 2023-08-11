using Homework2.Models;

namespace Homework2
{
    public static class StaticDb
    {
        public static List<Book> Books { get; } = new List<Book>
        {
            new Book
            {
                Author = "Author1",
                Title = "Book Title 1"
            },
            new Book
            {
                Author = "Author2",
                Title = "Book Title 2"
            },
            new Book
            {
                Author = "Author3",
                Title = "Book Title 3"
            }
        };
    }
}