using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultTeeABCDExtensions
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
        public static Result<(A, B, C, D)> Tee<A, B, C, D>(this Result<(A, B, C, D)> t, Action<A, B, C, D> func)
        {
            if (t.IsSuccess)
            {
                (A a, B b, C c, D d) = t.Value;
                func(a, b, c, d);
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
        public static async Task<Result<(A, B, C, D)>> Tee<A, B, C, D>(this Result<(A, B, C, D)> t, Func<A, B, C, D, Task> func)
        {
            if (t.IsSuccess)
            {
                (A a, B b, C c, D d) = t.Value;
                await func(a, b, c, d);
            }
            return t;
        }
    }
}
