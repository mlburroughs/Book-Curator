using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using BookCurator.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BookCurator
{
    
    public sealed partial class MainPage : Page
    {
        private readonly ObservableCollection<Book> Books;// Collection of all books
        private readonly ObservableCollection<Book> BooksToAdd;// Collection of all books availble for selection
        private ObservableCollection<Book> BookSelections;// Collection of books selected by user

        private readonly List<GenreItem> GenreItems;
        private readonly List<AuthorItem> AuthorItems;


        public MainPage()
        {
            this.InitializeComponent();

            // Create collection of all books
            Books = new ObservableCollection<Book>();
            BookManager.GetAllBooks(Books);

            // Create collection of user-selected books
            BookSelections = new ObservableCollection<Book>();

            // Create collection of books available for selection
            BooksToAdd = new ObservableCollection<Book>();
            BookManager.GetAllBooks(BooksToAdd);

            // Creates Author Menu
            AuthorItems = new List<AuthorItem>();
            AuthorItems.Add(new AuthorItem
            {
                Icon="/Assets/Images/Icons/Bookmark.png",
                AuthorName = "Jane Austen"
            });
            AuthorItems.Add(new AuthorItem
            {
                Icon = "/Assets/Images/Icons/Bookmark.png",
                AuthorName = "Robert Heinlein"
            });
            AuthorItems.Add(new AuthorItem
            {
                Icon = "/Assets/Images/Icons/Bookmark.png",
                AuthorName = "Toni Morrison",
            });


            GenreItems = new List<GenreItem>();
            GenreItems.Add(new GenreItem
            {
                Icon = "/Assets/Images/Genres/Children.png",
                Genre = Genres.Children
            });
            GenreItems.Add(new GenreItem
            {
                Icon = "/Assets/Images/Genres/Classic.png",
                Genre = Genres.Classic
            });
            GenreItems.Add(new GenreItem
            {
                Icon = "/Assets/Images/Genres/Fantasy.png",
                Genre = Genres.Fantasy
            });
            GenreItems.Add(new GenreItem
            {
                Icon = "/Assets/Images/Genres/History.png",
                Genre = Genres.History
            });
            GenreItems.Add(new GenreItem
            {
                Icon = "/Assets/Images/Genres/Romance.png",
                Genre = Genres.Romance
            });
            GenreItems.Add(new GenreItem
            {
                Icon = "/Assets/Images/Genres/ScienceFiction.png",
                Genre = Genres.ScienceFiction
            });
            GenreItems.Add(new GenreItem
            {
                Icon = "/Assets/Images/Genres/Technical.png",
                Genre = Genres.Technical
            });
            GenreItems.Add(new GenreItem
            {
                Icon = "/Assets/Images/Genres/Thriller.png",
                Genre = Genres.Thriller
            });

        }



        // Adds Book to BookSelections collection and removes Book from BooksToAdd
        private void BooksInCategory_ItemClick(object sender, ItemClickEventArgs e)
        {
            Book selectedBook = (Book)e.ClickedItem;
            selectedBook.UnselectedBook = false;

            // Need to handle this!
            string newText;
            newText = "All Books";
            BookCategoryTitle.Text = newText;

            BookManager.GetSelectedBooks(BookSelections, Books);
            BookManager.GetUnselectedBooks(BooksToAdd, Books);

        }

        // Removes Book from BookSelections collection and adds Book to BooksToAdd
        private void SelectedBooks_ItemClick(object sender, ItemClickEventArgs e)
        {
            Book unselectedBook = (Book)e.ClickedItem;
            unselectedBook.UnselectedBook = true;


            // Need to handle this!
            string newText;
            newText = "All Books";
            BookCategoryTitle.Text = newText;

            BookManager.UpdateStatus(Books, unselectedBook);
            BookManager.GetSelectedBooks(BookSelections, Books);
            BookManager.GetUnselectedBooks(BooksToAdd, Books);
           
            
        }

        // 
        private void Logo_Click(object sender, RoutedEventArgs e)
        {
            string newText;
            newText = "All Books";
            BookCategoryTitle.Text = newText;


            AuthorList.Visibility = Visibility.Collapsed;
            GenreList.Visibility = Visibility.Collapsed;
            BooksInCategory.Visibility = Visibility.Visible;


        }

        //
        private void ByGenre_Click(object sender, RoutedEventArgs e)
        {
            string newText;
            newText = "All Genres";
            BookCategoryTitle.Text = newText;


            AuthorList.Visibility = Visibility.Collapsed;
            GenreList.Visibility = Visibility.Visible;
            BooksInCategory.Visibility = Visibility.Collapsed;
        }

        private void ByAuthor_Click(object sender, RoutedEventArgs e)
        {
            string newText;
            newText = "All Authors";
            BookCategoryTitle.Text = newText;


            AuthorList.Visibility = Visibility.Visible;
            GenreList.Visibility = Visibility.Collapsed;
            BooksInCategory.Visibility = Visibility.Collapsed;
        }

        private void AllBooks_Click(object sender, RoutedEventArgs e)
        {
            string newText;
            newText = "All Books";
            BookCategoryTitle.Text = newText;

            AuthorList.Visibility = Visibility.Collapsed;
            GenreList.Visibility = Visibility.Collapsed;
            BooksInCategory.Visibility = Visibility.Visible;

        }

        private void GenreList_ItemClick(object sender, ItemClickEventArgs e)
        {
            GenreItem selectedGenre = (GenreItem)e.ClickedItem;
            BookManager.GetBooksByCategory(BooksToAdd, Books, selectedGenre.Genre);

            BookCategoryTitle.Text = selectedGenre.Genre.ToString();

            GenreList.Visibility = Visibility.Collapsed;
            BooksInCategory.Visibility = Visibility.Visible;

            
        }

        private void AuthorList_ItemClick(object sender, ItemClickEventArgs e)
        {
            AuthorItem selectedAuthor = (AuthorItem)e.ClickedItem;
            BookManager.GetBooksByAuthor(BooksToAdd, Books, selectedAuthor.AuthorName);

            BookCategoryTitle.Text = selectedAuthor.AuthorName.ToString();

            AuthorList.Visibility = Visibility.Collapsed;
            BooksInCategory.Visibility = Visibility.Visible;
        }
    }
}
