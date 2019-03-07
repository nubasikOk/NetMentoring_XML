﻿using System;
using System.Linq;
using System.Xml.Linq;
using XMLWorker.Abstract;
using XMLWorker.Entities;

namespace XMLWorker.Parsers
{
    public class BookParser : BaseXmlParser
    {
        public override string ElementName => "book";

        public override IEntity ParseElement(XElement element)
        {
            if (element.IsEmpty())
            {
                throw new ArgumentNullException($"{nameof(element)} is null");
            }
           
            Book book = new Book
            {
                Name = GetAttributeValue(element, "name"),
                City = GetAttributeValue(element, "city"),
                Publishing = GetAttributeValue(element, "publishing"),
                Year = int.Parse(GetAttributeValue(element, "year") ?? default(int).ToString()),
                PagesCount = int.Parse(GetAttributeValue(element, "pagesCount") ?? default(int).ToString()),
                ISBN = GetAttributeValue(element, "isbn"),
                Note = GetElement(element, "note").Value,
                Authors = GetElement(element, "authors").Elements("author").Select(elem => new Author
                {
                    FirstName = GetAttributeValue(elem, "firstName"),
                    LastName = GetAttributeValue(elem, "lastName")
                }).ToList()
            };
            return book;
        }
    }
}
