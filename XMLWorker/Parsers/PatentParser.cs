using System;
using System.Linq;
using System.Xml.Linq;
using XMLWorker.Abstract;
using XMLWorker.Entities;

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

            Patent patent = new Patent
            {
                Name = GetAttributeValue(element, "name"),
                Creators = GetElement(element, "creators").Elements("creator").Select(elem => new Author
                {
                    FirstName = GetAttributeValue(elem, "firstName"),
                    LastName = GetAttributeValue(elem, "lastName")
                }).ToList(),
                RegistrationNumber = int.Parse(GetAttributeValue(element, "number") ?? default(int).ToString()),
                FilingDate = GetDate(GetAttributeValue(element,"filingDate")),
                PublishDate = GetDate(GetAttributeValue(element, "publishDate")),
                Country = GetAttributeValue(element, "country"),
                PagesCount = int.Parse(GetAttributeValue(element, "pagesCount") ?? default(int).ToString()),
                Note = GetAttributeValue(element, "note")
            };

            return patent;
        }
    }
}
