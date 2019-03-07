using System;
using System.Xml.Linq;
using XMLWorker.Abstract;
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

            Newspaper newspaper = new Newspaper
            {
                Name = GetAttributeValue(element, "name"),
                City = GetAttributeValue(element, "city"),
                Publishing = GetAttributeValue(element, "publishing"),
                Year = int.Parse(GetAttributeValue(element, "year") ?? default(int).ToString()),
                PagesCount = int.Parse(GetAttributeValue(element, "pagescount") ?? default(int).ToString()),
                Note = GetAttributeValue(element, "note"),
                Number = int.Parse(GetAttributeValue(element, "number") ?? default(int).ToString()),
                Date = GetDate(GetAttributeValue(element, "date")),
                ISSN = GetAttributeValue(element, "issn")
            };

            return newspaper;
        }
    }
}
