using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ExtensionsNet.Extensions
{
    /// <summary>
    ///     Extension class for <see cref="Type" />.
    /// </summary>
    /// <author>Cyril Schumacher</author>
    /// <date>03/09/2014T15:51:08+01:00</date>
    /// <copyright file="/Extensions/TypeExtensions.cs">
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
    public static class TypeExtensions
    {
        #region Methods.

        /// <summary>
        ///     Get an array of values ​​of the constants in a specified enumeration.
        /// </summary>
        /// <typeparam name="T">Enumeration type of value.</typeparam>
        /// <param name="enumerationType">Enumeration type.</param>
        /// <returns>Enumerable contains value of enumeration.</returns>
        /// <exception cref="ArgumentNullException">Throw if <paramref name="enumerationType"/> is null.</exception>
        public static IEnumerable<T> GetValues<T>(Type enumerationType)
        {
            if (enumerationType == null)
            {
                throw new ArgumentNullException("enumerationType", "The parameter is null.");
            }

            try
            {
                var enumList = _ParseEnumeration(enumerationType);
                return enumList.Cast<T>().ToList();
            }
            catch (InvalidCastException)
            {
                // Return a default list if it is impossible to convert the values ​​of the enumeration into type defined.
                return new List<T>();
            }
        }


        #region Privates.

        /// <summary>
        ///     Get the metadata fields of enumeration.
        /// </summary>
        /// <param name="enumerationType">Enumeration type.</param>
        /// <returns>List of metadata.</returns>
        private static IEnumerable<FieldInfo> _GetFieldInfosEnumeration(Type enumerationType)
        {
            return enumerationType.GetFields().Where(field => field.IsLiteral);
        }

        /// <summary>
        ///     Parse the enumeration in a list of objects representing the fields of an <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="enumerationType">Enumeration type.</param>
        /// <returns>List of object.</returns>
        private static IEnumerable<object> _ParseEnumeration(Type enumerationType)
        {
            return _GetFieldInfosEnumeration(enumerationType).Select(field => field.GetValue(enumerationType));
        }

        #endregion Privates.

        #endregion Methods.
    }
}
