namespace RayCarrot.Common
{
    /// <summary>
    /// Event handler for when the status of an operation is updated
    /// </summary>
    /// <param name="sender">The sender</param>
    /// <param name="e">The event arguments</param>
    public delegate void StatusUpdateEventHandler(object sender, OperationProgressEventArgs e);
}