using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ExtensionsNet.Extensions;

namespace ExtensionsNet.Desktop.Extensions
{
    /// <summary>
    ///     Extension class for <see cref="ICustomAttributeProvider" />.
    /// </summary>
    /// <author>Cyril Schumacher</author>
    /// <date>03/09/2014T16:29:35+01:00</date>
    /// <copyright file="/Extensions/ICustomAttributeProviderExtensions.cs">
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
    public static class ICustomAttributeProviderExtensions
    {
        #region Methods.

        /// <summary>
        ///     Return the value of attribute.
        /// </summary>
        /// <typeparam name="T">Attribute type.</typeparam>
        /// <param name="customAttributeProvider">Attribute.</param>
        /// <param name="attributeType">Attribute type.</param>
        /// <param name="propertyName">Property name.</param>
        /// <returns><paramref name="customAttributeProvider" /> attribute value.</returns>
        /// <exception cref="System.ArgumentNullException">Throw if <paramref name="customAttributeProvider" /> is null.</exception>
        public static T GetAttributeValue<T>(this ICustomAttributeProvider customAttributeProvider, Type attributeType,
            string propertyName) where T : class
        {
            if (customAttributeProvider == null) throw new ArgumentNullException("customAttributeProvider");

            // Obtient les attributs selon le type de l'objet.
            var attributes = customAttributeProvider.GetCustomAttributes(attributeType, false);
            if (attributes.Length <= 0) return default(T);

            // Obtient et récupére la valeur du premier attribut.
            var attribute = attributes.FirstOrDefault();
            return attribute == null ? default(T) : ObjectExtensions.GetAttributeValue<T>(attribute, propertyName);
        }

        /// <summary>
        ///     Return the attributes by a type.
        /// </summary>
        /// <typeparam name="T">Attributes type.</typeparam>
        /// <param name="customAttributeProvider">Attribute.</param>
        /// <returns>Enumerable of attributes.</returns>
        /// <exception cref="System.ArgumentNullException">Throw if <paramref name="customAttributeProvider" /> is null.</exception>
        public static IEnumerable<T> GetCustomAttributesByType<T>(this ICustomAttributeProvider customAttributeProvider)
            where T : class
        {
            if (customAttributeProvider == null)
            {
                throw new ArgumentNullException("customAttributeProvider", "The parameter is null.");
            }

            return from customAttribute in customAttributeProvider.GetCustomAttributes(true).OfType<T>()
                select customAttribute;
        }

        #endregion Methods.
    }
}