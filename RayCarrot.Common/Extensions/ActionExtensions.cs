﻿using RayCarrot.Logging;
using System;

namespace RayCarrot.Common
{
    /// <summary>
    /// Extension methods for an <see cref="Action"/>
    /// </summary>
    public static class ActionExtensions
    {
        /// <summary>
        /// Tries running a method and requests to retry if an exception is thrown
        /// </summary>
        /// <param name="action">The method to run</param>
        /// <param name="retryFunction">The method to determine if it should try again in case of exception</param>
        /// <exception cref="ArgumentNullException"/>
        public static void RetryIfException(this Action action, Func<Exception, bool> retryFunction)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (retryFunction == null)
                throw new ArgumentNullException(nameof(retryFunction));

            bool retry = true;

            while (retry)
            {
                retry = false;
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    ex.HandleExpected();
                    if (retryFunction(ex))
                        retry = true;
                }
            }
        }

        /// <summary>
        /// Tries running a method and catches and handles a potential exception without throwing it
        /// </summary>
        /// <param name="action">The method to run</param>
        /// <exception cref="ArgumentNullException"/>
        public static void IgnoreIfException(this Action action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            try
            {
                action();
            }
            catch (Exception ex)
            {
                ex.HandleExpected();
            }
        }
    }
}