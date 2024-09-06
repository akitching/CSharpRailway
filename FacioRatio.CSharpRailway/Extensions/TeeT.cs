using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultTeeTExtensions
    {
        /// <summary>
        /// Act on a Result and preserve the original Result.
        /// <para>This is useful for logging or side effects.</para>
        /// </summary>
        /// <param name="t">The Result to act on.</param>
        /// <param name="func">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static Result<T> Tee<T>(this Result<T> t, Action<T> func)
        {
            if (t.IsSuccess)
                func(t.Value);

            return t;
        }

        /// <summary>
        /// Act on a Result and preserve the original Result.
        /// <para>This is useful for logging or side effects.</para>
        /// </summary>
        /// <param name="t">The Result to act on.</param>
        /// <param name="func">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static Task<Result<T>> Tee<T>(this Result<T> t, Func<T, Task> func)
        {
            if (t.IsSuccess)
                func(t.Value);

            return Task.FromResult(t);
        }

        /// <summary>
        /// Act on a Result and preserve the original Result.
        /// <para>This is useful for logging or side effects.</para>
        /// </summary>
        /// <param name="t">The Result to act on.</param>
        /// <param name="func">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static Result<T> Tee<T>(this Result<T> t, Func<T, Result<Empty>> func)
        {
            if (t.IsSuccess)
                return func(t.Value).Bind(_ => t);

            return t;
        }

        /// <summary>
        /// Act on a Result and preserve the original Result.
        /// <para>This is useful for logging or side effects.</para>
        /// </summary>
        /// <param name="t">The Result to act on.</param>
        /// <param name="func">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static Task<Result<T>> Tee<T>(this Result<T> t, Func<T, Task<Result<Empty>>> func)
        {
            if (t.IsSuccess)
                return func(t.Value).Bind(_ => t);

            return Task.FromResult(t);
        }
    }
}
