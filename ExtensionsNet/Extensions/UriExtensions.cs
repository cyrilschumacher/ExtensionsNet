using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ExtensionsNet.Extensions
{
    /// <summary>
    ///     Extension class for <see cref="Uri" />.
    /// </summary>
    /// <author>Cyril Schumacher</author>
    /// <date>03/09/2014T16:01:31+01:00</date>
    /// <copyright file="/Extensions/UriExtensions.cs">
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
    public static class UriExtensions
    {
        #region Constants.

        /// <summary>
        ///     Format of Uri parameters.
        /// </summary>
        private const string UriParametersFormat = "{0}?{1}";

        #endregion Constants.

        #region Methods.

        /// <summary>
        ///     Add informations of request.
        /// </summary>
        /// <param name="address">Uri address.</param>
        /// <param name="parameters">Parameters.</param>
        /// <exception cref="ArgumentNullException">Throw if <paramref name="address"/> or <paramref name="parameters"/> is null.</exception>
        public static Uri AddParameters(this Uri address, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            return AddParameters(address, parameters, CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///     Add informations of request.
        /// </summary>
        /// <param name="address">Uri address.</param>
        /// <param name="parameters">Parameters.</param>
        /// <param name="format">A composite format string.</param>
        /// <exception cref="ArgumentNullException">Throw if <paramref name="address"/> or <paramref name="parameters"/> is null.</exception>
        public static Uri AddParameters(this Uri address, IEnumerable<KeyValuePair<string, string>> parameters, IFormatProvider format)
        {
            if (address == null)
            {
                throw new ArgumentNullException("address", "The parameter is null.");
            }

            if (parameters == null)
            {
                throw new ArgumentNullException("parameters", "The parameter is null.");
            }

            var uri = string.Format(format, UriParametersFormat, address, _ToQueryString(parameters));
            return new Uri(uri, address.IsAbsoluteUri ? UriKind.Absolute : UriKind.Relative);
        }

        /// <summary>
        ///     Compares the specified parts of two URIs using the comparison rules specified.
        /// </summary>
        /// <param name="address">Uri address.</param>
        /// <param name="secondAddress">Second uri address.</param>
        /// <returns>True if two Uri address are identical, otherwise, False.</returns>
        /// <exception cref="ArgumentNullException">Throw if <paramref name="address"/> is null.</exception>
        public static bool Compare(this Uri address, string secondAddress)
        {
            if (address == null)
            {
                throw new ArgumentNullException("address", "The parameter is null.");
            }

            return address.OriginalString.Equals(secondAddress);
        }

        /// <summary>
        ///     Return the domain.
        /// </summary>
        /// <param name="address">Uri address.</param>
        /// <returns>Domain.</returns>
        /// <exception cref="ArgumentNullException">Throw if <paramref name="address"/> is null.</exception>
        public static string GetDomain(this Uri address)
        {
            if (address == null)
            {
                throw new ArgumentNullException("address", "The parameter is null.");
            }

            var hostParts = address.Host.Split('.');
            return String.Join(".", hostParts.Skip(Math.Max(0, hostParts.Length - 2)).Take(2));
        }

        /// <summary>
        ///     Return the informations of request.
        /// </summary>
        /// <param name="address">Uri address.</param>
        /// <returns>Informations of request.</returns>
        /// <exception cref="ArgumentNullException">Throw if <paramref name="address"/> is null.</exception>
        public static IDictionary<string, string> GetParametersQuery(this Uri address)
        {
            if (address == null)
            {
                throw new ArgumentNullException("address", "The parameter is null.");
            }

            var queries = address.Query.Trim('?').Split('&');
            return queries.Select(query => query.Split('='))
                .ToLookup(parameter => parameter[0], parameter => parameter[1])
                .ToDictionary(parameter => parameter.Key.ToString(), parameter => parameter.FirstOrDefault());
        }

        #region Privates.

        /// <summary>
        ///     Converts a generic collection of key/value pairs in a string representation of the query information.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        /// <returns>Parameters.</returns>
        private static string _ToQueryString(IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var query = new StringBuilder();
            foreach (var parameter in parameters)
            {
                query.Append(string.Format(CultureInfo.InvariantCulture, "{0}={1}&", parameter.Key, parameter.Value));
            }

            return query.ToString();
        }

        #endregion Privates.

        #endregion Methods.
    }
}