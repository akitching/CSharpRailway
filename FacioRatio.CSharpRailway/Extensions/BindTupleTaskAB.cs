using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultBindTupleTaskABExtensions
    {
        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B, C)>> BindTuple<A, B, C>(this Task<Result<(A, B)>> tTask, Func<A, B, Result<C>> func)
        {
            return tTask.Bind(y => { (A a, B b) = y; return func(a, b).Bind(c => (a, b, c)); });
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B, C)>> BindTuple<A, B, C>(this Task<Result<(A, B)>> tTask, Func<A, B, C> func)
        {
            return tTask.Bind(y => { (A a, B b) = y; return (a, b, func(a, b)); });
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B, C)>> BindTuple<A, B, C>(this Task<Result<(A, B)>> tTask, Func<A, B, Task<Result<C>>> func)
        {
            return tTask.Bind(y => { (A a, B b) = y; return func(a, b).Bind(c => (a, b, c)); });
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B, C)>> BindTuple<A, B, C>(this Task<Result<(A, B)>> tTask, Func<A, B, Task<C>> func)
        {
            return tTask.Bind(async y => { (A a, B b) = y; return (a, b, await func(a, b)); });
        }
    }
}
