using AngleSharp.Dom.Html;

namespace HTML_Parser
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
