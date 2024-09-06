using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultBindTupleAExtensions
    {
        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="t">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Result<(A, B)> BindTuple<A, B>(this Result<A> t, Func<A, Result<B>> func)
        {
            return t.Bind(a => func(a).Bind(b => (a, b)));
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="t">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Result<(A, B)> BindTuple<A, B>(this Result<A> t, Func<A, B> func)
        {
            return t.Bind(a => (a, func(a)));
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="t">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B)>> BindTuple<A, B>(this Result<A> t, Func<A, Task<Result<B>>> func)
        {
            return t.Bind(a => func(a).Bind(b => (a, b)));
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="t">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B)>> BindTuple<A, B>(this Result<A> t, Func<A, Task<B>> func)
        {
            return t.Bind(async a => (a, await func(a)));
        }
    }
}
