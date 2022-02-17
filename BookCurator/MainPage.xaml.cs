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
        private readonly ObservableCollection<Book> BookSelections;
        


        public MainPage()
        {
            this.InitializeComponent();
            Books = new ObservableCollection<Book>();
            BookManager.GetAllBooks(Books);

            BookSelections = new ObservableCollection<Book>();

            MenuItems = new List<MenuItem>();
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

        private void SelectedBooks_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void BooksInCategory_ItemClick(object sender, ItemClickEventArgs e)
        {
            Book selectedBook = (Book)e.ClickedItem;
            BookSelections.Add(selectedBook);
            Books.Remove(selectedBook);
        }
        
        private void SelectCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            MenuItem selection = (MenuItem)SelectCategory.SelectedItem;
            BookCategoryTitle.Text = selection.CategoryTitle;
            BookManager.GetBooksByCategory(Books, selection.Category);

        }
    }
}
