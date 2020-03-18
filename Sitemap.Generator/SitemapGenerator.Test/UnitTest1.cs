using NUnit.Framework;
using Sitemap.Generator;
using System.Collections.Generic;

namespace SitemapGenerator.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        public void SitemapCreator()
        {
            List<Node> nodes = new List<Node> { new Node("index", 1), 
                new Node("product", 1), new Node("about", 1) };
            string xmltest = @"<?xml version=""1.0"" encoding=""UTF-8""?>" +
@"<urlset xmlns=""http://www.sitemaps.org/schemas/sitemap/0.9"">" +
@"<url><loc>http://www.example.com/</loc><lastmod>2005-01-01</lastmod>" +
@"<changefreq>monthly</changefreq><priority>0.8</priority></url></urlset>";
        }
    }
}