using System;
using System.Xml.Linq;
using XMLWorker.Interfaces;
using XMLWorker.Entities;


namespace XMLWorker.Parsers
{
    public class NewspapersParser : BaseXmlParser
    {
        public override string ElementName => "newspaper";

        public override IEntity ParseElement(XElement element)
        {
            if (element.IsEmpty())
            {
                throw new ArgumentNullException($"{nameof(element)} is null");
            }

            var newspaper = new Newspaper
            {
                Name = GetAttributeValue(element, "name"),
                City = GetAttributeValue(element, "city"),
                Publishing = GetAttributeValue(element, "publishing"),
                Year = GetAttributeValue(element, "year").Convert<int>(),
                PagesCount = GetAttributeValue(element, "pagesCount").Convert<int>(),
                Note = GetElement(element, "note").Value,
                Number = GetAttributeValue(element, "number").Convert<int>(),
                Date = GetDate(GetAttributeValue(element, "date")),
                ISSN = GetAttributeValue(element, "issn")
            };

            return newspaper;
        }
    }
}
