﻿using XMLWorker.Interfaces;

namespace XMLWorker.Entities
{
    public class Author:IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
