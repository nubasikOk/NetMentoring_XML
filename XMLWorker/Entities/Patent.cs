using System;
using System.Collections.Generic;
using XMLWorker.Interfaces;

namespace XMLWorker.Entities
{
    public class Patent: IEntity
    {
        
        public string Name { get; set; }
        public List<Author> Creators { get; set; }
        public int RegistrationNumber { get; set; }
        public DateTime FilingDate { get; set; }
        public DateTime PublishDate { get; set; }
        public string Country { get; set; }
        public int PagesCount { get; set; }
        public string Note { get; set; }
        
    }
}
