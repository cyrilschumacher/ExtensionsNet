using System;
using System.Globalization;
using System.Web.Mvc;

namespace ExtensionsNet.Web.Extensions
{
    /// <summary>
    ///     Extension class for <see cref="UrlHelper" />.
    /// </summary>
    /// <author>Cyril Schumacher</author>
    /// <date>03/09/2014T16:48:19+01:00</date>
    /// <copyright file="/Extensions/UrlHelperExtensions.cs">
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
    public static class UrlHelperExtensions
    {
        #region Constants.

        /// <summary>
        ///     Format anchor.
        /// </summary>
        private const string AnchorFormat = "{0}#{1}";

        #endregion Constants.


        #region Methods.

        /// <summary>
        ///     Generates a <see cref="string"/> to a fully qualified URL to an action method.
        /// </summary>
        /// <param name="helper">Url helper.</param>
        /// <param name="actionName">Name of action method.</param>
        /// <param name="controllerName">Controller name.</param>
        /// <param name="anchor">Anchor.</param>
        /// <returns>A <see cref="string"/> to a fully qualified URL to an action method.</returns>
        /// <exception cref="System.ArgumentNullException">Throw if <paramref name="helper" /> is null.</exception>
        public static string Action(this UrlHelper helper, string actionName, string controllerName, string anchor)
        {
            if (helper == null)
            {
                throw new ArgumentNullException("helper", "The parameter is null.");
            }

            return string.Format(CultureInfo.InvariantCulture, AnchorFormat, helper.Action(actionName, controllerName), anchor);
        }

        #endregion Methods.
    }
}