using System;
using System.Globalization;
using System.Windows.Media;

namespace ExtensionsNet.Desktop.Extensions
{
    /// <summary>
    ///     Extension class for <see cref="string" />.
    /// </summary>
    /// <author>Cyril Schumacher</author>
    /// <date>08/09/2014T16:12:38+01:00</date>
    /// <copyright file="/Extensions/ObjectExtensions.cs">
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
        ///     Convert a hexadecimal value to <see cref="Color" />.
        /// </summary>
        /// <param name="hexaValue">Hexadecimal value.</param>
        /// <returns>Color.</returns>
        /// <exception cref="System.ArgumentNullException">Throw if <paramref name="hexaValue" /> is null.</exception>
        public static Color ToColor(string hexaValue)
        {
            if (hexaValue == null)
            {
                throw new ArgumentNullException("hexaValue", "The parameter is null");
            }

            hexaValue = hexaValue.Replace("#", string.Empty);
            var integerValue = _ConvertHexaToInteger(hexaValue);

            var alpha = (hexaValue.Length == 8) ? _ComputeAlpha(integerValue) : (byte)255;
            return Color.FromArgb(alpha, (byte)((integerValue >> 16) & 0xff), (byte)((integerValue >> 8) & 0xff), (byte)(integerValue & 0xff));
        }

        #region Privates.

        /// <summary>
        ///     Convert a hexadecimal color to integer color.
        /// </summary>
        /// <param name="hexaValue">Hexadecimal color.</param>
        /// <returns>Integer color.</returns>
        private static int _ConvertHexaToInteger(string hexaValue)
        {
            return int.Parse(hexaValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///     Compute a transparency of hexadecimal color.
        /// </summary>
        /// <param name="hexaValue">Hexadecimal color.</param>
        /// <returns>Alpha number.</returns>
        private static byte _ComputeAlpha(int hexaValue)
        {
            return (byte)(hexaValue >> 24);
        }

        #endregion Privates.

        #endregion Methods.
    }
}