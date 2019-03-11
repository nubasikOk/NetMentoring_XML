using System;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using XMLWorker.Abstract;
using XMLWorker.Entities;

namespace XMLWorker.Writers
{
    public class NewspapersWriter : BaseXmlWriter
    {
        public override Type TypeToWrite =>  typeof(Newspaper);

        public override void WriteEntity(XmlWriter xmlWriter, IEntity entity)
        {
            Newspaper newsPaper = entity as Newspaper;
            if (newsPaper.IsEmpty())
            {
                throw new ArgumentException($"provided {nameof(entity)} is null or not of type {nameof(Newspaper)}");
            }

            XElement element = new XElement("newspaper");
            AddAttribute(element, "name", newsPaper.Name, true);
            AddAttribute(element, "city", newsPaper.City);
            AddAttribute(element, "publishing", newsPaper.Publishing);
            AddAttribute(element, "year", newsPaper.Year.ToString());
            AddAttribute(element, "pagesCount", newsPaper.PagesCount.ToString());
            AddAttribute(element, "issn", newsPaper.ISSN, true);
            AddAttribute(element, "number", newsPaper.Number.ToString());
            AddAttribute(element, "date", Convert.ToDateTime(newsPaper.Date).ToShortDateString());
            AddElement(element, "note", newsPaper.Note);
            element.WriteTo(xmlWriter);
        }
    }
}
