using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultBindTupleTaskAExtensions
    {
        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B)>> BindTuple<A, B>(this Task<Result<A>> tTask, Func<A, Result<B>> func)
        {
            return tTask.Bind(a => func(a).Bind(b => (a, b)));
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B)>> BindTuple<A, B>(this Task<Result<A>> tTask, Func<A, B> func)
        {
            return tTask.Bind(a => (a, func(a)));
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B)>> BindTuple<A, B>(this Task<Result<A>> tTask, Func<A, Task<Result<B>>> func)
        {
            return tTask.Bind(a => func(a).Bind(b => (a, b)));
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B)>> BindTuple<A, B>(this Task<Result<A>> tTask, Func<A, Task<B>> func)
        {
            return tTask.Bind(async a => (a, await func(a)));
        }
    }
}
