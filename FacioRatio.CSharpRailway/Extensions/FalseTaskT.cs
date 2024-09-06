using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultFalseTaskTExtensions
    {
        /// <summary>
        /// Verify a condition is false with a condition failure message.
        /// </summary>
        /// <param name="tTask">The Result to check.</param>
        /// <param name="func">The condition function.</param>
        /// <param name="conditionMsg">The condition failure message.</param>
        /// <returns>
        /// A Result with the original value if the condition is false, otherwise a Result with a condition failure message.
        /// </returns>
        public static async Task<Result<T>> False<T>(this Task<Result<T>> tTask, Func<T, Result<bool>> func, string conditionMsg = null)
        {
            return (await tTask).False(func, conditionMsg);
        }

        /// <summary>
        /// Verify a condition is false with a condition failure message.
        /// </summary>
        /// <param name="tTask">The Result to check.</param>
        /// <param name="func">The condition function.</param>
        /// <param name="conditionMsg">The condition failure message.</param>
        /// <returns>
        /// A Result with the original value if the condition is false, otherwise a Result with a condition failure message.
        public static async Task<Result<T>> False<T>(this Task<Result<T>> tTask, Func<T, Task<Result<bool>>> func, string conditionMsg = null)
        {
            return await (await tTask).False(func, conditionMsg);
        }

        /// <summary>
        /// Verify a condition is false with a condition failure message.
        /// </summary>
        /// <param name="tTask">The Result to check.</param>
        /// <param name="func">The condition function.</param>
        /// <param name="conditionMsg">The condition failure message.</param>
        /// <returns>
        /// A Result with the original value if the condition is false, otherwise a Result with a condition failure message.
        public static async Task<Result<T>> False<T>(this Task<Result<T>> tTask, Func<T, bool> func, string conditionMsg = null)
        {
            return (await tTask).False(func, conditionMsg);
        }

        /// <summary>
        /// Verify a condition is false with a condition failure message.
        /// </summary>
        /// <param name="tTask">The Result to check.</param>
        /// <param name="func">The condition function.</param>
        /// <param name="conditionMsg">The condition failure message.</param>
        /// <returns>
        /// A Result with the original value if the condition is false, otherwise a Result with a condition failure message.
        public static async Task<Result<T>> False<T>(this Task<Result<T>> tTask, Func<T, Task<bool>> func, string conditionMsg = null)
        {
            return await (await tTask).False(func, conditionMsg);
        }
    }
}
