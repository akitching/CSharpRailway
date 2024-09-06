using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultTeeABCExtensions
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
        public static Result<(A, B, C)> Tee<A, B, C>(this Result<(A, B, C)> t, Action<A, B, C> func)
        {
            if (t.IsSuccess)
            {
                (A a, B b, C c) = t.Value;
                func(a, b, c);
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
        public static async Task<Result<(A, B, C)>> Tee<A, B, C>(this Result<(A, B, C)> t, Func<A, B, C, Task> func)
        {
            if (t.IsSuccess)
            {
                (A a, B b, C c) = t.Value;
                await func(a, b, c);
            }
            return t;
        }
    }
}
