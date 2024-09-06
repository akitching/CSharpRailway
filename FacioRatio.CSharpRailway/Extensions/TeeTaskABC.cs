using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultTeeTaskABCExtensions
    {
        /// <summary>
        /// Act on a Result and preserve the original Result.
        /// <para>This is useful for logging or side effects.</para>
        /// </summary>
        /// <param name="tTask">The Result to act on.</param>
        /// <param name="func">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static async Task<Result<(A, B, C)>> Tee<A, B, C>(this Task<Result<(A, B, C)>> tTask, Action<A, B, C> func)
        {
            var t = await tTask;
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
        /// <param name="tTask">The Result to act on.</param>
        /// <param name="func">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static async Task<Result<(A, B, C)>> Tee<A, B, C>(this Task<Result<(A, B, C)>> tTask, Func<A, B, C, Task> func)
        {
            var t = await tTask;
            if (t.IsSuccess)
            {
                (A a, B b, C c) = t.Value;
                await func(a, b, c);
            }
            return t;
        }
    }
}
