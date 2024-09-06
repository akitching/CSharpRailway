using System;
using System.Collections.Generic;
using System.Linq;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultFirstTExtensions
    {
        /// <summary>
        /// Retrieve the first item in a list Result.
        /// </summary>
        /// <param name="t">The list Result to retrieve the first item from.</param>
        /// <returns>
        /// A Result with the first item in the list if the list is not empty,
        /// otherwise a failed Result with a NotFoundException.
        /// </returns>
        public static Result<T> First<T>(this Result<IEnumerable<T>> t)
        {
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            try
            {
                var value = t.Value.First();
                return Result.Ok(value);
            }
            catch (InvalidOperationException)
            {
                return Result.Fail<T>(new NotFoundException(typeof(T).Name));
            }
        }

        /// <summary>
        /// Retrieve the first item in a list Result.
        /// </summary>
        /// <param name="t">The list Result to retrieve the first item from.</param>
        /// <returns>
        /// A Result with the first item in the list if the list is not empty,
        /// otherwise a failed Result with a NotFoundException.
        /// </returns>
        public static Result<T> First<T>(this Result<List<T>> t)
        {
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            if (t.Value.Count == 0)
                return Result.Fail<T>(new NotFoundException(typeof(T).Name));

            return Result.Ok(t.Value[0]);
        }
    }
}
