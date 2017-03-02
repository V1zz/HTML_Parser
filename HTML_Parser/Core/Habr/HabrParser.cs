using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace HTML_Parser.Core.Habr
{
    class HabrParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var items = document.QuerySelectorAll("a")
                        .Where(item => item.ClassName != null 
                        && item.ClassName.Contains("post__title_link"));

            return items.Select(item => item.TextContent).ToArray();
        }
        public string[] Parse2(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("a")
                        .Where(item => item.ClassName != null
                         && item.ClassName.Contains("post__title_link"));
            
            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }
            return list.ToArray();
        }
    }
}
