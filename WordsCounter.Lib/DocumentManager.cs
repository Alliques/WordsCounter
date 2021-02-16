using System;
using System.IO;
using System.Net;

namespace WordsCounter.Lib
{
    public class DocumentManager
    {
        //public string FilePath { get; set; }
        public DocumentManager()
        {
            CreateFolder();
        }
       
        public void WriteText(string text, string path=null)
        {
            if(string.IsNullOrEmpty(path))
            {
                path = Settings.DefaultPath;
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(path+Settings.FileName+Settings.FileExtention, false, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(WebUtility.HtmlDecode(text));
                }
                Console.WriteLine("Запись выполнена. Путь к файлу: "+path+Settings.FileName + Settings.FileExtention);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private string CreateFolder()
        {
            var directory = Directory.CreateDirectory(Settings.DefaultPath);
            return directory.FullName;
        }
    }
}
