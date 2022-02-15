using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCurator.Model
{
    class BookManager
    {

        public static void GetAllBooks(ObservableCollection<Book> books)
        {
            var allBooks = GetBooks();
            books.Clear();

            allBooks.ForEach(book => books.Add(book));
        }

        public static void GetBooksByCategory(ObservableCollection<Book> books, BookCategory category)
        {
            var allBooks = GetBooks();
            var filteredBooks = allBooks.Where(book => book.Category == category).ToList();
            books.Clear();

            filteredBooks.ForEach(book => books.Add(book));
        }
        private static List<Book> GetBooks()
        {
            var books = new List<Book>();
            books.Add(new Book("PrideAndPrejudice", "Pride And Prejudice", "Jane Austen", "placeholder", BookCategory.Romance));
            books.Add(new Book("Beloved", "Beloved", "Toni Morrison", "placeholder", BookCategory.Classics));
            books.Add(new Book("TheMoonIsAHarshMistress", "The Moon Is A Harsh Mistress", "Robert Heinlein", "placeholder", BookCategory.ScienceFiction));

            return books;
        }
    }
}
