using System;
using System.Collections.Generic;
using System.Text;

namespace Sitemap.Generator
{
    public static class HtmlParser
    {
        public static List<string> GetTags(string webcontent)
        {
            List<string> tags = new List<string>();
            string pattern_tag = @"\w*a.*?href=(""|')(?<ref>.*?)(""|').*?>(.*?)<\w/a\w*>";
            return null;
        }
    }
}
