using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sitemap.Generator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Queue<Node> activeQueue = new Queue<Node>();
            List<string> container = new List<string>();
            Html html = new Html("http://specialprojects.com");
            await html.Process();
            List<string> temp = HtmlParser.GetTags(html.Content(), "http://specialprojects.com");
            container.AddRange(temp);
            foreach (var item in container)
            {
                activeQueue.Enqueue(new Node(item));
            }
            container = container.Distinct().ToList();
            container.Sort();
            while (activeQueue.Count > 0)
            {
                try
                {
                    Node node = activeQueue.Dequeue();
                    //Console.WriteLine("Dequeue::" + node.Index.ToString() +"::"+ node.Link);
                    Html childhtml = new Html(node.Link);
                    await childhtml.Process();
                    List<string> tempNodes = HtmlParser.GetTags(childhtml.Content(),
                        "http://specialprojects.com");
                    tempNodes.ForEach(nd =>
                    {
                        if (!container.Contains(nd))
                        {
                            container.Add(nd);
                            activeQueue.Enqueue(new Node(nd));
                        }
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Occured: " + ex.Message);
                }
            }

            Console.WriteLine("Process Done");
            container.Distinct().ToList();
            List<Node> ctn = new List<Node>();
            container.ForEach(item => ctn.Add(new Node(item)));
            ctn.Sort();
            SitemapCreator.Generate(ctn, "weekly", "0.5");
            Console.ReadKey();
        }
    }
}
