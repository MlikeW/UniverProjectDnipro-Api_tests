using System;

namespace CommonUtilities.Methods.CustomAttributes
{
    public class XPathAttribute : Attribute
    {
        public string XPath { get; }

        public XPathAttribute(string xPath)
        {
            XPath = xPath;
        }
    }
}
