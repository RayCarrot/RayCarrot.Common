using System.Diagnostics;

namespace RayCarrot.Common
{
    /// <summary>
    /// Extension methods for <see cref="ProcessStartInfo"/>
    /// </summary>
    public static class ProcessStartInfoExtensions
    {
        /// <summary>
        /// Sets the required verb of the <see cref="ProcessStartInfo"/> for it to run as administrator (in elevated mode)
        /// </summary>
        /// <param name="processStartInfo">The process start info</param>
        /// <returns>The process start info</returns>
        public static ProcessStartInfo AsAdmin(this ProcessStartInfo processStartInfo)
        {
            processStartInfo.Verb = "runas";
            return processStartInfo;
        }
    }
}