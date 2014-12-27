using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HyperlinkExtract
{
    class ListItem
    {
        public string Display { get; set; }
        public string Path { get; set; }

        public override string ToString()
        {
            return Display;
        }
    }
}
