using System.Net.Http;
using System.Net;
using System.Threading.Tasks;

namespace HTML_Parser.Core
{
    class HtmlLoader
    {
        readonly HttpClient _client;

        readonly string _url;

        public HtmlLoader(IParserSettings settings)
        {
            _client = new HttpClient();
            _url = $"{settings.BaseUrl}/{settings.Prefix}/";
        }

        public async Task<string> GetSourseByPageId(int id)
        {
            var currentUrl = _url.Replace("{CurrentId", id.ToString());
            var response = await _client.GetAsync(currentUrl);
            string sourse = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                sourse = await response.Content.ReadAsStringAsync();
            }

            return sourse;
        } 
    }
}
