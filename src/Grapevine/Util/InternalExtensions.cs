﻿using System.Text.RegularExpressions;

namespace Grapevine.Util
{
    public static class InternalExtensions
    {
        private static readonly Regex CamelCaseInner = new Regex(@"(\P{Ll})(\P{Ll}\p{Ll})", RegexOptions.Singleline | RegexOptions.Compiled);
        private static readonly Regex CamelCaseOuter = new Regex(@"(\p{Ll})(\P{Ll})", RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// Returns the string with spaces between inserted in the camel casing.
        /// </summary>
        internal static string ConvertCamelCase(this string s)
        {
            return CamelCaseOuter.Replace(CamelCaseInner.Replace(s, "$1 $2"), "$1 $2");
        }

        /// <summary>
        /// Returns true if this is of type &lt;T&gt;
        /// </summary>
        internal static bool IsA<T>(this object obj)
        {
            return obj is T || obj.GetType().IsInstanceOfType(typeof(T));
        }

        /// <summary>
        /// Returns true if this is NOT of type &lt;T&gt;
        /// </summary>
        internal static bool IsNot<T>(this object obj)
        {
            return !obj.IsA<T>();
        }
    }
}
