using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultTrueTaskTExtensions
    {
        /// <summary>
        /// Verify a condition is true with a condition failure message.
        /// </summary>
        /// <param name="tTask">The Result to verify.</param>
        /// <param name="func">The condition function.</param>
        /// <param name="conditionMsg">The message to use if the condition is false.</param>
        /// <returns>
        /// The original Result if the condition is true, otherwise a failed Result.
        /// </returns>
        public static async Task<Result<T>> True<T>(this Task<Result<T>> tTask, Func<T, Result<bool>> func, string conditionMsg = null)
        {
            return (await tTask).True(func, conditionMsg);
        }

        /// <summary>
        /// Verify a condition is true with a condition failure message.
        /// </summary>
        /// <param name="tTask">The Result to verify.</param>
        /// <param name="func">The condition function.</param>
        /// <param name="conditionMsg">The message to use if the condition is false.</param>
        /// <returns>
        /// The original Result if the condition is true, otherwise a failed Result.
        /// </returns>
        public static async Task<Result<T>> True<T>(this Task<Result<T>> tTask, Func<T, Task<Result<bool>>> func, string conditionMsg = null)
        {
            return await (await tTask).True(func, conditionMsg);
        }

        /// <summary>
        /// Verify a condition is true with a condition failure message.
        /// </summary>
        /// <param name="tTask">The Result to verify.</param>
        /// <param name="func">The condition function.</param>
        /// <param name="conditionMsg">The message to use if the condition is false.</param>
        /// <returns>
        /// The original Result if the condition is true, otherwise a failed Result.
        /// </returns>
        public static async Task<Result<T>> True<T>(this Task<Result<T>> tTask, Func<T, bool> func, string conditionMsg = null)
        {
            return (await tTask).True(func, conditionMsg);
        }

        /// <summary>
        /// Verify a condition is true with a condition failure message.
        /// </summary>
        /// <param name="tTask">The Result to verify.</param>
        /// <param name="func">The condition function.</param>
        /// <param name="conditionMsg">The message to use if the condition is false.</param>
        /// <returns>
        /// The original Result if the condition is true, otherwise a failed Result.
        /// </returns>
        public static async Task<Result<T>> True<T>(this Task<Result<T>> tTask, Func<T, Task<bool>> func, string conditionMsg = null)
        {
            return await (await tTask).True(func, conditionMsg);
        }
    }
}
