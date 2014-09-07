using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;

namespace ExtensionsNet.Desktop.Extensions
{
    /// <summary>
    ///     Extension class for <see cref="BitmapImage" />.
    /// </summary>
    /// <author>Cyril Schumacher</author>
    /// <date>18/07/2013T16:04:21+01:00</date>
    /// <copyright file="/Extensions/BitmapImageExtensions.cs">
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
    public static class BitmapImageExtensions
    {
        #region Methods.

        /// <summary>
        ///     Convert Base64 data to <see cref="BitmapImage"/>.
        /// </summary>
        /// <param name="base64String">Data.</param>
        /// <returns>Bitmap image.</returns>
        public static BitmapImage FromBase64(string base64String)
        {
            var rawData = Convert.FromBase64String(base64String);
            using (var memory = new MemoryStream(rawData, 0, rawData.Length))
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = memory;
                bitmap.EndInit();

                return bitmap;
            }
        }

        /// <summary>
        ///     Create a bitmap image from data.
        /// </summary>
        /// <param name="buffer">Data.</param>
        /// <returns>Bitmap image.</returns>
        public static BitmapImage FromSource(IEnumerable<byte> buffer)
        {
            var image = new BitmapImage();
            image.SetSource(buffer);

            return image;
        }

        /// <summary>
        ///     Create a bitmap image from data.
        /// </summary>
        /// <param name="buffer">Data.</param>
        /// <returns>Bitmap image.</returns>
        public static BitmapImage FromSource(IEnumerable<sbyte> buffer)
        {
            var image = new BitmapImage();
            image.SetSource(buffer);

            return image;
        }

        /// <summary>
        ///     Set the source.
        /// </summary>
        /// <param name="bitmap">Bitmap.</param>
        /// <param name="buffer">Data.</param>
        /// <exception cref="System.ArgumentNullException">Throw if <paramref name="bitmap"/> or <paramref name="buffer"/> is null.</exception>
        public static void SetSource(this BitmapImage bitmap, byte[] buffer)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException("bitmap");
            }

            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            using (var memory = new MemoryStream(buffer))
            {
                bitmap.BeginInit();
                bitmap.StreamSource = memory;
                bitmap.EndInit();
            }
        }

        /// <summary>
        ///     Set the source.
        /// </summary>
        /// <param name="bitmap">Bitmap.</param>
        /// <param name="buffer">Data.</param>
        /// <exception cref="System.ArgumentNullException">Throw if <paramref name="bitmap"/> or <paramref name="buffer"/> is null.</exception>
        public static void SetSource(this BitmapImage bitmap, IEnumerable<byte> buffer)
        {
            SetSource(bitmap, buffer.ToArray());
        }

        /// <summary>
        ///     Set the source.
        /// </summary>
        /// <param name="bitmap">Bitmap.</param>
        /// <param name="buffer">Data.</param>
        /// <exception cref="System.ArgumentNullException">Throw if <paramref name="bitmap"/> or <paramref name="buffer"/> is null.</exception>
        public static void SetSource(this BitmapImage bitmap, IEnumerable<sbyte> buffer)
        {
            SetSource(bitmap, buffer.ToArray());
        }
        #endregion Methods.
    }
}