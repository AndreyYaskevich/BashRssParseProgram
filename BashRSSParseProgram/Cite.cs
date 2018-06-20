using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashRSSParseProgram
{
    class Cite
    {
        public string Title { get; set; }

        public Uri URL { get; set; }

        public string Description { get; set; }

        public DateTime PubDate { get; set; }

        public string CiteContent { get; set; }

        public Cite()
        {

        }

        
    }
}
