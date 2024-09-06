using System;

namespace FacioRatio.CSharpRailway
{
    /// <summary>
    /// Represents an exception that is thrown when a collection is not empty.
    /// </summary>
    public class NotEmptyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotEmptyException"/> class.
        /// </summary>
        public NotEmptyException(string typeName)
            : base($"{typeName} collection is not empty.")
        {
        }
    }
}
