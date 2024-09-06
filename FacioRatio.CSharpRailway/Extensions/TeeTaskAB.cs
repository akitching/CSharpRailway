using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultTeeTaskABExtensions
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
        public static async Task<Result<(A, B)>> Tee<A, B>(this Task<Result<(A, B)>> tTask, Action<A, B> func)
        {
            var t = await tTask;
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
        /// <param name="tTask">The Result to act on.</param>
        /// <param name="func">The action to take.</param>
        /// <returns>
        /// The original Result.
        /// </returns>
        public static async Task<Result<(A, B)>> Tee<A, B>(this Task<Result<(A, B)>> tTask, Func<A, B, Task> func)
        {
            var t = await tTask;
            if (t.IsSuccess)
            {
                (A a, B b) = t.Value;
                await func(a, b);
            }
            return t;
        }
    }
}
