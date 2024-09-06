using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultTrueTExtensions
    {
        /// <summary>
        /// Verify a condition is true with a condition failure message.
        /// </summary>
        /// <param name="t">The Result to verify.</param>
        /// <param name="func">The condition function.</param>
        /// <param name="conditionMsg">The message to use if the condition is false.</param>
        /// <returns>
        /// The original Result if the condition is true, otherwise a failed Result.
        /// </returns>
        public static Result<T> True<T>(this Result<T> t, Func<T, Result<bool>> func, string conditionMsg = null)
        {
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            return func(t.Value)
                .Bind(yes => yes ? t : Result.Fail<T>(new ArgumentException(conditionMsg ?? "Condition not met.", nameof(T))));
        }

        /// <summary>
        /// Verify a condition is true with a condition failure message.
        /// </summary>
        /// <param name="t">The Result to verify.</param>
        /// <param name="func">The condition function.</param>
        /// <param name="conditionMsg">The message to use if the condition is false.</param>
        /// <returns>
        /// The original Result if the condition is true, otherwise a failed Result.
        /// </returns>
        public static Task<Result<T>> True<T>(this Result<T> t, Func<T, Task<Result<bool>>> func, string conditionMsg = null)
        {
            if (t.IsFailure)
                return Result.FailTask<T>(t.Error);

            return func(t.Value)
                .Bind(yes => yes ? t : Result.Fail<T>(new ArgumentException(conditionMsg ?? "Condition not met.", nameof(T))));
        }

        /// <summary>
        /// Verify a condition is true with a condition failure message.
        /// </summary>
        /// <param name="t">The Result to verify.</param>
        /// <param name="func">The condition function.</param>
        /// <param name="conditionMsg">The message to use if the condition is false.</param>
        /// <returns>
        /// The original Result if the condition is true, otherwise a failed Result.
        /// </returns>
        public static Result<T> True<T>(this Result<T> t, Func<T, bool> func, string conditionMsg = null)
        {
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            return func(t.Value) ? t : Result.Fail<T>(new ArgumentException(conditionMsg ?? "Condition not met.", nameof(T)));
        }

        /// <summary>
        /// Verify a condition is true with a condition failure message.
        /// </summary>
        /// <param name="t">The Result to verify.</param>
        /// <param name="func">The condition function.</param>
        /// <param name="conditionMsg">The message to use if the condition is false.</param>
        /// <returns>
        /// The original Result if the condition is true, otherwise a failed Result.
        /// </returns>
        public static async Task<Result<T>> True<T>(this Result<T> t, Func<T, Task<bool>> func, string conditionMsg = null)
        {
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            return await func(t.Value) ? t : Result.Fail<T>(new ArgumentException(conditionMsg ?? "Condition not met.", nameof(T)));
        }
    }
}
