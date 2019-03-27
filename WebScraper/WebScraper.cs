using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace ConsoleApp1
{
    class WebScraper
    {
        private const string titlePath = "/html/head/title";
        static void Main(string[] args)
        {
            string[] urls = new string[] {"https://www.facebook.com/",
                                          "https://stackoverflow.com/",
                                          "https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/foreach-in",
                                          "https://www.hejDennaSidanFinnsInte.se",
                                          "https://www.dsek.se/"};
            foreach (string url in urls)
            {
                Console.WriteLine("Finding title of " + url);
                List<string> list = HandleTitle(GetTitle(url, 10));
                list.ForEach(word => Console.Write(word + " "));
                Console.WriteLine("\n");
            }
            Console.ReadLine();
        }
        public static string GetTitle(string url, int nbrRetries)
        {
            for (int i = 0; i < nbrRetries; i++)
            {
                try
                {
                    HtmlDocument htmlDoc = new HtmlWeb().Load(url);
                    Console.WriteLine("Try: " + (i + 1));
                    return htmlDoc.DocumentNode.SelectSingleNode(titlePath).InnerHtml;
                }
                catch { Console.WriteLine("try: " + (i + 1)); }
            }
            return "Page could not be found";
        }

        public static List<string> HandleTitle(string title)
        {
            List<string> list = new List<string>(title.Split(' '));
            list.Reverse();
            return list;
        }
    }
}