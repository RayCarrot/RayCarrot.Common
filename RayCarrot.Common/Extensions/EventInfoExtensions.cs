using System;
using System.Reflection;

namespace RayCarrot.Common
{
    /// <summary>
    /// Extension methods for <see cref="EventInfo"/>
    /// </summary>
    public static class EventInfoExtensions
    {
        /// <summary>
        /// Adds an event handler to an event source
        /// </summary>
        /// <typeparam name="T">The type of event handler</typeparam>
        /// <param name="eventInfo">The event information</param>
        /// <param name="target">The event source</param>
        /// <param name="handler">Encapsulates a method or methods to be invoked when the event is raised by the target</param>
        /// <exception cref="InvalidOperationException">The event does not have a public add accessor</exception>
        /// <exception cref="ArgumentException">The handler that was passed in cannot be used</exception>
        /// <exception cref="MethodAccessException">In the .NET for Windows Store apps or the Portable Class Library, catch the base
        /// class exception, <see cref="MemberAccessException"/>, instead. The caller does not have access permission to the member.</exception>
        /// <exception cref="TargetException">In the .NET for Windows Store apps or the Portable Class Library, catch <see cref="Exception"/>
        /// instead.The target parameter is null and the event is not static.-or- The <see cref="EventInfo"/> is not declared on the target.</exception>
        public static void AddEventHandler<T>(this EventInfo eventInfo, object target, T handler)
            where T : Delegate
        {
            eventInfo.AddEventHandler(target, handler);
        }

        /// <summary>
        /// Removes an event handler from an event source
        /// </summary>
        /// <typeparam name="T">The type of event handler</typeparam>
        /// <param name="eventInfo">The event information</param>
        /// <param name="target">The event source</param>
        /// <param name="handler">The delegate to be disassociated from the events raised by target</param>
        /// <exception cref="InvalidOperationException">The event does not have a public add accessor</exception>
        /// <exception cref="ArgumentException">The handler that was passed in cannot be used</exception>
        /// <exception cref="TargetException">In the [.NET for Windows Store apps](http://go.microsoft.com/fwlink/?LinkID=247912)
        /// or the [Portable Class Library](~/docs/standard/cross-platform/cross-platform-development-with-the-portable-class-library.md),
        /// catch <see cref="Exception"/> instead. The target parameter is null and the event is not static. -or- 
        /// The <see cref="EventInfo"/> is not declared on the target.</exception>
        /// <exception cref="MethodAccessException">In the [.NET for Windows Store apps](http://go.microsoft.com/fwlink/?LinkID=247912)
        /// or the [Portable Class Library](~/docs/standard/cross-platform/cross-platform-development-with-the-portable-class-library.md),
        /// catch the base class exception, <see cref="MemberAccessException"/>, instead. The caller does not have access permission to the member.</exception>
        public static void RemoveEventHandler<T>(this EventInfo eventInfo, object target, T handler)
            where T : Delegate
        {
            eventInfo.RemoveEventHandler(target, handler);
        }
    }
}