using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultBindTupleABCDExtensions
    {
        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="t">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Result<(A, B, C, D, U)> BindTuple<A, B, C, D, U>(this Result<(A, B, C, D)> t, Func<A, B, C, D, Result<U>> func)
        {
            return t.Bind(y => { (A a, B b, C c, D d) = y; return func(a, b, c, d).Bind(u => (a, b, c, d, u)); });
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="t">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Result<(A, B, C, D, U)> BindTuple<A, B, C, D, U>(this Result<(A, B, C, D)> t, Func<A, B, C, D, U> func)
        {
            return t.Bind(y => { (A a, B b, C c, D d) = y; return (a, b, c, d, func(a, b, c, d)); });
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="t">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B, C, D, U)>> BindTuple<A, B, C, D, U>(this Result<(A, B, C, D)> t, Func<A, B, C, D, Task<Result<U>>> func)
        {
            return t.Bind(y => { (A a, B b, C c, D d) = y; return func(a, b, c, d).Bind(u => (a, b, c, d, u)); });
        }

        /// <summary>
        /// Bind and return a Tuple with the original value.
        /// </summary>
        /// <param name="t">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static Task<Result<(A, B, C, D, U)>> BindTuple<A, B, C, D, U>(this Result<(A, B, C, D)> t, Func<A, B, C, D, Task<U>> func)
        {
            return t.Bind(async y => { (A a, B b, C c, D d) = y; var u = await func(a, b, c, d); return (a, b, c, d, u); });
        }
    }
}
