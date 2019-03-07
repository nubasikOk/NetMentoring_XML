using System;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using XMLWorker.Exceptions;

namespace XMLWorker.Abstract
{
    public abstract class BaseXmlWriter : IXmlElementWriter
    {
        public abstract Type TypeToWrite { get; }
        public abstract void WriteEntity(XmlWriter xmlWriter, IEntity entity);

        protected string GetInvariantShortDateString(DateTime date)
        {
            return date.ToString(CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern, CultureInfo.InvariantCulture);
        }

        protected void AddAttribute(XElement element, string attributeName, string value, bool isMandatory = false)
        {
            if (value.IsEmpty() && isMandatory)
            {
                throw new MandatoryAttributeMissedException($"Value of mandatory attribute \"{attributeName}\" is null or empty");
            }

            element.SetAttributeValue(attributeName, value);
        }

        protected void AddElement(XElement element, string newElementName, object value, bool isMandatory = false)
        {
            if (value.IsEmpty() && isMandatory)
            {
                throw new MandatoryElementMissedException($"Value of mandatory element \"{newElementName}\" is null");
            }

            var newElement = new XElement(newElementName, value);
            element.Add(newElement);
        }
    }
}
