using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.ServiceModel;

namespace BashRSSParseProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var cites = RssReader.RssFeedParse(RssConfig.URL);
            foreach (var cite in cites)
            {
                Console.WriteLine("Title: {0}\nURL: {1}\nDescription: {2}\nPublishDate: {3}\n{4}\n", cite.Title, cite.URL, cite.Description, cite.PubDate, cite.CiteContent);
            }
            Console.ReadKey();

        }


    }
}
