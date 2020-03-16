using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sitemap.Generator
{
    /// <summary>
    /// Class html contains data tha will be parsed 
    /// by the html parser. When the install of the class 
    /// is created, the user need to call the gethml in 
    /// order to get the html response.
    /// </summary>
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
