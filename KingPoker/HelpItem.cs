using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPoker
{
    public class HelpItem
    {
        public string Text { get; set; }
        public bool IsHeader { get; set; }

        public HelpItem()
        {

        }

        public HelpItem(string text, bool isHeader)
        {
            Text = text;
            IsHeader = isHeader;
        }
    }
}
