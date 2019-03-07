using System.Collections;
using System.Collections.Generic;
using XMLWorker.Entities;
namespace XMLWorker.Comparers
{
    public class PatentsComparer : IComparer, IComparer<Patent>
    {
        public int Compare(Patent x, Patent y)
        {
            return x.Name == y.Name
                   && x.Country== y.Country
                   && x.FilingDate == y.FilingDate
                   && x.PublishDate == y.PublishDate
                   && x.Note == y.Note
                   && x.RegistrationNumber == y.RegistrationNumber
                   && x.PagesCount == y.PagesCount ? 0 : 1;
        }

        public int Compare(object x, object y)
        {
            return Compare(x as Patent, y as Patent);
        }
    }
}
