using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultTeeABExtensions
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
        public static Result<(A, B)> Tee<A, B>(this Result<(A, B)> t, Action<A, B> func)
        {
            if (t.IsSuccess)
            {
                (A a, B b) = t.Value;
                func(a, b);
            }
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
        public static async Task<Result<(A, B)>> Tee<A, B>(this Result<(A, B)> t, Func<A, B, Task> func)
        {
            if (t.IsSuccess)
            {
                (A a, B b) = t.Value;
                await func(a, b);
            }
            return t;
        }
    }
}
