using System;
using System.ComponentModel;
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

        public static T Convert<T>(this string input)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                   
                    return (T)converter.ConvertFromString(input);
                }
                return default(T);
            }
            catch (NotSupportedException)
            {
                return default(T);
            }
        }
    }
}
