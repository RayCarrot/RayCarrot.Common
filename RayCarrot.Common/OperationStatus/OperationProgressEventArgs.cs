using System;

namespace RayCarrot.Common
{
    /// <summary>
    /// Event arguments for events during an operation
    /// </summary>
    public class OperationProgressEventArgs : EventArgs
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="progress">The current progress of the operation</param>
        /// <param name="state">The state of the operation</param>
        public OperationProgressEventArgs(ItemsOperationProgress progress, OperationState state)
        {
            Progress = progress;
            State = state;
        }

        /// <summary>
        /// The current progress of the operation
        /// </summary>
        public ItemsOperationProgress Progress { get; }

        /// <summary>
        /// The state of the operation
        /// </summary>
        public OperationState State { get; }
    }
}