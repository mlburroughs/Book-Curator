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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly ObservableCollection<Book> Books;
        private readonly List<MenuItem> MenuItems;
        private ObservableCollection<Book> BookSelections;
        private readonly ObservableCollection<Book> BooksToAdd;
        private MenuItem Selection;

        private readonly string LogoPath;

        public MainPage()
        {
            this.InitializeComponent();

            LogoPath = $"/Assets/Images/Icons/MainLogoBook.png";

            Books = new ObservableCollection<Book>();
            BookManager.GetAllBooks(Books);

            BookSelections = new ObservableCollection<Book>();
            BooksToAdd = new ObservableCollection<Book>();
            BookManager.GetAllBooks(BooksToAdd);

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

        private void SelectCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Selection = (MenuItem)SelectCategory.SelectedItem;
            BookCategoryTitle.Text = Selection.CategoryTitle;
            BookManager.GetBooksByCategory(BooksToAdd, Books, Selection.Category);
        }

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

        private void Logo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
