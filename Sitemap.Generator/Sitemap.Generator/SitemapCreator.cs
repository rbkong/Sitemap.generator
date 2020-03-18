using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Sitemap.Generator
{
    /// <summary>
    /// This class generates a XML sitemap file
    /// from a collection of string.
    /// The generate methode use add node methode 
    /// to populate the xml file with url node.
    /// </summary>
    public static class SitemapCreator
    {
        public static XNamespace x = "";
        public static XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
        public static XNamespace xs = "http://www.w3.org/2001/XMLSchema-instance";

        private static void AddNode(ref XDocument xmldoc, string link,
            string changef, string priority)
        {
            XElement node = new XElement("url",
                new XElement("loc", link),
                new XElement("changefreq", changef),
                new XElement("priority", priority)
                );
            xmldoc.Root.Add(node);
        }

        public static void Generate(List<Node> data, string changef,
            string priority)
        {
            XDocument sitemap = new XDocument(
                new XDeclaration("1.0", "UTF-8", "no"),
                new XElement(ns + "urlset",
                    new XAttribute(XNamespace.Xmlns + "xsi", xs),
                    new XAttribute(xs + "SchemaLocation", 
                    "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd")
                    )
                );
            data.ForEach(node => AddNode(ref sitemap, node.Link, changef, priority));
            sitemap.Save("sitemap.xml", SaveOptions.None);
        }
    }
}
