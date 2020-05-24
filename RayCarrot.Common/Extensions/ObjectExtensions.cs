using System;

namespace RayCarrot.Common
{
    /// <summary>
    /// Extension methods for an <see cref="Object"/>
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Casts the object to the specified type
        /// </summary>
        /// <typeparam name="T">The type to cast to</typeparam>
        /// <param name="item">The object to cast</param>
        /// <returns>The same object, cast to the specified type</returns>
        /// <exception cref="InvalidCastException">The item can not be cast to the specified type</exception>
        public static T CastTo<T>(this object item)
        {
            return (T)item;
        }
    }
}