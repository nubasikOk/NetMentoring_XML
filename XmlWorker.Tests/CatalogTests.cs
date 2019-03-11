using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using XMLWorker;
using XMLWorker.Abstract;
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
            return "<book name=\"War and peace\" " +
                       "city=\"Saint-Petersburg\" " +
                       "publishing=\"Astrel\" " +
                       "year=\"2010\" " +
                       "pagesCount=\"1200\" " +
                       "isbn=\"978-1-56619-909-4\">" +
                       "<note>This book is about war and peace.</note>" +
                       "<authors>" +
                            "<author firstName=\"Lev\" lastName=\"Tolstoi\" />" +
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
                Number = 3,
                Date = new DateTime(2019, 3, 2),
                Note = "123",
            };
        }

        private string GetPaperXml()
        {
            return "<newspaper name=\"Evening Grodno\" "  +
                       "city=\"Grodno\" "  +
                       "publishing=\"Evening Grodno\" "  +
                       "year=\"2019\" " +
                       "pagesCount=\"12\" " +
                       "issn=\"1476-4687\" " +
                       "number=\"3\" " +
                       "date=\"3/2/2019\">" +
                       "<note>123</note>" +
                   "</newspaper>";
        }

        private Patent CreatePatent()
        {
            return new Patent
            {
                Name = "Patent",
                Creators = new List<Author>
                {
                    new Author {FirstName = "Ivan", LastName = "Ivanov"}
                },
                RegistrationNumber = 13456,
                FilingDate=new DateTime(2010,3,1),
                PublishDate= new DateTime(2011, 1, 12),
                Country="Russia",
                PagesCount = 10,
                Note = "A new patent"
            };
        }

        private string GetPatentXml()
        {
            return "<patent name=\"Patent\" " +
                       "number=\"13456\" " +
                       "filingDate=\"3/1/2010\" " +
                       "publishDate=\"1/12/2011\" " +
                       "country=\"Russia\" " +
                       "pagesCount=\"10\">" +
                       "<note>A new patent</note>" +
                       "<creators>" +
                            "<creator firstName=\"Ivan\" lastName=\"Ivanov\" />" +
                       "</creators>" +
                   "</patent>";
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
            TextReader sr = new StringReader(@"<?xml version=""1.0"" encoding=""utf-16""?>" +
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
            TextReader sr = new StringReader(@"<?xml version=""1.0"" encoding=""utf-16""?>" +
                                             "<catalog>" +
                                             GetPaperXml() +
                                             "</catalog>");

            var papers = _catalog.ReadFrom(sr);
            
               
           
            CollectionAssert.AreEqual(papers, new[] { CreateNewspaper() }, new NewspapersComparer());

            sr.Dispose();

        }

        [Test]
        public void Test_Patent_Reader()
        {
            TextReader sr = new StringReader(@"<?xml version=""1.0"" encoding=""utf-16""?>" +
                                             "<catalog>" +
                                             GetPatentXml() +
                                             "</catalog>");

            var patents = _catalog.ReadFrom(sr);

            CollectionAssert.AreEqual(patents, new[] { CreatePatent() }, new PatentsComparer());

            sr.Dispose();

        }

        [Test]
        public void Test_MixedEntities_Read()
        {
            TextReader sr = new StringReader(@"<?xml version=""1.0"" encoding=""utf-16""?>" +
                                             "<catalog>" +
                                                GetPatentXml() +
                                                GetBookXml() +
                                                GetPaperXml() +
                                             "</catalog>");

            var entities = _catalog.ReadFrom(sr).ToList();

            Assert.IsTrue(new PatentsComparer().Compare(entities[0], CreatePatent()) == 0);
            Assert.IsTrue(new BooksComparer().Compare(entities[1], CreateBook()) == 0);
            Assert.IsTrue(new NewspapersComparer().Compare(entities[2], CreateNewspaper()) == 0);

            sr.Dispose();
        }

        [Test]
        public void Test_MixedEntities_Write()
        {
            StringBuilder actualResult = new StringBuilder();
            StringWriter sw = new StringWriter(actualResult);
            var book = CreateBook();
            var newspaper = CreateNewspaper();
            var patent = CreatePatent();
            var entities = new IEntity[]
            {
                book,
                newspaper,
                patent
            };
            string expectedResult = @"<?xml version=""1.0"" encoding=""utf-16""?>" +
                "<catalog>" +
                    GetBookXml()+
                    GetPaperXml()+
                    GetPatentXml()+
                "</catalog>";

            _catalog.WriteTo(sw, entities);
            sw.Dispose();
            Assert.AreEqual(expectedResult, actualResult.ToString());
        }

    }
}
