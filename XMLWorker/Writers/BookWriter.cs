﻿using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using XMLWorker.Entities;
using XMLWorker.Interfaces;

namespace XMLWorker.Writers
{
    public class BookWriter : BaseXmlWriter
    {
        public override Type TypeToWrite => typeof(Book);

        public override void WriteEntity(XmlWriter xmlWriter, IEntity entity)
        {
            var book = entity as Book;
            if (book.IsEmpty())
            {
                throw new ArgumentException($"provided {nameof(entity)} is null or not of type {nameof(Book)}");
            }

            var element = new XElement("book");
            AddAttribute(element, "name", book.Name);
            AddAttribute(element, "city", book.City);
            AddAttribute(element, "publishing", book.Publishing);
            AddAttribute(element, "year", book.Year.ToString());
            AddAttribute(element, "pagesCount", book.PagesCount.ToString());
            AddAttribute(element, "isbn", book.ISBN);
            AddElement(element, "note", book.Note);
            AddElement(element, "authors",
                book.Authors?.Select(a => new XElement("author",
                    new XAttribute("firstName", a.FirstName),
                    new XAttribute("lastName", a.LastName)
                ))
            );

            element.WriteTo(xmlWriter);
        }
    }
}
