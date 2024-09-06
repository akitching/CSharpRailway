using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultBindABCExtensions
    {
        /// <summary>
        /// Transform a Result to another Result type.
        /// </summary>
        /// <param name="t">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Result<U> Bind<A, B, C, U>(this Result<(A, B, C)> t, Func<A, B, C, Result<U>> func)
        {
            if (t.IsFailure)
                return Result.Fail<U>(t.Error);

            var result = func(t.Value.Item1, t.Value.Item2, t.Value.Item3);
            return result;
        }

        /// <summary>
        /// Transform a Result to another Result type.
        /// </summary>
        /// <param name="t">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<U>> Bind<A, B, C, U>(this Result<(A, B, C)> t, Func<A, B, C, Task<Result<U>>> func)
        {
            if (t.IsFailure)
                return Task.FromResult(Result.Fail<U>(t.Error));

            var result = func(t.Value.Item1, t.Value.Item2, t.Value.Item3);
            return result;
        }
    }
}
