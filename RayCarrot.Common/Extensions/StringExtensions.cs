using System;
using System.Collections.Generic;
using System.Linq;

namespace RayCarrot.Common
{
    /// <summary>
    /// Extension methods for a <see cref="String"/>
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Returns true if the string is null or an empty string
        /// </summary>
        /// <param name="value">The string</param>
        /// <returns>True if the string is null or empty, false if not</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return String.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Returns true if the string is null or an empty string or just whitespace
        /// </summary>
        /// <param name="value">The string</param>
        /// <returns>True if the string is null, empty or just white space, false if not</returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return String.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Replaces every occurrence of the old characters with the new string
        /// </summary>
        /// <param name="value">The string to replace the characters in</param>
        /// <param name="oldChars">The old characters to replace</param>
        /// <param name="newString">The string to replace the old characters with</param>
        /// <returns>The string with the characters replaced</returns>
        /// <exception cref="ArgumentNullException"/>
        public static string Replace(this string value, char[] oldChars, string newString)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (oldChars == null)
                throw new ArgumentNullException(nameof(oldChars));

            if (newString == null)
                throw new ArgumentNullException(nameof(newString));

            return String.Join(newString, value.Split(oldChars, StringSplitOptions.RemoveEmptyEntries));
        }

        /// <summary>
        /// Determines whether a <see cref="String"/> object and other specified <see cref="String"/> objects have the same value
        /// </summary>
        /// <param name="value">The <see cref="String"/> object to compare to</param>
        /// <param name="values">The <see cref="String"/> objects to compare</param>
        /// <returns>True if one of the specified values has the same value as the <see cref="String"/> object they were compared against,
        /// or false if not or if one of the parameters is null</returns>
        public static bool Equals(this string value, params string[] values)
        {
            if (value == null || values == null)
                return false;

            foreach (string item in values)
            {
                if (value.Equals(item))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="String"/> object and other specified <see cref="String"/> objects have the same value
        /// </summary>
        /// <param name="value">The <see cref="String"/> object to compare to</param>
        /// <param name="stringComparison">The <see cref="StringComparison"/> to use</param>
        /// <param name="values">The <see cref="String"/> objects to compare</param>
        /// <returns>True if one of the specified values has the same value as the <see cref="String"/> object they were compared against,
        /// or false if not or if one of the parameters is null</returns>
        public static bool Equals(this string value, StringComparison stringComparison, params string[] values)
        {
            if (value == null || values == null)
                return false;

            foreach (string item in values)
            {
                if (value.Equals(item, stringComparison))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Gets all indexes of a specific value in a string
        /// </summary>
        /// <param name="str">The string to get the indexes from</param>
        /// <param name="value">The value to search for</param>
        /// <returns>The found indexes</returns>
        public static IEnumerable<int> AllIndexesOf(this string str, string value)
        {
            if (value.IsNullOrEmpty())
                throw new ArgumentException("The string to find may not be empty", nameof(value));

            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index, StringComparison.Ordinal);

                if (index == -1)
                    break;

                yield return index;
            }
        }

        /// <summary>
        /// Removes the specified parts of a string
        /// </summary>
        /// <param name="input">The string to remove the parts from</param>
        /// <param name="toRemove">The parts of the string to remove</param>
        /// <returns>The new string with the specified parts removed</returns>
        public static string Remove(this string input, IEnumerable<string> toRemove)
        {
            return toRemove.Where(x => !x.IsNullOrWhiteSpace()).Aggregate(input, (current, s) => current.Replace(s, String.Empty));
        }

        /// <summary>
        /// Truncates a string to have the specified maximum length
        /// </summary>
        /// <param name="value">The string to truncate</param>
        /// <param name="maxLength">The max string length</param>
        /// <returns>The truncated string</returns>
        public static string Truncate(this string value, int maxLength)
        {
            if (value.IsNullOrEmpty()) 
                return value;

            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}