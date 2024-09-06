using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultBindTupleTaskABCExtensions
    {
        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B, C, D)>> BindTuple<A, B, C, D>(this Task<Result<(A, B, C)>> tTask, Func<A, B, C, Result<D>> func)
        {
            return tTask.Bind(y => { (A a, B b, C c) = y; return func(a, b, c).Bind(d => (a, b, c, d)); });
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B, C, D)>> BindTuple<A, B, C, D>(this Task<Result<(A, B, C)>> tTask, Func<A, B, C, D> func)
        {
            return tTask.Bind(y => { (A a, B b, C c) = y; return (a, b, c, func(a, b, c)); });
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B, C, D)>> BindTuple<A, B, C, D>(this Task<Result<(A, B, C)>> tTask, Func<A, B, C, Task<Result<D>>> func)
        {
            return tTask.Bind(y => { (A a, B b, C c) = y; return func(a, b, c).Bind(d => (a, b, c, d)); });
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B, C, D)>> BindTuple<A, B, C, D>(this Task<Result<(A, B, C)>> tTask, Func<A, B, C, Task<D>> func)
        {
            return tTask.Bind(async y => { (A a, B b, C c) = y; return (a, b, c, await func(a, b, c)); });
        }
    }
}
