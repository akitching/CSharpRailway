using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultFalseTExtensions
    {
        /// <summary>
        /// Verify a condition is false with a condition failure message.
        /// </summary>
        /// <param name="t">The Result to check.</param>
        /// <param name="func">The condition function.</param>
        /// <param name="conditionMsg">The condition failure message.</param>
        /// <returns>
        /// A Result with the original value if the condition is false, otherwise a Result with a condition failure message.
        /// </returns>
        public static Result<T> False<T>(this Result<T> t, Func<T, Result<bool>> func, string conditionMsg = null)
        {
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            return func(t.Value)
                .Bind(yes => !yes ? t : Result.Fail<T>(new ArgumentException(conditionMsg ?? "Condition not met.", nameof(T))));
        }

        /// <summary>
        /// Verify a condition is false with a condition failure message.
        /// </summary>
        /// <param name="t">The Result to check.</param>
        /// <param name="func">The condition function.</param>
        /// <param name="conditionMsg">The condition failure message.</param>
        /// <returns>
        /// A Result with the original value if the condition is false, otherwise a Result with a condition failure message.
        /// </returns>
        public static Task<Result<T>> False<T>(this Result<T> t, Func<T, Task<Result<bool>>> func, string conditionMsg = null)
        {
            if (t.IsFailure)
                return Result.FailTask<T>(t.Error);

            return func(t.Value)
                .Bind(yes => !yes ? t : Result.Fail<T>(new ArgumentException(conditionMsg ?? "Condition not met.", nameof(T))));
        }

        /// <summary>
        /// Verify a condition is false with a condition failure message.
        /// </summary>
        /// <param name="t">The Result to check.</param>
        /// <param name="func">The condition function.</param>
        /// <param name="conditionMsg">The condition failure message.</param>
        /// <returns>
        /// A Result with the original value if the condition is false, otherwise a Result with a condition failure message.
        /// </returns>
        public static Result<T> False<T>(this Result<T> t, Func<T, bool> func, string conditionMsg = null)
        {
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            return !func(t.Value) ? t : Result.Fail<T>(new ArgumentException(conditionMsg ?? "Condition not met.", nameof(T)));
        }

        /// <summary>
        /// Verify a condition is false with a condition failure message.
        /// </summary>
        /// <param name="t">The Result to check.</param>
        /// <param name="func">The condition function.</param>
        /// <param name="conditionMsg">The condition failure message.</param>
        /// <returns>
        /// A Result with the original value if the condition is false, otherwise a Result with a condition failure message.
        /// </returns>
        public static async Task<Result<T>> False<T>(this Result<T> t, Func<T, Task<bool>> func, string conditionMsg = null)
        {
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            return !(await func(t.Value)) ? t : Result.Fail<T>(new ArgumentException(conditionMsg ?? "Condition not met.", nameof(T)));
        }
    }
}
