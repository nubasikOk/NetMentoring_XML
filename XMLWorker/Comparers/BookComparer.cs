using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return Compare(x as Book, y as Book);
        }
    }
}
