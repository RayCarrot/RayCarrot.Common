﻿using System;
using System.Collections.Generic;

namespace RayCarrot.Common
{
    /// <summary>
    /// Extension methods for an array of items
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Append the given objects to the array
        /// </summary>
        /// <typeparam name="T">The type of array</typeparam>
        /// <param name="source">The original array of values</param>
        /// <param name="toAdd">The values to append to the source</param>
        /// <returns>The new array</returns>
        /// <exception cref="ArgumentNullException"/>
        public static T[] Append<T>(this T[] source, params T[] toAdd)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (toAdd == null)
                throw new ArgumentNullException(nameof(toAdd));

            var list = new List<T>(source);

            list.AddRange(toAdd);

            return list.ToArray();
        }

        /// <summary>
        /// Prepend the given objects to the array
        /// </summary>
        /// <typeparam name="T">The type of array</typeparam>
        /// <param name="source">The original array of values</param>
        /// <param name="toAdd">The values to prepend to the source</param>
        /// <returns>The new array</returns>
        /// <exception cref="ArgumentNullException"/>
        public static T[] Prepend<T>(this T[] source, params T[] toAdd)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (toAdd == null)
                throw new ArgumentNullException(nameof(toAdd));

            var list = new List<T>(toAdd);
            list.AddRange(source);
            return list.ToArray();
        }
    }
}