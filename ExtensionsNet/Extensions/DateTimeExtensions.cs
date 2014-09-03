using System;
using System.Globalization;

namespace ExtensionsNet.Extensions
{
    /// <summary>
    ///     Extension class for <see cref="DateTime" />.
    /// </summary>
    /// <author>Cyril Schumacher</author>
    /// <date>03/09/2014T14:13:26+01:00</date>
    /// <copyright file="/Extensions/DateTimeExtensions.cs">
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
    public static class DateTimeExtensions
    {
        #region Methods.

        /// <summary>
        ///     Indicates whether the specified string is a date in a format.
        /// </summary>
        /// <param name="date">Date.</param>
        /// <param name="supportedFormats">Formats supported.</param>
        /// <returns>True if <paramref name="date"/> is a specified format, otherwise, False.</returns>
        /// <exception cref="ArgumentNullException">Throw if <paramref name="date"/> or <paramref name="supportedFormats"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throw if <paramref name="supportedFormats"/> contains no parameters.</exception>
        public static bool IsDateFormat(this DateTime date, params string[] supportedFormats)
        {
            if (date == null)
            {
                throw new ArgumentNullException("date", "The parameter is null");
            }

            if (supportedFormats == null)
            {
                throw new ArgumentNullException("supportedFormats", "The parameter is null");
            }

            if (supportedFormats.Length == 0)
            {
                throw new ArgumentOutOfRangeException("supportedFormats", "No parameters have been given.");
            }

            DateTime result;
            return DateTime.TryParseExact(date.ToString(), supportedFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
        }

        #endregion Methods.
    }
}