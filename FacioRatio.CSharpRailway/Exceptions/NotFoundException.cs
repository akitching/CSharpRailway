using System;

namespace FacioRatio.CSharpRailway
{
    /// <summary>
    /// Represents an exception that is thrown when a collection is empty.
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        public NotFoundException(string typeName)
            : base($"{typeName} collection is empty.")
        {
        }
    }
}
