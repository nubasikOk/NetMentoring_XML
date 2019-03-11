using System;
using System.Xml;

namespace XMLWorker.Interfaces
{
    public interface IXmlElementWriter
    {
        Type TypeToWrite { get; }

        void WriteEntity(XmlWriter xmlWriter, IEntity entity);
    }
}
