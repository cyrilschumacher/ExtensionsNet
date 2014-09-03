using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ExtensionsNet.Desktop.Extensions
{
    /// <summary>
    ///     Extension class for <see cref="XmlSerializer" />.
    /// </summary>
    /// <author>Cyril Schumacher</author>
    /// <date>03/09/2014T16:47:52+01:00</date>
    /// <copyright file="/Extensions/XmlSerializerExtensions.cs">
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
    public static class XmlSerializerExtensions
    {
        #region Methods.

        /// <summary>
        ///     Serialize a object into a <see cref="string"/>.
        /// </summary>
        /// <typeparam name="T">Type of the object to serialize.</typeparam>
        /// <param name="model">Object to serialize.</param>
        /// <returns>Object serialized.</returns>
        public static string SerializeToString<T>(T model)
            where T : class
        {
            return SerializeToString<T>(model, Encoding.UTF8);
        }

        /// <summary>
        ///     Serialize a object into a <see cref="string"/>.
        /// </summary>
        /// <typeparam name="T">Type of the object to serialize.</typeparam>
        /// <param name="model">Object to serialize.</param>
        /// <param name="encoding">Encoding.</param>
        /// <returns>Object serialized.</returns>
        public static string SerializeToString<T>(T model, Encoding encoding)
            where T : class
        {
            return SerializeToString<T>(model, Encoding.UTF8, false);
        }

        /// <summary>
        ///     Serialize a object into a <see cref="string"/>.
        /// </summary>
        /// <typeparam name="T">Type of the object to serialize.</typeparam>
        /// <param name="model">Object to serialize.</param>
        /// <param name="encoding">Encoding.</param>
        /// <param name="indent">If the string must be indented.</param>
        /// <returns>Object serialized.</returns>
        public static string SerializeToString<T>(T model, Encoding encoding, bool indent)
            where T : class
        {
            using (var writer = new StringWriter(CultureInfo.InvariantCulture))
            {
                return _SerializeToString(new XmlSerializer(typeof (T)), model, writer,
                    new XmlWriterSettings {Indent = indent, Encoding = encoding});
            }
        }

        /// <summary>
        ///     Deserialize a XML file into a class.
        /// </summary>
        /// <typeparam name="T">Class type.</typeparam>
        /// <param name="path">Path to XML file.</param>
        /// <returns>Object instance.</returns>
        public static T Deserialize<T>(string path) where T : class
        {
            return Deserialize<T>(path, Encoding.UTF8);
        }

        /// <summary>
        ///     Deserialize a XML file into a class.
        /// </summary>
        /// <typeparam name="T">Class type.</typeparam>
        /// <param name="path">Path to XML file.</param>
        /// <param name="encoding">Encoding.</param>
        /// <returns>Object instance.</returns>
        public static T Deserialize<T>(string path, Encoding encoding) where T : class
        {
            using (var reader = new StreamReader(path, encoding))
            {
                return _Deserializer<T>(new XmlSerializer(typeof (T)), new XmlTextReader(reader));
            }
        }

        #region Privates.

        /// <summary>
        ///     Deserialize a XML file into a class.
        /// </summary>
        /// <typeparam name="T">Class type.</typeparam>
        /// <param name="serializer">Class instance of <see cref="XmlSerializer" />.</param>
        /// <param name="reader">Class instance of <see cref="XmlReader" />.</param>
        /// <returns>File content.</returns>
        private static T _Deserializer<T>(XmlSerializer serializer, XmlReader reader) where T : class
        {
            return (serializer.CanDeserialize(reader))
                ? serializer.Deserialize(reader) as T
                : default(T);
        }

        /// <summary>
        ///     Serialize a object into a <seealso cref="string"/>.
        /// </summary>
        /// <typeparam name="T">Class type.</typeparam>
        /// <param name="serializer">Class instance of <see cref="XmlSerializer" />.</param>
        /// <param name="model">Object to serialize.</param>
        /// <param name="writer">Stream contains the result of serialization.</param>
        /// <param name="settings">Parameters.</param>
        /// <returns>XML content.</returns>
        private static string _SerializeToString<T>(XmlSerializer serializer, T model, TextWriter writer,
            XmlWriterSettings settings)
        {
            using (var xmlWriter = XmlWriter.Create(writer, settings))
            {
                serializer.Serialize(xmlWriter, model);
                return writer.ToString();
            }
        }

        #endregion Privates.

        #endregion Methods.
    }
}