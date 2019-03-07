using System;
using XMLWorker.Abstract;

namespace XMLWorker.Entities
{
    public class Newspaper: IEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Publishing { get; set; }
        public int Year { get; set; }
        public int PagesCount { get; set; }
        public string Note { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string ISSN { get; set; }
    }
}
