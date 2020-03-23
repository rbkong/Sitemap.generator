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
            
            if (args.Length > 0)
            {
                Html html = new Html(args[0]);
                Console.WriteLine($"Process as started ...\n");
                await html.Process();
                List<string> temp = HtmlParser.GetTags(html.Content(), args[0]);
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
                        //Console.WriteLine("Error Occured: " + ex.Message);
                    }
                    double val = 1.0 - ((float)activeQueue.Count / (float)container.Count);
                    int percent = (int) (val * 100.0);
                    if(percent < 0) Console.Write($"\r0 %");
                    else Console.Write($"\r{percent} %");
                }

                Console.WriteLine("\nCrawling Done");
                container.Distinct().ToList();
                List<Node> ctn = new List<Node>();
                container.ForEach(item => ctn.Add(new Node(item)));
                ctn.Sort();
                string path = SitemapCreator.Generate(ctn, "weekly", "0.5");
                Console.WriteLine($"Sitemap Generated: {path}");
            }else
            {
                Console.WriteLine("Usage\n\n Sitemap.Generator <http(s)://website>\n\n" +
                    "Specify the targeted website using http:// in front.");
            }
            
        }
    }
}
