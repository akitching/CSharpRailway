using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultBindTaskABCsExtensions
    {
        /// <summary>
        /// Transform a Result to another Result type.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static async Task<Result<U>> Bind<A, B, C, U>(this Task<Result<(A, B, C)>> tTask, Func<A, B, C, Result<U>> func)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<U>(t.Error);

            var result = func(t.Value.Item1, t.Value.Item2, t.Value.Item3);
            return result;
        }

        /// <summary>
        /// Transform a Result to another Result type.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static async Task<Result<U>> Bind<A, B, C, U>(this Task<Result<(A, B, C)>> tTask, Func<A, B, C, Task<Result<U>>> func)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<U>(t.Error);

            var result = await func(t.Value.Item1, t.Value.Item2, t.Value.Item3);
            return result;
        }
    }
}
