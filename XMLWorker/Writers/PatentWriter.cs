using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using XMLWorker.Abstract;
using XMLWorker.Entities;

namespace XMLWorker.Writers
{
    public class PatentWriter : BaseXmlWriter
    {
        public override Type TypeToWrite => typeof(Patent);

        public override void WriteEntity(XmlWriter xmlWriter, IEntity entity)
        {
            Patent patent = entity as Patent;
            if (patent.IsEmpty())
            {
                throw new ArgumentException($"provided {nameof(entity)} is null or not of type {nameof(Patent)}");
            }

            XElement element = new XElement("patent");
            AddAttribute(element, "name", patent.Name);
            AddAttribute(element, "number", patent.RegistrationNumber.ToString());
            AddAttribute(element, "filingDate", patent.FilingDate.ToString());
            AddAttribute(element, "publishDate", patent.PublishDate.ToString());
            AddAttribute(element, "pagesCount", patent.PagesCount.ToString());
            AddAttribute(element, "country", patent.Country);
            AddElement(element, "note", patent.Note);
            AddElement(element, "creators",
                patent.Creators?.Select(a => new XElement("creator",
                    new XAttribute("firstName", a.FirstName),
                    new XAttribute("lastName", a.LastName)
                ))
            );

            element.WriteTo(xmlWriter);
        }
    }
}
