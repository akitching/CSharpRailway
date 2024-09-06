using System.Collections.Generic;
using System.Linq;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultNotAnyTExtensions
    {
        /// <summary>
        /// Verify a list Result is empty.
        /// </summary>
        /// <param name="t">The list Result to verify.</param>
        /// <returns>
        /// A successful Result if the list is empty,
        /// otherwise a failed Result with a NotEmptyException.
        /// </returns>
        public static Result<Empty> NotAny<T>(this Result<IEnumerable<T>> t)
        {
            if (t.IsFailure)
                return Result.Fail<Empty>(t.Error);

            if (t.Value.Any())
                return Result.Fail<Empty>(new NotEmptyException(typeof(T).Name));

            return Result.Ok();
        }

        /// <summary>
        /// Verify a list Result is empty.
        /// </summary>
        /// <param name="t">The list Result to verify.</param>
        /// <returns>
        /// A successful Result if the list is empty,
        /// otherwise a failed Result with a NotEmptyException.
        /// </returns>
        public static Result<Empty> NotAny<T>(this Result<List<T>> t)
        {
            if (t.IsFailure)
                return Result.Fail<Empty>(t.Error);

            if (t.Value.Count > 0)
                return Result.Fail<Empty>(new NotEmptyException(typeof(T).Name));

            return Result.Ok();
        }
    }
}
