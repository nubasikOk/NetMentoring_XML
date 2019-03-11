using System;
using System.Collections;
using System.Collections.Generic;
using XMLWorker.Entities;

namespace XMLWorker.Comparers
{
    public class BooksComparer : IComparer, IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
           
            return x.PagesCount == y.PagesCount
                   && x.Name == y.Name
                   && x.ISBN == y.ISBN
                   && x.Note == y.Note
                   && x.Year == y.Year
                   && x.City == y.City
                   && x.Publishing == y.Publishing? 0 : 1;
        }

        public int Compare(object x, object y)
        {
            
            if (typeof(Book) !=x.GetType() || (typeof(Book)) != y.GetType()) throw new Exception("types mismatch!");
            return Compare(x as Book, y as Book);
            
        }
    }
}
