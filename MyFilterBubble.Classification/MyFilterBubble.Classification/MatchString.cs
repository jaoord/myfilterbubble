using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilterBubble.Classification
{
    static class MatchString
    {
        public static string Create(string title, string text)
        {
            return title + " " + text;
        }
    }
}
