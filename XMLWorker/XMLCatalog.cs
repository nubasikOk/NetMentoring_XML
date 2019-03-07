using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XMLWorker.Abstract;
using XMLWorker.Exceptions;

namespace XMLWorker
{
    class XMLCatalog
    {
        private static string _catalogElementName = "catalog";

        private readonly IDictionary<string, IXmlElementParser> _elementParsers;
        private readonly IDictionary<Type, IXmlElementWriter> _entityWriters;

        public XMLCatalog()
        {
            _elementParsers = new Dictionary<string, IXmlElementParser>();
            _entityWriters = new Dictionary<Type, IXmlElementWriter>();
        }

        public void AddParsers(params IXmlElementParser[] elementParsers)
        {
            foreach (var parser in elementParsers)
            {
                _elementParsers.Add(parser.ElementName, parser);
            }
        }

        public void AddWriters(params IXmlElementWriter[] writers)
        {
            foreach (var writer in writers)
            {
                _entityWriters.Add(writer.TypeToWrite, writer);
            }
        }

        public IEnumerable<IEntity> ReadFrom(TextReader input)
        {
            using (XmlReader xmlReader = XmlReader.Create(input, new XmlReaderSettings
            {
                IgnoreWhitespace = true,
                IgnoreComments = true
            }))
            {
                xmlReader.ReadToFollowing(_catalogElementName);
                xmlReader.ReadStartElement();

                do
                {
                    while (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        var node = XNode.ReadFrom(xmlReader) as XElement;
                        IXmlElementParser parser;
                        if (_elementParsers.TryGetValue(node.Name.LocalName, out parser))
                        {
                            yield return parser.ParseElement(node);
                        }
                        else
                        {
                            throw new UnknownElementException($"Founded unknown element tag: {node.Name.LocalName}");
                        }
                    }
                } while (xmlReader.Read());
            }
        }

        public void WriteTo(TextWriter output, IEnumerable<IEntity> catalogEntities)
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(output, new XmlWriterSettings()))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement(_catalogElementName);
                foreach (var catalogEntity in catalogEntities)
                {
                    IXmlElementWriter writer;
                    if (_entityWriters.TryGetValue(catalogEntity.GetType(), out writer))
                    {
                        writer.WriteEntity(xmlWriter, catalogEntity);
                    }
                    else
                    {
                        throw new EntityWriterNotFoundedException($"Cannot find entity writer for type {catalogEntity.GetType().FullName}");
                    }
                }
                xmlWriter.WriteEndElement();
            }
        }
    }
}
