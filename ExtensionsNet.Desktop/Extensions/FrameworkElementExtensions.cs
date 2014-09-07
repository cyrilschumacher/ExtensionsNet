using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace ExtensionsNet.Desktop.Extensions
{
    /// <summary>
    ///     Classe d'extension pour le type <see cref="FrameworkElement"/>.
    /// </summary>
    /// <author>Cyril Schumacher</author>
    /// <date>04/02/2014T13:41:22+01:00</date>
    /// <copyright file="/Extensions/FrameworkElementExtensions.cs">
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
    public static class FrameworkElementExtensions
    {
        #region Methods.

        /// <summary>
        ///     Return the ancestors of the element to the root. 
        /// </summary>
        /// <param name="node">Current element.</param>
        /// <returns>Enumerator contains the ancestors.</returns>
        public static IEnumerable<FrameworkElement> GetVisualAncestors(this FrameworkElement node)
        {
            var parent = node.GetVisualParent();
            while (parent != null)
            {
                yield return parent;
                parent = parent.GetVisualParent();
            }
        }

        /// <summary>
        ///     Return the visual parent of element.
        /// </summary>
        /// <param name="node">Element to check.</param>
        /// <returns>Visual parent.</returns>
        public static FrameworkElement GetVisualParent(this FrameworkElement node)
        {
            return VisualTreeHelper.GetParent(node) as FrameworkElement;
        }

        #endregion Methods.
    }
}