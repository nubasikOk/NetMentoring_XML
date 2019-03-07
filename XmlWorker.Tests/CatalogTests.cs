using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using XMLWorker;
using XMLWorker.Comparers;
using XMLWorker.Entities;
using XMLWorker.Parsers;
using XMLWorker.Writers;

namespace XmlWorker.Tests
{
    [TestFixture]
    public class CatalogTests
    {
        private XMLCatalog _catalog;
        private Book CreateBook()
        {
            return new Book
            {
                Name = "War and peace",
                City = "Saint-Petersburg",
                Publishing = "Astrel",
                Year = 2010,
                PagesCount = 1200,
                ISBN = "978-1-56619-909-4",
                Note = "This book is about war and peace.",
                Authors = new List<Author>
                {
                    new Author {FirstName = "Lev", LastName = "Tolstoi"}
                }
            };
        }

        private string GetBookXml()
        {
            return @"<book name=""War and peace"" " +
                       @"city=""Saint-Petersburg"" " +
                       @"publishing=""Astrel"" " +
                       @"year=""2010"" " +
                       @"pagesCount=""1200"" " +
                       @"isbn=""978-1-56619-909-4"">" +
                       "<note>This book is about war and peace.</note>" +
                       "<authors>" +
                            @"<author firstName=""Lev"" lastName=""Tolstoi"" />" +
                       "</authors>" +
                   "</book>";
        }

        private Newspaper CreateNewspaper()
        {
            return new Newspaper
            {
                Name = "Evening Grodno",
                City = "Grodno",
                Publishing = "Evening Grodno",
                Year = 2019,
                PagesCount = 12,
                ISSN = "1476-4687",
                Note = "Only latest news.",
                Number = 3,
                Date = new DateTime(1905, 5, 16),
            };
        }

        private string GetPaperXml()
        {
            return "<newspaper name=\"Evening Grodno\" " +
                       "city=\"Grodno\" " +
                       "publishing=\"Evening Grodno\" " +
                       "year=\"2019\" " +
                       "pagesCount=\"12\" " +
                       "date=\"05/16/1905\" " +
                       "issn=\"1476-4687\" " +
                       "number=\"3\">" +
                       "<note>Only latest news.</note>" +
                   "</newspaper>";
        }

        [SetUp]
        public void Init()
        {
            _catalog = new XMLCatalog();
            _catalog.AddParsers(new BookParser(), new NewspapersParser(), new PatentParser());
            _catalog.AddWriters(new BookWriter(),new NewspapersWriter(), new PatentWriter());
        }

        [Test]
        public void Test_Book_Reader()
        {
            TextReader sr = new StringReader(@"<?xml version=""1.0"" encoding=""utf-8""?>" +
                                             "<catalog>" +
                                             GetBookXml() +
                                             "</catalog>");

            var books = _catalog.ReadFrom(sr);

            CollectionAssert.AreEqual(books, new[] { CreateBook() }, new BooksComparer());

            sr.Dispose();

        }

        [Test]
        public void Test_Paper_Reader()
        {
            TextReader sr = new StringReader(@"<?xml version=""1.0"" encoding=""utf-8""?>" +
                                             "<catalog>" +
                                             GetPaperXml() +
                                             "</catalog>");

            var papers = _catalog.ReadFrom(sr);
            foreach(var paper in papers)
            {
                Console.WriteLine((paper as Newspaper).Date.ToShortDateString());
            }
            CollectionAssert.AreEqual(papers, new[] { CreateNewspaper() }, new NewspapersComparer());

            sr.Dispose();

        }
    }
}
