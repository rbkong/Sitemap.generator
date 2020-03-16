using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sitemap.Generator
{
    class Html
    {
        private string _content;
        private string _url;

        public Html(string url)
        {
            _url = url;
        }

        public async Task GetContent()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage msg = await client.GetAsync(_url);
                msg.EnsureSuccessStatusCode();
                _content = await msg.Content.ReadAsStringAsync();
                _content = Regex.Replace(_content, @"\t\n\r", "");
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
