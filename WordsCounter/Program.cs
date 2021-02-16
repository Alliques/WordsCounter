using System;
using HtmlAgilityPack;
using WordsCounter.Lib;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WordsCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            //args =new string[] { @"https://www.simbirsoft.com/"};
            ParseHtmlDocument(args);
            Console.ReadLine();
        }
        public static void ParseHtmlDocument(string[] args)
        {
            try
            {
                Init(args);
                WebHelper webHelper = new WebHelper(args[0]);
                DocumentManager documentManager = new DocumentManager();
                documentManager.WriteText(webHelper.GetHtmlDocument().Text);

                var text = File.ReadAllText(Settings.DefaultPath + Settings.FileName + Settings.FileExtention,Encoding.Default);

                Parser parser = new Parser();
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(text);

                var statistics = Parser.CountingWords(parser.ConvertToWordsArray(parser.ExtractViewableText(htmlDocument.DocumentNode)));

                PrintStatistics(statistics);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Проверьте правильность введенных данных! Проверьте корректность URL!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //public void InitFolders()
        //{

        //}
        public static void Init(string[] args)
        {
            if(args.Length>1)
            {
                Settings.DefaultPath = args[1];
                Settings.FileName=Settings.FileName.Insert(0, @"\");
            }
            if(args.Length>2)
            {
                Settings.DefaultPath = args[1];
                Settings.FileName =@"\"+ args[2];
            }
        }

        public static void PrintStatistics(Dictionary<string,int> statistics)
        {
            foreach (var item in statistics.OrderByDescending(o=>o.Value))
            {
                Console.WriteLine(item.Key + " - " + item.Value.ToString());
            }
        }
    }
}
