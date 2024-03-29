﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace ExtensionsNet.Extensions
{
    /// <summary>
    ///     Extension class for <see cref="ValueType" />.
    /// </summary>
    /// <author>Cyril Schumacher</author>
    /// <date>03/09/2014T14:32:35+01:00</date>
    /// <copyright file="/Extensions/ValueTypeExtensions.cs">
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
    public static class ValueTypeExtensions
    {
        #region Methods. 

        /// <summary>
        ///     Get an array of values ​​of the constants in a specified enumeration.
        /// </summary>
        /// <param name="valueType">Enumeration.</param>
        /// <returns>Array contains value constants in <paramref name="valueType"/>.</returns>
        /// <exception cref="ArgumentNullException">Throw if <paramref name="valueType"/> is null.</exception>
        public static Array GetValues(this ValueType valueType)
        {
            if (valueType == null)
            {
                throw new ArgumentNullException("valueType", "The parameter is null.");
            }

            var type = valueType.GetType();
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);

            return _GetMemberEnum(type, fields);
        }

        #region Privates.

        /// <summary>
        ///     Return the members of enumeration in array.
        /// </summary>
        /// <param name="valueType">Enumeration type.</param>
        /// <param name="fields">Fields of enumeration.</param>
        /// <returns>Array contains value of enumeration.</returns>
        private static Array _GetMemberEnum(Type valueType, IList<FieldInfo> fields)
        {
            var array = Array.CreateInstance(valueType, fields.Count);
            for (var i = 0; i < fields.Count; i++)
            {
                var obj = fields[i].GetValue(null);
                array.SetValue(obj, i);
            }

            return array;
        }

        #endregion Privates.

        #endregion Methods.
    }
}