using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionsNet.Extensions
{
    /// <summary>
    ///     Extension class for <see cref="IEnumerable{T}" />.
    /// </summary>
    /// <author>Cyril Schumacher</author>
    /// <date>03/09/2014T15:43:53+01:00</date>
    /// <copyright file="/Extensions/IEnumerableExtensions.cs">
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
    public static class IEnumerableExtensions
    {
        #region Methods.

        /// <summary>
        ///     Determines the element is the first in a list.
        /// </summary>
        /// <typeparam name="T">Enumerable type.</typeparam>
        /// <param name="enumerable">Enumerable.</param>
        /// <param name="item">Element to test.</param>
        /// <returns>True if the element is the first, otherwise, False.</returns>
        public static bool IsFirst<T>(this IEnumerable<T> enumerable, T item)
        {
            var first = enumerable.FirstOrDefault();
            return !Equals(first, default(T)) && item.Equals(first);
        }

        /// <summary>
        ///     Determines the element is the last in a list.
        /// </summary>
        /// <typeparam name="T">Enumerable type.</typeparam>
        /// <param name="enumerable">Enumerable.</param>
        /// <param name="item">Element to test.</param>
        /// <returns>True if the element is the last, otherwise, False.</returns>
        public static bool IsLast<T>(this IEnumerable<T> enumerable, T item)
        {
            var last = enumerable.LastOrDefault();
            return !Equals(last, default(T)) && item.Equals(last);
        }

        /// <summary>
        ///     Get a random element list.
        /// </summary>
        /// <typeparam name="T">Enumerable type.</typeparam>
        /// <param name="enumerable">Enumerable.</param>
        /// <returns>Random element enumerable.</returns>
        public static IEnumerable<T> Random<T>(this IEnumerable<T> enumerable) where T : class
        {
            return enumerable.OrderBy(x => Guid.NewGuid());
        }

        /// <summary>
        ///     Get a random element list.
        /// </summary>
        /// <typeparam name="T">Enumerable type.</typeparam>
        /// <param name="enumerable">Valeur.</param>
        /// <param name="count">Number of items to return.</param>
        /// <returns>Random element enumerable.</returns>
        public static IEnumerable<T> Random<T>(this IEnumerable<T> enumerable, int count) where T : class
        {
            return Random(enumerable).Take(count);
        }

        #endregion Methods.
    }
}