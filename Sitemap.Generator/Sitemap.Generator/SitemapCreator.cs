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
        public static XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
        public static XNamespace xs = "http://www.w3.org/2001/XMLSchema-instance";
        public static XNamespace nxs = "http://www.sitemaps.org/schemas/sitemap/0.9";

        private static void AddNode(ref XDocument xmldoc, string link,
            string changef, string priority)
        {
            XElement node = new XElement(nxs +"url",
                new XElement(nxs +"loc", link),
                new XElement(nxs +"changefreq", changef),
                new XElement(nxs + "priority", priority)
                );
            xmldoc.Root.Add(node);
        }

        public static string Generate(List<Node> data, string changef,
            string priority)
        {
           
            XDocument sitemap = new XDocument(
                new XDeclaration("1.0", "UTF-8", "no"),
                new XElement( nxs + "urlset",
                new XAttribute("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9"),
                    new XAttribute(XNamespace.Xmlns + "xsi", xs),
                    new XAttribute(xs + "SchemaLocation", 
                    "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd")
                    )
                );
            data.ForEach(node => AddNode(ref sitemap, node.Link, changef, priority));
            string path = @"C:\Web Sites\main\xml\sitemap.xml";
            sitemap.Save(path, SaveOptions.None);
            //sitemap.Save(@"C:\Web Sites\main\xml\sitemap.xml", SaveOptions.None);
            return path;
        }
    }
}
