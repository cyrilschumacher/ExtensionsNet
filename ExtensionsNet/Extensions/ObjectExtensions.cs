using System;
using System.Collections.Generic;

namespace ExtensionsNet.Extensions
{
    /// <summary>
    ///     Extension class for <see cref="object" />.
    /// </summary>
    /// <author>Cyril Schumacher</author>
    /// <date>03/09/2014T15:43:53+01:00</date>
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
    public static class ObjectExtensions
    {
        #region Methods.

        /// <summary>
        ///     Return the value of attribute.
        /// </summary>
        /// <typeparam name="T">Attribute type.</typeparam>
        /// <param name="value">Attribute.</param>
        /// <param name="propertyName">Name of property.</param>
        /// <returns><paramref name="value" /> attribute value.</returns>
        /// <exception cref="ArgumentNullException">Throw if <paramref name="value"/> is null.</exception>
        public static T GetAttributeValue<T>(this object value, string propertyName) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "The parameter is null.");
            }

            return value.GetType().GetProperty(propertyName).GetValue(value, null) as T;
        }

        /// <summary>
        ///     Determines if the object is null.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns>True if the value is null, otherwise, False.</returns>
        public static bool IsNull(this object value)
        {
            return value == null;
        }

        /// <summary>
        ///     Determines if the object is no-null.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns>True if the value is no-null, otherwise, False.</returns>
        public static bool IsNotNull(this object value)
        {
            return value != null;
        }

        /// <summary>
        ///     Return enumerable.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="value">Value.</param>
        /// <returns>Enumerable.</returns>
        public static IEnumerable<T> ToEnumerable<T>(this T value)
        {
            yield return value;
        }

        #endregion Methods.
    }
}