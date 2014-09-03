using System;
using System.Globalization;

namespace ExtensionsNet.Extensions
{
    /// <summary>
    ///     Extension class for <see cref="String" />.
    /// </summary>
    /// <author>Cyril Schumacher</author>
    /// <date>03/09/2014T14:21:53+01:00</date>
    /// <copyright file="/Extensions/StringExtensions.cs">
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
    public static class StringExtensions
    {
        #region Methods.

        /// <summary>
        ///     Replaces each element forming a specified by the text equivalent of the value of a corresponding object chain.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="parameters">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of format in which the format items have been replaced by the string representation of the corresponding objects in <paramref name="parameters"/>.</returns>
        public static string FormatWith(this string format, params object[] parameters)
        {
            return FormatWith(format, CultureInfo.InvariantCulture, parameters);
        }

        /// <summary>
        ///     Replaces each element forming a specified by the text equivalent of the value of a corresponding object chain.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <param name="parameters">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of format in which the format items have been replaced by the string representation of the corresponding objects in <paramref name="parameters"/>.</returns>
        public static string FormatWith(this string format, IFormatProvider provider, params object[] parameters)
        {
            return string.Format(provider, format, parameters);
        }
        /// <summary>
        ///     Indicates whether the specified string is a valid date.
        /// </summary>
        /// <param name="value">Value represents a date.</param>
        /// <returns>True if <paramref name="value"/> is a valid date, otherwise, False.</returns>
        public static bool IsDate(this string value)
        {
            DateTime dateTime;
            return !string.IsNullOrEmpty(value) && DateTime.TryParse(value, out dateTime);
        }

        /// <summary>
        ///     Indicates whether the specified string is a valid date.
        /// </summary>
        /// <param name="value">Value represents a date.</param>
        /// <param name="supportedFormats">Value represents a date.</param>
        /// <returns>True if <paramref name="value"/> is a valid date, otherwise, False.</returns>
        public static bool IsDate(this string value, params string[] supportedFormats)
        {
            DateTime result;
            return DateTime.TryParseExact(value, supportedFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
        }

        /// <summary>
        ///     Determines if the date is W3C format.
        /// </summary>
        /// <param name="value">Value represents a date.</param>
        /// <returns>True if <paramref name="value"/> is a W3C date, otherwise, False.</returns>
        public static bool IsW3CDate(this string value)
        {
            return IsDate(value, "yyyy-MM-dd", "YYYY-MM-DDThh:mmTZD", "YYYY-MM-DDThh:mm:ssTZD", "YYYY-MM-DDThh:mm:ss.sTZD");
        }

        #endregion Methods.
    }
}
