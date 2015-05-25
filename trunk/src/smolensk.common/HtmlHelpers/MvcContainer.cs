using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace smolensk.common.HtmlHelpers
{
    /// <summary>
    /// Определяет куда вставлять добавочный текст котейнера
    /// </summary>
    public enum InsertAt
    {
        /// <summary>
        /// Перед содержимым контейнера
        /// </summary>
        Begin,
        /// <summary>
        /// После содержимого контейнера
        /// </summary>
        End
    }

    public class MvcContainer : IDisposable
    {
        protected bool Disposed { get; set; }
        protected HttpResponseBase HttpResponse { get; set; }
        protected string Tag { get; set; }
        protected string AdditionalText { get; set; }
        protected InsertAt Insertion { get; set; }

        public MvcContainer(HttpResponseBase httpResponse, string tag, string _additionalText = null,
                            InsertAt _insertion = InsertAt.End)
        {
            if (httpResponse == null)
            {
                throw new ArgumentNullException("httpResponse");
            }

            if (string.IsNullOrEmpty(tag))
            {
                throw new ArgumentNullException("tag");
            }

            this.HttpResponse = httpResponse;
            this.Tag = tag;
            AdditionalText = _additionalText ?? String.Empty;
            Insertion = _insertion;

            if (Insertion == InsertAt.Begin) WriteAdditionalText();
        }

        /// <summary>
        /// Write the closing tag
        /// </summary>
        public virtual void EndContainer()
        {
            this.Dispose(true);
        }

        protected void WriteAdditionalText()
        {
            this.HttpResponse.Write(MvcHtmlString.Create(AdditionalText));
        }

        #region IDisposable Members

        /// <summary>
        /// Write the closing tag
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                this.Disposed = true;
                if (Insertion == InsertAt.End) WriteAdditionalText();
                this.HttpResponse.Write(string.Format("</{0}>", this.Tag));
            }
        }

        #endregion
    }
}