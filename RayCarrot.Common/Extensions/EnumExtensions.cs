using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RayCarrot.Common
{
    /// <summary>
    /// Extension methods for <see cref="Enum"/>
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets all flags in the specified <see cref="Enum"/>
        /// </summary>
        /// <param name="input">The <see cref="Enum"/> to check</param>
        /// <returns>The flags</returns>
        /// <exception cref="ArgumentException">input is not an <see cref="Enum"/></exception>
        /// <exception cref="ArgumentNullException">input is null</exception>
        /// <exception cref="InvalidOperationException">The method is invoked by reflection in a reflection-only context, -or- 
        /// input s a type from an assembly loaded in a reflection-only context</exception>
        public static IEnumerable<Enum> GetFlags(this Enum input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            foreach (Enum value in Enum.GetValues(input.GetType()))
                if (input.HasFlag(value))
                    yield return value;
        }

        /// <summary>
        /// Gets all flags in the specified <see cref="Enum"/>
        /// </summary>
        /// <typeparam name="T">The type of enum</typeparam>
        /// <param name="input">The <see cref="Enum"/> to check</param>
        /// <returns>The flags</returns>
        /// <exception cref="ArgumentException">input is not an <see cref="Enum"/></exception>
        /// <exception cref="ArgumentNullException">input is null</exception>
        /// <exception cref="InvalidOperationException">The method is invoked by reflection in a reflection-only context, -or- 
        /// input s a type from an assembly loaded in a reflection-only context</exception>
        public static IEnumerable<T> GetFlags<T>(this T input)
            where T : Enum
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            foreach (Enum value in Enum.GetValues(input.GetType()))
                if (input.HasFlag(value))
                    yield return (T)value;
        }

        /// <summary>
        /// Gets all values for an <see cref="Enum"/>
        /// </summary>
        /// <typeparam name="T">The type of enum</typeparam>
        /// <param name="input">The enum to get values from</param>
        /// <returns>An array with the values</returns>
        /// <exception cref="ArgumentException">input is not an <see cref="Enum"/></exception>
        /// <exception cref="ArgumentNullException">input is null</exception>
        /// <exception cref="InvalidOperationException">The method is invoked by reflection in a reflection-only context, -or- 
        /// input s a type from an assembly loaded in a reflection-only context</exception>
        public static T[] GetValues<T>(this T input)
            where T : Enum
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            return EnumHelpers.GetValues<T>();
        }

        /// <summary>
        /// Gets the first attribute of specified type for the enum value
        /// </summary>
        /// <typeparam name="T">The type of attribute to retrieve</typeparam>
        /// <param name="value">The enum value to get the attribute for</param>
        /// <returns>The attribute instance</returns>
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            // Get the member info for the value
            var memberInfo = value.GetType().GetMember(value.ToString());

            // Get the attribute
            var attributes = memberInfo.First().GetCustomAttributes<T>(false);

            // Return the first attribute
            return attributes.FirstOrDefault();
        }
    }
}