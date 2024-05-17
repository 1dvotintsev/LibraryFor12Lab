using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLibrary
{
    public class SortByTag : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Emoji emoji1 = x as Emoji;
            Emoji emoji2 = y as Emoji;

            if (emoji1 == null || emoji2 == null) return -1;

            return string.Compare(emoji1.Tag, emoji2.Tag);
        }
    }
}
