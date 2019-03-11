using System;
using System.Linq;
using System.Xml.Linq;
using XMLWorker.Entities;
using XMLWorker.Interfaces;

namespace XMLWorker.Parsers
{
    public class PatentParser : BaseXmlParser
    {
        public override string ElementName => "patent";

        public override IEntity ParseElement(XElement element)
        {
            if(element.IsEmpty())
            {
                throw new ArgumentNullException($"{nameof(element)} is null");
            }

            var patent = new Patent
            {
                Name = GetAttributeValue(element, "name"),
                Creators = GetElement(element, "creators").Elements("creator").Select(elem => new Author
                {
                    FirstName = GetAttributeValue(elem, "firstName"),
                    LastName = GetAttributeValue(elem, "lastName")
                }).ToList(),
                RegistrationNumber = GetAttributeValue(element, "number").Convert<int>(),
                FilingDate = GetAttributeValue(element,"filingDate").Convert<DateTime>(),
                PublishDate = GetAttributeValue(element, "publishDate").Convert<DateTime>(),
                Country = GetAttributeValue(element, "country"),
                PagesCount = GetAttributeValue(element, "pagesCount").Convert<int>(),
                Note = GetElement(element, "note").Value
            };

            return patent;
        }
    }
}
