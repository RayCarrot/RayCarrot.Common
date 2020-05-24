using RayCarrot.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RayCarrot.Common
{
    /// <summary>
    /// Extension methods for an <see cref="IEnumerable{T}"/>
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Runs an action on each element of the enumerable object
        /// </summary>
        /// <typeparam name="T">The type of items in the enumerable object</typeparam>
        /// <param name="enumerable">The enumerable object to enumerate through</param>
        /// <param name="action">The action to run on each item</param>
        /// <exception cref="ArgumentNullException"/>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            foreach (T item in enumerable)
                action(item);
        }

        /// <summary>
        /// Concatenates the members of a constructed <see cref="IEnumerable{T}"/> collection of 
        /// type <see cref="String"/>, using the specified separator between each member
        /// </summary>
        /// <typeparam name="T">The type of objects in the enumerable</typeparam>
        /// <param name="enumerable">The enumerable</param>
        /// <param name="seperator">The separator to use between each object</param>
        /// <returns>A string that consists of the members of values delimited by the separator string.
        /// If values has no members, the method returns <see cref="String.Empty"/>.</returns>
        /// <exception cref="ArgumentNullException"/>
        public static string JoinItems<T>(this IEnumerable<T> enumerable, string seperator)
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            if (seperator == null)
                throw new ArgumentNullException(nameof(seperator));

            return String.Join(seperator, enumerable);
        }

        /// <summary>
        /// Concatenates the members of a constructed <see cref="IEnumerable{T}"/> collection of 
        /// type <see cref="String"/>, using the specified separator between each member
        /// </summary>
        /// <typeparam name="T">The type of objects in the enumerable</typeparam>
        /// <param name="enumerable">The enumerable</param>
        /// <param name="seperator">The separator to use between each object</param>
        /// <param name="formatter">The formatter to use for converting each object to a string</param>
        /// <returns>A string that consists of the members of values delimited by the separator string.
        /// If values has no members, the method returns <see cref="String.Empty"/>.</returns>
        /// <exception cref="ArgumentNullException"/>
        public static string JoinItems<T>(this IEnumerable<T> enumerable, string seperator, Func<T, string> formatter)
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            if (seperator == null)
                throw new ArgumentNullException(nameof(seperator));

            if (formatter == null)
                throw new ArgumentNullException(nameof(formatter));

            return String.Join(seperator, enumerable.Select(formatter));
        }

        /// <summary>
        /// Converts to an observable collection
        /// </summary>
        /// <typeparam name="T">The type of objects in the enumerable</typeparam>
        /// <param name="enumerable">The enumerable</param>
        /// <returns>The observable collection</returns>
        /// <exception cref="ArgumentNullException"/>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            if (enumerable is ObservableCollection<T> oc)
                return oc;

            return new ObservableCollection<T>(enumerable);
        }

        /// <summary>
        /// Returns an item matching the predicate in an enumerable
        /// </summary>
        /// <typeparam name="T">The type of objects in the enumerable</typeparam>
        /// <param name="enumerable">The enumerable</param>
        /// <param name="match">The predicate used to find the matching item</param>
        /// <returns>The item matching the predicate, or the default value if none was found</returns>
        /// <exception cref="ArgumentNullException"/>
        public static T FindItem<T>(this IEnumerable<T> enumerable, Predicate<T> match)
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            if (match == null)
                throw new ArgumentNullException(nameof(match));

            foreach (T item in enumerable)
                if (match(item))
                    return item;

            return default;
        }

        /// <summary>
        /// Returns the index of an item matching the predicate in a list
        /// </summary>
        /// <typeparam name="T">The type of objects in the list</typeparam>
        /// <param name="list">The list</param>
        /// <param name="match">The predicate used to find the matching item index</param>
        /// <returns>The item index matching the predicate, or -1 if none was found</returns>
        /// <exception cref="ArgumentNullException"/>
        public static int FindItemIndex<T>(this IList<T> list, Predicate<T> match)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (match == null)
                throw new ArgumentNullException(nameof(match));

            for (int i = 0; i < list.Count; i++)
                if (match(list[i]))
                    return i;

            return -1;
        }

        /// <summary>
        /// Returns the first occurrence of an item of the specified type in an enumerable
        /// </summary>
        /// <typeparam name="E">The type of items in the enumerable</typeparam>
        /// <typeparam name="T">The type of item to find and return</typeparam>
        /// <param name="enumerable">The enumerable</param>
        /// <returns>The first occurrence of an item of the specified type, or the default value if non was found</returns>
        /// <exception cref="ArgumentNullException"/>
        public static T FindItem<T, E>(this IEnumerable<E> enumerable)
            where T : class, E
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            return enumerable.FindItem(x => x.GetType() == typeof(T)) as T;
        }

        /// <summary>
        /// Adds a specified element to every second position of the list
        /// </summary>
        /// <typeparam name="T">The type of objects in the enumerable</typeparam>
        /// <param name="list">The list</param>
        /// <param name="element">The element to add</param>
        /// <returns>The new list with the added items</returns>
        /// <exception cref="ArgumentNullException"/>
        public static IEnumerable<T> Intersperse<T>(this IList<T> list, T element)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (element == null)
                throw new ArgumentNullException(nameof(element));

            bool first = true;
            foreach (T value in list)
            {
                if (!first)
                    yield return element;
                yield return value;
                first = false;
            }
        }

        /// <summary>
        /// Determines whether a sequence contains any elements
        /// </summary>
        /// <param name="enumerable">The <see cref="IEnumerable"/> to check for emptiness</param>
        /// <returns>true if the source sequence contains any elements, otherwise false</returns>
        /// <exception cref="ArgumentNullException"/>
        public static bool Any(this IEnumerable enumerable)
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            var e = enumerable.GetEnumerator();
            e.Reset();
            return e.MoveNext();
        }

        /// <summary>
        /// Enumerates an <see cref="IEnumerable{T}"/> sequence while catching exception for retrieving each item
        /// </summary>
        /// <typeparam name="T">The type of items in the collection</typeparam>
        /// <param name="sequence">The sequence to enumerate</param>
        /// <param name="handler">The exception handler, returning a value indicating if the enumeration should continue</param>
        /// <returns>The new enumeration</returns>
        public static IEnumerable<T> TryForEach<T>(this IEnumerable<T> sequence, Func<Exception, bool> handler)
        {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));

            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            // Get the enumerator
            using (var enumerator = sequence.GetEnumerator())
            {
                // Loop until we don't retrieve a new item
                bool retrievedItem = true;
                while (retrievedItem)
                {
                    try
                    {
                        // Attempt to get the next item
                        retrievedItem = enumerator.MoveNext();
                    }
                    catch (Exception ex)
                    {
                        ex.HandleExpected("Try for each enumeration exception");

                        // Catch any exceptions and send it to out handler
                        if (!handler(ex))
                            yield break;

                        continue;
                    }

                    // Return the item if it was retrieved
                    if (retrievedItem)
                        yield return enumerator.Current;
                }
            }
        }

        /// <summary>
        /// Disposes all items in the collection
        /// </summary>
        /// <param name="disposables">The collection of disposable items</param>
        public static void DisposeAll(this IEnumerable<IDisposable> disposables)
        {
            disposables?.ForEach(x => x?.Dispose());
        }
    }
}