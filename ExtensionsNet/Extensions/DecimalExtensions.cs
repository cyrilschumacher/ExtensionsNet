using System.Globalization;

namespace ExtensionsNet.Extensions
{
    /// <summary>
    ///     Extension class for <see cref="decimal" />.
    /// </summary>
    /// <author>Cyril Schumacher</author>
    /// <date>26/01/2014T02:10:19+01:00</date>
    /// <copyright file="/Extensions/DecimalExtensions.cs">
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
    public static class DecimalExtensions
    {
        /// <summary>
        ///     Returns the number of decimal places.
        /// </summary>
        /// <param name="value">Decimal number.</param>
        /// <returns>Number of characters after the decimal point, otherwise, -1.</returns>
        public static int GetSignificantDigits(this decimal value)
        {
            return (value % 1).ToString(CultureInfo.InvariantCulture).Length - 2;
        }
    }
}
