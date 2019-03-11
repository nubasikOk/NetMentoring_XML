using System.Xml.Linq;

namespace XMLWorker.Interfaces
{
    public interface IXmlElementParser 
    {
        string ElementName { get; }
        IEntity ParseElement(XElement element);
    }
}
