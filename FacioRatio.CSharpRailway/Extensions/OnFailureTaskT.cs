using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultOnFailureTaskTExtensions
    {
        /// <summary>
        /// Act on a failure Result and preserve the original Result.
        /// <para>This is useful for logging or side effects.</para>
        /// </summary>
        /// <param name="tTask">The Result to act on.</param>
        /// <param name="action">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> tTask, Action<Exception> action)
        {
            var t = await tTask;
            if (t.IsFailure)
            {
                action(t.Error);
            }
            return t;
        }

        /// <summary>
        /// Act on a failure Result and preserve the original Result.
        /// <para>This is useful for logging or side effects.</para>
        /// </summary>
        /// <param name="tTask">The Result to act on.</param>
        /// <param name="action">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> tTask, Func<Exception, Task> action)
        {
            var t = await tTask;
            if (t.IsFailure)
            {
                await action(t.Error);
            }
            return t;
        }

        /// <summary>
        /// Act on a failure Result and preserve the original Result.
        /// <para>This is useful for logging or side effects.</para>
        /// </summary>
        /// <param name="tTask">The Result to act on.</param>
        /// <param name="action">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> tTask, Func<Exception, Result<Empty>> action)
        {
            var t = await tTask;
            if (t.IsFailure)
            {
                var f = action(t.Error);
                return t.Combine(f, (t, _) => t); //adds more details to the original failure
            }
            return t;
        }

        /// <summary>
        /// Act on a failure Result and preserve the original Result.
        /// <para>This is useful for logging or side effects.</para>
        /// </summary>
        /// <param name="tTask">The Result to act on.</param>
        /// <param name="action">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static async Task<Result<T>> OnFailure<T>(this Task<Result<T>> tTask, Func<Exception, Task<Result<Empty>>> action)
        {
            var t = await tTask;
            if (t.IsFailure)
            {
                var f = await action(t.Error);
                return t.Combine(f, (t, _) => t); //adds more details to the original failure
            }
            return t;
        }
    }
}
