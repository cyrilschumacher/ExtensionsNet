using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ExtensionsNet.Web.Extensions
{
    /// <summary>
    ///     Extension class for <see cref="System.Web.Mvc.Html" />.
    /// </summary>
    /// <author>Cyril Schumacher</author>
    /// <date>03/09/2014T16:58:54+01:00</date>
    /// <copyright file="/Extensions/HtmlExtensions.cs">
    ///     The MIT License (MIT)
    ///
    ///     Copyright (c) 2014, ExtensionsNet by Cyril Schumacher
    ///
    ///     Permission is hereby granted, free of charge, to any person obtaining a copy
    ///     of this software and associated documentation files (the "Software"), to deal
    ///     in the Software without restriction, including without limitation the rights
    ///     to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    ///     copies of the Software, and to permit persons to whom the Software is
    ///     furnished to do so, subject to the following conditions:
    ///
    ///     The above copyright notice and this permission notice shall be included in
    ///     all copies or substantial portions of the Software.
    ///
    ///     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    ///     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    ///     FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    ///     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    ///     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    ///     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    ///     THE SOFTWARE.
    /// </copyright>
    [CLSCompliant(true)]
    public static class HtmlExtensions
    {
        #region Constants.

        /// <summary>
        ///     Format of title of website.
        /// </summary>
        private const string TitleFormat = "{0} - ";

        #endregion Constants.

        #region Methods.

        /// <summary>
        ///     Return a <c><base /></c> by Uri address of page.
        /// </summary>
        /// <param name="helper">Html helper.</param>
        /// <returns>The HTML markup without encoding.</returns>
        public static IHtmlString Base(this HtmlHelper helper)
        {
            var href = new Uri(HttpContext.Current.Request.Url.AbsoluteUri, UriKind.Absolute);

            var tag = new TagBuilder("base");
            tag.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(new { href }));

            return new MvcHtmlString(tag.ToString(TagRenderMode.SelfClosing));
        }

        /// <summary>
        ///     Return a <c><meta /></c> by attributes.
        /// </summary>
        /// <param name="helper">Html helper.</param>
        /// <param name="htmlAttributes">Html attributes.</param>
        /// <returns>The HTML markup without encoding.</returns>
        public static IHtmlString Meta(this HtmlHelper helper, object htmlAttributes)
        {
            var tag = new TagBuilder("meta");
            tag.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            return new MvcHtmlString(tag.ToString(TagRenderMode.SelfClosing));
        }

        /// <summary>
        ///     Return a <c><meta /></c> by a name and a specific content.
        /// </summary>
        /// <param name="helper">Html helper.</param>
        /// <param name="name">Name of metadata.</param>
        /// <param name="content">Content of metadata.</param>
        /// <returns>The HTML markup without encoding.</returns>
        public static IHtmlString Meta(this HtmlHelper helper, string name, string content)
        {
            return Meta(helper, name, content, false);
        }

        /// <summary>
        ///     Return a <c><meta /></c> by a name and a specific content.
        /// </summary>
        /// <param name="helper">Html helper.</param>
        /// <param name="name">Name of metadata.</param>
        /// <param name="content">Content of metadata.</param>
        /// <param name="ignoreIfNull">Ignore if the content is empty.</param>
        /// <returns>The HTML markup without encoding.</returns>
        public static IHtmlString Meta(this HtmlHelper helper, string name, string content, bool ignoreIfNull)
        {
            if (ignoreIfNull && string.IsNullOrEmpty(content))
            {
                return null;
            }

            content = HttpUtility.HtmlEncode(content);
            return Meta(helper, new { name, content });
        }

        /// <summary>
        ///     Return a <c><title /></c> by a title of website and categories of the current page.
        /// </summary>
        /// <param name="helper">Html helper.</param>
        /// <param name="websiteName">Title of Website.</param>
        /// <param name="pageCategories">Categories of the current page.</param>
        /// <returns>The HTML markup without encoding.</returns>
        public static IHtmlString Title(this HtmlHelper helper, string websiteName, params string[] pageCategories)
        {
            var title = pageCategories.Where(category => !string.IsNullOrEmpty(category))
                .Aggregate(new StringBuilder(), (builder, category) => builder.AppendFormat("{0} - ", category)).Append(websiteName);

            return Title(helper, title.ToString());
        }

        /// <summary>
        ///     Return a <c><title /></c> by a title of website.
        /// </summary>
        /// <param name="helper">Html helper.</param>
        /// <param name="websiteName">Title of Website.</param>
        /// <returns>The HTML markup without encoding.</returns>
        public static IHtmlString Title(this HtmlHelper helper, string websiteName)
        {
            var tag = new TagBuilder("title")
            {
                InnerHtml = HttpUtility.HtmlEncode(websiteName)
            };

            return new MvcHtmlString(tag.ToString());
        }

        #endregion Methods.
    }
}