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

        private readonly List<MenuItem> MenuItems;// List of Category Menu Items
        
        private MenuItem Selection;// Selected MenuItem from ComboBox


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

            // Create Menu Items of book genres for ComboBox
            MenuItems = new List<MenuItem>();
            MenuItems.Add(new MenuItem
            {
                CategoryTitle = "All Books",
                Category = BookCategory.AllBooks
            });
            MenuItems.Add(new MenuItem
            {
                CategoryTitle = "Biographies",
                Category = BookCategory.Biographies
            });
            MenuItems.Add(new MenuItem
            {
                CategoryTitle = "Classics",
                Category = BookCategory.Classics
            });
            MenuItems.Add(new MenuItem
            {
                CategoryTitle = "Fantasy",
                Category = BookCategory.Fantasy
            });
            MenuItems.Add(new MenuItem
            {
                CategoryTitle = "History",
                Category = BookCategory.History
            });
            MenuItems.Add(new MenuItem
            {
                CategoryTitle = "Mystery",
                Category = BookCategory.Mystery
            });
            MenuItems.Add(new MenuItem
            {
                CategoryTitle = "Romance",
                Category = BookCategory.Romance
            });
            MenuItems.Add(new MenuItem
            {
                CategoryTitle = "Science Fiction",
                Category = BookCategory.ScienceFiction
            });

        }

        // Updates BooksToAdd collection based on user-selected MenuItem
        private void SelectCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Selection = (MenuItem)SelectCategory.SelectedItem;
            BookCategoryTitle.Text = Selection.CategoryTitle;
            BookManager.GetBooksByCategory(BooksToAdd, Books, Selection.Category);
        }

        // Adds Book to BookSelections collection and removes Book from BooksToAdd
        private void BooksInCategory_ItemClick(object sender, ItemClickEventArgs e)
        {
            Book selectedBook = (Book)e.ClickedItem;
            selectedBook.UnselectedBook = false;
            BookManager.UpdateStatus(Books, selectedBook);
            BookManager.GetSelectedBooks(BookSelections, Books);
            BookManager.GetUnselectedBooks(BooksToAdd, Books);
            if (SelectCategory.SelectedIndex > -1)
            {
                BookManager.GetBooksByCategory(BooksToAdd, Books, Selection.Category); 
             }
            
        }

        // Removes Book from BookSelections collection and adds Book to BooksToAdd
        private void SelectedBooks_ItemClick(object sender, ItemClickEventArgs e)
        {
            Book unselectedBook = (Book)e.ClickedItem;
            unselectedBook.UnselectedBook = true;
            BookManager.UpdateStatus(Books, unselectedBook);
            BookManager.GetSelectedBooks(BookSelections, Books);
            BookManager.GetUnselectedBooks(BooksToAdd, Books);
            if (SelectCategory.SelectedIndex > -1) 
            {
                BookManager.GetBooksByCategory(BooksToAdd, Books, Selection.Category);
            }
        }

        // 
        private void Logo_Click(object sender, RoutedEventArgs e)
        {

        }

        //
        private void Reset_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
