using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultFirstOrDefaultTaskTExtensions
    {
        /// <summary>
        /// Retrieve the first or default item in a list Result.
        /// </summary>
        /// <param name="tTask">The list Result to retrieve the first item from.</param>
        /// <returns>
        /// A Result with the first item in the list if the list is not empty,
        /// otherwise the default value for the type.
        /// </returns>
        public static async Task<Result<T>> FirstOrDefault<T>(this Task<Result<IEnumerable<T>>> tTask)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            var value = t.Value.FirstOrDefault();
            return Result.Ok(value);
        }

        /// <summary>
        /// Retrieve the first or default item in a list Result.
        /// </summary>
        /// <param name="tTask">The list Result to retrieve the first item from.</param>
        /// <returns>
        /// A Result with the first item in the list if the list is not empty,
        /// otherwise the default value for the type.
        /// </returns>
        public static async Task<Result<T>> FirstOrDefault<T>(this Task<Result<List<T>>> tTask)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            if (t.Value.Count == 0)
                return Result.Ok<T>(default);

            return Result.Ok(t.Value[0]);
        }
    }
}
