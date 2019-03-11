﻿using System;
using System.Xml.Linq;
using XMLWorker.Exceptions;
using XMLWorker.Interfaces;

namespace XMLWorker.Parsers
{
    public abstract class BaseXmlParser : IXmlElementParser
    {
        public abstract string ElementName { get; }
        public abstract IEntity ParseElement(XElement element);
        protected string GetAttributeValue(XElement element, string name, bool isMandatory = false)
        {
            var attribute = element.Attribute(name);
            if (attribute.IsEmpty() && isMandatory)
            {
                throw new MandatoryAttributeMissedException($"{name}");
            }

            return attribute?.Value;
        }

        protected XElement GetElement(XElement parentElement, string name, bool isMandatory = false)
        {
            var element = parentElement.Element(name);
            if (element.IsEmpty() && isMandatory)
            {
                throw new MandatoryElementMissedException($"{name}");
            }

            return element;
        }

        protected DateTime GetDate(string dateInvariant)
        {
            if (string.IsNullOrEmpty(dateInvariant))
            {
                return default(DateTime);
            }

            return Convert.ToDateTime(dateInvariant);
        }
    }
}
