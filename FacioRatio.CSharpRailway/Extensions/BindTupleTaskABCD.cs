﻿using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultBindTupleTaskABCDExtensions
    {
        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B, C, D, U)>> BindTuple<A, B, C, D, U>(this Task<Result<(A, B, C, D)>> tTask, Func<A, B, C, D, Result<U>> func)
        {
            return tTask.Bind(y => { (A a, B b, C c, D d) = y; return func(a, b, c, d).Bind(u => (a, b, c, d, u)); });
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B, C, D, U)>> BindTuple<A, B, C, D, U>(this Task<Result<(A, B, C, D)>> tTask, Func<A, B, C, D, U> func)
        {
            return tTask.Bind(y => { (A a, B b, C c, D d) = y; return (a, b, c, d, func(a, b, c, d)); });
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B, C, D, U)>> BindTuple<A, B, C, D, U>(this Task<Result<(A, B, C, D)>> tTask, Func<A, B, C, D, Task<Result<U>>> func)
        {
            return tTask.Bind(y => { (A a, B b, C c, D d) = y; return func(a, b, c, d).Bind(u => (a, b, c, d, u)); });
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B, C, D, U)>> BindTuple<A, B, C, D, U>(this Task<Result<(A, B, C, D)>> tTask, Func<A, B, C, D, Task<U>> func)
        {
            return tTask.Bind(async y => { (A a, B b, C c, D d) = y; return (a, b, c, d, await func(a, b, c, d)); });
        }
    }
}
