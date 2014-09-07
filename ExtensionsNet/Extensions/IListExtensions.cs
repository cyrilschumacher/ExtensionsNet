using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionsNet.Extensions
{
    /// <summary>
    ///     Extension class for <see cref="IList{T}" />.
    /// </summary>
    /// <author>Cyril Schumacher</author>
    /// <date>13/01/2014T17:34:08+01:00</date>
    /// <copyright file="/Extensions/IListExtensions.cs">
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
    public static class IListExtensions
    {
        #region Methods.

        /// <summary>
        ///     Add a list of items of a <see cref="IList {T}" /> type.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="list">Collection.</param>
        /// <param name="items">Items to add.</param>
        /// <exception cref="ArgumentNullException">Throw if <paramref name="list"/> or <paramref name="items"/> is null.</exception>
        public static void AddRange<T>(this IList<T> list, IEnumerable<T> items)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            foreach (var item in items)
            {
                list.Add(item);
            }
        }

        /// <summary>
        ///     Add a list of uniques items of a <see cref="IList {T}" /> type.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="list">Collection.</param>
        /// <param name="items">Items to add.</param>
        /// <exception cref="ArgumentNullException">Throw if <paramref name="list"/> or <paramref name="items"/> is null.</exception>
        public static void AddUnique<T>(this IList<T> list, IEnumerable<T> items)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            foreach (var item in _GetNotExistingItems(list, items))
            {
                list.Add(item);
            }
        }

        /// <summary>
        ///     Remove all items by a list.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="list">Collection.</param>
        /// <param name="delete">Delegate that defines the conditions of the items to be removed.</param>
        /// <exception cref="ArgumentNullException">Throw if <paramref name="list"/> or <paramref name="delete"/> is null.</exception>
        public static int RemoveAll<T>(this IList<T> list, IEnumerable<T> delete)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            if (delete == null)
            {
                throw new ArgumentNullException("delete");
            }

            var itemToRemoves = delete as IList<T> ?? delete.ToList();
            foreach (var itemToRemove in itemToRemoves)
            {
                list.Remove(itemToRemove);
            }

            return itemToRemoves.Count();
        }

        #region Privates.

        /// <summary>
        ///     Returns only not-existing items of list.
        /// </summary>
        /// <typeparam name="T">Type of item.</typeparam>
        /// <param name="list">Collection.</param>
        /// <param name="items">Items to add.</param>
        /// <returns>Not-existing items.</returns>
        private static IEnumerable<T> _GetNotExistingItems<T>(ICollection<T> list, IEnumerable<T> items)
        {
            return from item in items where !list.Contains(item) select item;
        }

        #endregion Privates.

        #endregion Methods.
    }
}