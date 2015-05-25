using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;
using log4net;
using System.Reflection;

namespace smolensk.common.Infrastructure
{
    public class HtmlDomTransformer
    {
        private static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IMarkupProcessor MarkupProcessorChain { get; set; }
        
        public string Transform(string htmlText)
        {
            try
            {
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(htmlText);

                IMarkupProcessor current = MarkupProcessorChain;
                while (current != null)
                {
                    InvokeMarkupProcessor(current, document);
                    current = current.Previous;
                }

                return document.DocumentNode.OuterHtml;
            }
            catch (Exception ex)
            {
                log.Error("Failed to transform html text", ex);

                return htmlText;
            }
        }

        private void InvokeMarkupProcessor(IMarkupProcessor processor, HtmlDocument document)
        {
            // подумать над обработкой исключений
            // пока оставляем проброс на первом упавшем обработчике
            processor.ProcessMarkup(document);
        }
    }
}