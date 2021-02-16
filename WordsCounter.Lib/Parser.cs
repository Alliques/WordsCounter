using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;
namespace WordsCounter.Lib
{
    public class Parser
    {
        public string[] ConvertToWordsArray(string text)
        {
            
            return text.Split(Settings.ReservedChars, StringSplitOptions.RemoveEmptyEntries);
        }
        ///// <summary>
        ///// Removed artifacts in the form of tabs
        ///// </summary>
        ///// <returns></returns>
        //public string RemoveArtifacts()
        //{

        //}
        /// <summary>
        /// Returns words from all HTML nodes
        /// </summary>
        /// <param name="node">Root html node</param>
        /// <returns>Text that contains all the words in the input html</returns>
        public string ExtractViewableText(HtmlNode node)
        {
            StringBuilder sb = new StringBuilder();
            ExtractViewableTextHelper(sb, node);
            return sb.ToString();
        }

        /// <summary>
        /// clipping scripts and styles
        /// </summary>
        /// <param name="sb">Some string builder</param>
        /// <param name="node">Html node</param>
        private void ExtractViewableTextHelper(StringBuilder sb, HtmlNode node)
        {
            if (node.Name != "script" && node.Name != "style")
            {
                if (node.NodeType == HtmlNodeType.Text)
                {
                    AppendNodeText(sb, node);
                }

                foreach (HtmlNode child in node.ChildNodes)
                {
                    ExtractViewableTextHelper(sb, child);
                }
            }
        }

        /// <summary>
        /// The division words
        /// </summary>
        /// <param name="sb">Input StringBuilder</param>
        /// <param name="node">Some HtmlNode</param>
        private string AppendNodeText(StringBuilder sb, HtmlNode node)
        {
            string text = ((HtmlTextNode)node).Text;
            if (string.IsNullOrWhiteSpace(text) == false)
            {
                sb.Append(text);

                // если последний символ не пробел, то добавляем пробел, чтобы не было слияния слов
                if (!text.EndsWith("\u0009") || !text.EndsWith("\u000A") || !text.EndsWith("\u0020") || !text.EndsWith("\u000D"))
                {
                    sb.Append("\u0020");
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Returns words statistics in dictionary format
        /// </summary>
        /// <param name="wordsArray">input words array</param>
        /// <returns></returns>
        public static Dictionary<string, int> CountingWords(string[] wordsArray)
        {
            Dictionary<string, int> wordsDictionary = new Dictionary<string, int>();

            foreach (var word in wordsArray)
            {
                if (wordsDictionary.ContainsKey(word))
                {
                    wordsDictionary[word]++;
                }
                else
                {
                    wordsDictionary.Add(word, 1);
                }
            }
            return wordsDictionary;
        }

        //public string RemoveReservedCharacters(string strValue)
        //{
        //    return new string(strValue.Where(x => !Settings.ReservedChars.Contains(x)).ToArray());
        //}
    }
}
