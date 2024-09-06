using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultOnFailureTExtensions
    {
        /// <summary>
        /// Act on a failure Result and preserve the original Result.
        /// <para>This is useful for logging or side effects.</para>
        /// </summary>
        /// <param name="t">The Result to act on.</param>
        /// <param name="action">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static Result<T> OnFailure<T>(this Result<T> t, Action<Exception> action)
        {
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
        /// <param name="t">The Result to act on.</param>
        /// <param name="action">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static async Task<Result<T>> OnFailure<T>(this Result<T> t, Func<Exception, Task> action)
        {
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
        /// <param name="t">The Result to act on.</param>
        /// <param name="action">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static Result<T> OnFailure<T>(this Result<T> t, Func<Exception, Result<Empty>> action)
        {
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
        /// <param name="t">The Result to act on.</param>
        /// <param name="action">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static async Task<Result<T>> OnFailure<T>(this Result<T> t, Func<Exception, Task<Result<Empty>>> action)
        {
            if (t.IsFailure)
            {
                var f = await action(t.Error);
                return t.Combine(f, (t, _) => t); //adds more details to the original failure
            }
            return t;
        }
    }
}
