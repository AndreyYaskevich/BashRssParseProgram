using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Syndication;
namespace BashRSSParseProgram
{
    class RssReader
    {
        
        public static List<Cite> RssFeedParse(string URL)
        {
            List<Cite> cites= new List<Cite>();
            XmlReader reader = XmlReader.Create(URL);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            foreach (SyndicationItem item in feed.Items)
            {
                Cite cite = new Cite();
                cite.Title = item.Title.Text;
                cite.URL = item.Links[0].Uri;
                cite.PubDate = item.PublishDate.DateTime;
                cite.CiteContent = FormatQuoteData(item.Summary.Text);

                cites.Add(cite);
            }
            
            return cites;
        }

        private static string FormatQuoteData(string QuoteData)
        {
            StringBuilder FormatedQuoteData = new StringBuilder();
            char[] str = QuoteData.ToCharArray();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '<' && str[i + 1] == 'b' && str[i + 2] == 'r' && str[i + 3] == '>')
                {
                    i += 3;
                    FormatedQuoteData.Append('\n');
                    continue;
                }
                FormatedQuoteData.Append(str[i]);
            }

            return FormatedQuoteData.ToString();
        }

    }
}
