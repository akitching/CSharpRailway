using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultBindTExtensions
    {
        /// <summary>
        /// Transform a Result to another Result type.
        /// </summary>
        /// <param name="t">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Result<U> Bind<T, U>(this Result<T> t, Func<T, Result<U>> func)
        {
            if (t.IsFailure)
                return Result.Fail<U>(t.Error);

            return func(t.Value);
        }

        /// <summary>
        /// Transform a Result to another Result type.
        /// </summary>
        /// <param name="t">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<U>> Bind<T, U>(this Result<T> t, Func<T, Task<Result<U>>> func)
        {
            if (t.IsFailure)
                return Task.FromResult(Result.Fail<U>(t.Error));

            return func(t.Value);
        }

        /// <summary>
        /// Transform a Result to another Result type.
        /// </summary>
        /// <param name="t">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Result<U> Bind<T, U>(this Result<T> t, Func<T, U> func)
        {
            if (t.IsFailure)
                return Result.Fail<U>(t.Error);

            return Result.Ok(func(t.Value));
        }

        /// <summary>
        /// Transform a Result to another Result type.
        /// </summary>
        /// <param name="t">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static async Task<Result<U>> Bind<T, U>(this Result<T> t, Func<T, Task<U>> func)
        {
            if (t.IsFailure)
                return Result.Fail<U>(t.Error);

            return Result.Ok(await func(t.Value));
        }
    }
}
