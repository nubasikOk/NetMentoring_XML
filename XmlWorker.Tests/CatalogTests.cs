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

        [SetUp]
        public void Init()
        {
            _catalog = new XMLCatalog();
            _catalog.AddParsers(new BookParser());
            _catalog.AddWriters(new BookWriter());
        }

        [Test]
        public void Test_Reader()
        {
            TextReader sr = new StringReader(@"<?xml version=""1.0"" encoding=""utf-8""?>" +
                                             "<catalog>" +
                                             GetBookXml() +
                                             "</catalog>");

            var books = _catalog.ReadFrom(sr);

            CollectionAssert.AreEqual(books, new[] { CreateBook() }, new BooksComparer());

            sr.Dispose();

        }
    }
}
