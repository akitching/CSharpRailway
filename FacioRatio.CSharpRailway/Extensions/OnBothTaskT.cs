using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultOnBothTaskTExtensions
    {
        /// <summary>
        /// Act on both success and failure Results and preserve the original Result.
        /// <para>This is useful for logging or side effects.</para>
        /// </summary>
        /// <param name="tTask">The Result to act on.</param>
        /// <param name="action">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static async Task<Result<T>> OnBoth<T>(this Task<Result<T>> tTask, Action<Result<T>> action)
        {
            var t = await tTask;
            action(t);
            return t;
        }

        /// <summary>
        /// Act on both success and failure Results and preserve the original Result.
        /// <para>This is useful for logging or side effects.</para>
        /// </summary>
        /// <param name="tTask">The Result to act on.</param>
        /// <param name="action">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static async Task<Result<T>> OnBoth<T>(this Task<Result<T>> tTask, Action<Task<Result<T>>> action)
        {
            var t = await tTask;
            action(Task.FromResult(t));
            return t;
        }

        /// <summary>
        /// Act on both success and failure Results and preserve the original Result.
        /// <para>This is useful for logging or side effects.</para>
        /// </summary>
        /// <param name="tTask">The Result to act on.</param>
        /// <param name="action">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static async Task<Result<T>> OnBoth<T>(this Task<Result<T>> tTask, Func<Result<T>, Task> action)
        {
            var t = await tTask;
            await action(t);
            return t;
        }

        /// <summary>
        /// Act on both success and failure Results and preserve the original Result.
        /// <para>This is useful for logging or side effects.</para>
        /// </summary>
        /// <param name="tTask">The Result to act on.</param>
        /// <param name="action">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static async Task<Result<T>> OnBoth<T>(this Task<Result<T>> tTask, Func<Task<Result<T>>, Task> action)
        {
            var t = await tTask;
            await action(Task.FromResult(t));
            return t;
        }
    }
}
