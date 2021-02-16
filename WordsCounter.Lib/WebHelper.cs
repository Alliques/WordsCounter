using HtmlAgilityPack;
using System.IO;
using System.Text;

namespace WordsCounter.Lib
{
    public class WebHelper
    {
        public string Url { get; }
        //public string FilePath { get; set; }
        public WebHelper(string url)
        {
            Url = url;
        }
       
        //private string CreateFolder()
        //{
        //    var directory = Directory.CreateDirectory(Settings.DefaultPath);
        //    return directory.FullName;
        //}
        public HtmlDocument GetHtmlDocument()
        {
            var web = new HtmlWeb();
            web.OverrideEncoding = Encoding.UTF8;

            return web.Load(Url);
        }
    }
}
