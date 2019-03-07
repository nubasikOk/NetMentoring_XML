using System.Xml.Linq;

namespace XMLWorker.Abstract
{
    public interface IXmlElementParser 
    {
        string ElementName { get; }
        IEntity ParseElement(XElement element);
    }
}
