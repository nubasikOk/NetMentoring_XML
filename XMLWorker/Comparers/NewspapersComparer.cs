
using System.Collections;
using System.Collections.Generic;
using XMLWorker.Entities;

namespace XMLWorker.Comparers
{
    class NewspapersComparer : IComparer, IComparer<Newspaper>
    {
        public int Compare(Newspaper x, Newspaper y)
        {
            return x.PagesCount == y.PagesCount
                   && x.Name == y.Name
                   && x.Number == y.Number
                   && x.ISSN== y.ISSN
                   && x.Note == y.Note
                   && x.Year == y.Year
                   && x.City == y.City
                   && x.Publishing == y.Publishing ? 0 : 1;
        }

        public int Compare(object x, object y)
        {
            return Compare(x as Newspaper, y as Newspaper);
        }
    }
}
