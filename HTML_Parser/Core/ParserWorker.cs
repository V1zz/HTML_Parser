using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Parser.Html;

namespace HTML_Parser.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> _parser;
        IParserSettings _parserSettings;

        HtmlLoader _loader;

        bool _isActive ;

        #region Properties

        public IParser<T> Parser
        {
            get { return _parser; }
            set { _parser = value; }
        }

        public IParserSettings Settings
        {
            get { return _parserSettings; }
            set
            {
                _parserSettings = value;
                _loader = new HtmlLoader(value);
            }
        }

        public bool IsActive => _isActive;

        #endregion

        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted; 

        public ParserWorker(IParser<T> parser)
        {
            this._parser = parser;
        }


        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this._parserSettings = parserSettings;
        }

        public void Start()
        {
            _isActive = true;
            Worker();
        }

        public void Abort()
        {
            _isActive = false;
        }

        private async void Worker()
        {
            for (int i = _parserSettings.StartPoint; i < _parserSettings.EndPoint; i++)
            {
                if (!IsActive)
                {
                    OnCompleted?.Invoke(this);
                    return;;
                }

                var source = await _loader.GetSourseByPageId(i);
                var domParser = new HtmlParser();

                var document = await domParser.ParseAsync(source);

                var result  = _parser.Parse(document);
                
                OnNewData?.Invoke(this, result);
            }
            OnCompleted?.Invoke(this);
        }


    }
}
