using System;
using System.Linq;
using System.Xml.Linq;
using XMLWorker.Entities;
using XMLWorker.Interfaces;

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
           
            var book = new Book
            {
                Name = GetAttributeValue(element, "name"),
                City = GetAttributeValue(element, "city"),
                Publishing = GetAttributeValue(element, "publishing"),
                Year = GetAttributeValue(element, "year").Convert<int>(),
                PagesCount = GetAttributeValue(element, "pagesCount").Convert<int>(),
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
