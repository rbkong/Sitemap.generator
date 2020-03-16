using System;
using System.Collections.Generic;
using System.Text;

namespace Sitemap.Generator
{
    public class Node
    {
        public string Link { get; set; }
        public int Index { get; set; }

        public Node(string link, int index)
        {
            Link = link; Index = index;
        }
        public static bool operator ==(Node a, Node b)
        {
            return a.Link.Equals(b.Link);
        }

        public static bool operator !=(Node a, Node b)
        {
            return !a.Link.Equals(b.Link);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
