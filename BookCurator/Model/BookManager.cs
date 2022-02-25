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
        // Places all books in collection
        public static void GetAllBooks(ObservableCollection<Book> books)
        {
            var allBooks = GetBooks();
            books.Clear();

            allBooks.ForEach(book => books.Add(book));
        }

        // Places books in collection based on category
        public static void GetBooksByCategory(ObservableCollection<Book> books, ObservableCollection<Book> collection, BookCategory category)
        {
            var filteredBooks = collection.Where(book => book.Category == category && book.UnselectedBook).ToList();
            books.Clear();

            filteredBooks.ForEach(book => books.Add(book));
        }

        // Places books in collection based on author
        public static void GetBooksByAuthor(ObservableCollection<Book> books, ObservableCollection<Book> collection, String author)
        {
            var filteredBooks = collection.Where(book => book.Author == author && book.UnselectedBook).ToList();
            books.Clear();

            filteredBooks.ForEach(book => books.Add(book));
        }

        // Generates a list of <Book> items
        private static List<Book> GetBooks()
        {
            var books = new List<Book>();
            books.Add(new Book("Beloved", "Beloved", "Toni Morrison", "placeholder", BookCategory.Classics));
            books.Add(new Book("PrideAndPrejudice", "Pride And Prejudice", "Jane Austen", "placeholder", BookCategory.Romance));
            books.Add(new Book("TheMoonIsAHarshMistress", "The Moon Is A Harsh Mistress", "Robert Heinlein", "placeholder", BookCategory.ScienceFiction));
            return books;
        }

        // Retrieves selected books
        public static void GetSelectedBooks(ObservableCollection<Book> selectedBooks, ObservableCollection<Book> allBooks)
        {
            var filteredBooks = allBooks.Where(book => book.UnselectedBook == false).ToList();
            selectedBooks.Clear();

            filteredBooks.ForEach(book => selectedBooks.Add(book));
        }

        // Retrieves unselected books
        public static void GetUnselectedBooks(ObservableCollection<Book> unselectedBooksCollection, ObservableCollection<Book> allBooks)
        {
            var filteredBooks = allBooks.Where(book => book.UnselectedBook).ToList();
            unselectedBooksCollection.Clear();

            filteredBooks.ForEach(book => unselectedBooksCollection.Add(book));
        }

        // Updates Book.UnselectedBook attribute
        public static void UpdateStatus(ObservableCollection<Book> books, Book book)
        {
            foreach(Book item in books)
            {
                if(item.Label == book.Label)
                {
                    item.UnselectedBook = book.UnselectedBook;
                }
            }
        }

    }
}
