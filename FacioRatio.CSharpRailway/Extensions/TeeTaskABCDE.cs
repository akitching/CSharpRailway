﻿using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultTeeTaskABCDEExtensions
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
        public static async Task<Result<(A, B, C, D, E)>> Tee<A, B, C, D, E>(this Task<Result<(A, B, C, D, E)>> tTask, Action<A, B, C, D, E> func)
        {
            var t = await tTask;
            if (t.IsSuccess)
            {
                (A a, B b, C c, D d, E e) = t.Value;
                func(a, b, c, d, e);
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
        public static async Task<Result<(A, B, C, D, E)>> Tee<A, B, C, D, E>(this Task<Result<(A, B, C, D, E)>> tTask, Func<A, B, C, D, E, Task> func)
        {
            var t = await tTask;
            if (t.IsSuccess)
            {
                (A a, B b, C c, D d, E e) = t.Value;
                await func(a, b, c, d, e);
            }
            return t;
        }
    }
}
