using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCurator.Model
{

    public enum Genres
    {
        Children,
        Classic,
        Fantasy,
        History,
        Romance,
        ScienceFiction,
        Technical,
        Thriller
    }


    public class Book
    {
        public string Label { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public Genres Genre { get; set; }
        public string ImageFile { get; set; }
        public bool UnselectedBook { get; set; }

        public Book(string label, string title, string author, string description, Genres genre)
        {
            Label = label;
            Title = title;
            Author = author;
            Description = description;
            Genre = genre;

            ImageFile = $"/Assets/Images/Authors/{Genre}/{Label}.png";
            UnselectedBook = true;
        }
    }
}
