using System.Xml.Linq;

namespace XMLWorker
{
    public static class ExtensionMethods
    {
        public static bool IsEmpty(this XAttribute attribute)
        {
            return string.IsNullOrEmpty(attribute?.Value);
        }

        public static bool IsEmpty(this XElement element)
        {
            return string.IsNullOrEmpty(element?.Value);
        }

        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsEmpty(this object value)
        {
            return value==null;
        }
    }
}
