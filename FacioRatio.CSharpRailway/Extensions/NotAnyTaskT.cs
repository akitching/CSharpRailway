using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultNotAnyTaskTExtensions
    {
        /// <summary>
        /// Verify a list Result is empty.
        /// </summary>
        /// <param name="tTask">The list Result to verify.</param>
        /// <returns>
        /// A successful Result if the list is empty,
        /// otherwise a failed Result with a NotEmptyException.
        /// </returns>
        public static async Task<Result<Empty>> NotAny<T>(this Task<Result<IEnumerable<T>>> tTask)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<Empty>(t.Error);

            if (t.Value.Any())
                return Result.Fail<Empty>(new NotEmptyException(typeof(T).Name));

            return Result.Ok();
        }

        /// <summary>
        /// Verify a list Result is empty.
        /// </summary>
        /// <param name="tTask">The list Result to verify.</param>
        /// <returns>
        /// A successful Result if the list is empty,
        /// otherwise a failed Result with a NotEmptyException.
        /// </returns>
        public static async Task<Result<Empty>> NotAny<T>(this Task<Result<List<T>>> tTask)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<Empty>(t.Error);

            if (t.Value.Count > 0)
                return Result.Fail<Empty>(new NotEmptyException(typeof(T).Name));

            return Result.Ok();
        }
    }
}
