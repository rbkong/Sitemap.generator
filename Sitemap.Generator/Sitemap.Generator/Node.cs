using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Sitemap.Generator
{
    public class Node: IComparable<Node>, IEquatable<Node>
    {
        public string Link { get; set; }
        public int Index { get; }

        public Node(string link)
        {
            Link = link; 
            Index = Count(link) - 2;
        }
        //public static bool operator ==(Node a, Node b)
        //{
        //    return a.Link.Equals(b.Link);
        //}

        //public static bool operator !=(Node a, Node b)
        //{
        //    return !a.Link.Equals(b.Link);
        //}

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}

        private int Count(string str)
        {
            var result = 0;
            foreach(char c in str)
            {
                if (c == '/') result++;
            }
            return result;
        }

        public int CompareTo([AllowNull] Node other)
        {
            if (other == null) return 1;
            if(this.Index == other.Index) { return this.Link.CompareTo(other.Link); }
            return this.Index.CompareTo(other.Index); 
        }

        public bool Equals([AllowNull] Node other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return Link.Equals(other.Link);
        }
    }
}
