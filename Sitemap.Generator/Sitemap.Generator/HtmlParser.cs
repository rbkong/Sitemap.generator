using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Sitemap.Generator
{
    public static class HtmlParser
    {
        private static string pattern_tag = @"\w*a.*?href=(""|')(?<ref>.*?)(""|').*?>(.*?)<\w/a\w*>";
        public static List<Node> GetTags(string webcontent, int index, string url)
        {
            List<string> tags = new List<string>();
            List<Node> nodes = new List<Node>();
            MatchCollection matches = Regex.Matches(webcontent, pattern_tag);
            foreach(Match match in matches)
            {
                string result = (match.Groups["ref"]).ToString();
                result = result.Trim();

                if (result[^1] != '/') result += "/";
                if(result[0] == '/' && !tags.Contains(result))
                {
                    result = url + result;
                }
            }
            tags.ForEach(lk => nodes.Add(new Node(lk, index)));
            return nodes;
        }
    }
}

