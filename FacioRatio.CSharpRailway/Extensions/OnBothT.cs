using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultOnBothExtensions
    {
        /// <summary>
        /// Act on both success and failure Results and preserve the original Result.
        /// <para>This is useful for logging or side effects.</para>
        /// </summary>
        /// <param name="t">The Result to act on.</param>
        /// <param name="action">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static Result<T> OnBoth<T>(this Result<T> t, Action<Result<T>> action)
        {
            action(t);
            return t;
        }

        /// <summary>
        /// Act on both success and failure Results and preserve the original Result.
        /// <para>This is useful for logging or side effects.</para>
        /// </summary>
        /// <param name="t">The Result to act on.</param>
        /// <param name="action">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static Result<T> OnBoth<T>(this Result<T> t, Action<Task<Result<T>>> action)
        {
            action(Task.FromResult(t));
            return t;
        }

        /// <summary>
        /// Act on both success and failure Results and preserve the original Result.
        /// <para>This is useful for logging or side effects.</para>
        /// </summary>
        /// <param name="t">The Result to act on.</param>
        /// <param name="action">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static Result<T> OnBoth<T>(this Result<T> t, Func<Result<T>, Task> action)
        {
            action(t);
            return t;
        }

        /// <summary>
        /// Act on both success and failure Results and preserve the original Result.
        /// <para>This is useful for logging or side effects.</para>
        /// </summary>
        /// <param name="t">The Result to act on.</param>
        /// <param name="action">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static Result<T> OnBoth<T>(this Result<T> t, Func<Task<Result<T>>, Task> action)
        {
            action(Task.FromResult(t));
            return t;
        }
    }
}
