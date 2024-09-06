using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultBindTupleABExtensions
    {
        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="t">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Result<(A, B, C)> BindTuple<A, B, C>(this Result<(A, B)> t, Func<A, B, Result<C>> func)
        {
            return t.Bind(y => { (A a, B b) = y; return func(a, b).Bind(c => (a, b, c)); });
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="t">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Result<(A, B, C)> BindTuple<A, B, C>(this Result<(A, B)> t, Func<A, B, C> func)
        {
            return t.Bind(y => { (A a, B b) = y; return (a, b, func(a, b)); });
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="t">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B, C)>> BindTuple<A, B, C>(this Result<(A, B)> t, Func<A, B, Task<Result<C>>> func)
        {
            return t.Bind(y => { (A a, B b) = y; return func(a, b).Bind(c => (a, b, c)); });
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="t">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B, C)>> BindTuple<A, B, C>(this Result<(A, B)> t, Func<A, B, Task<C>> func)
        {
            return t.Bind(async y => { (A a, B b) = y; var c = await func(a, b); return (a, b, c); });
        }
    }
}
