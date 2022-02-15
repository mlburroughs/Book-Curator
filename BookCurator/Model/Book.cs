using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCurator.Model
{

    public enum BookCategory
    {
        Biographies,
        Classics,
        Fantasy,
        History,
        Mystery,
        Romance,
        ScienceFiction
    }


    public class Book
    {
        public string Label { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public BookCategory Category { get; set; }

        public Book(string label, string title, string author, string description, BookCategory category)
        {
            Label = label;
            Title = title;
            Author = author;
            Description = description;
            ImageFile = $"/Assets/Images/{category}/{label}.png";
            Category = category;
        }
    }
}
