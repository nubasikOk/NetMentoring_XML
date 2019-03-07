using System.Collections.Generic;
using XMLWorker.Abstract;

namespace XMLWorker.Entities 
{
    public class Book:IEntity
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public List<Author> Authors { get; set; }
        public string City { get; set; }
        public string Publishing { get; set; }
        public int Year { get; set; }
        public int PagesCount { get; set; }
        public string Note { get; set; }
    }
}
