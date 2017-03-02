namespace HTML_Parser.Core.Habr
{
    class HabrSettings : IParserSettings
    {

        public HabrSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }

        public string BaseUrl { get; set; } = "https://habrahabr.ru";
        public string Prefix { get; set; } = "page";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
