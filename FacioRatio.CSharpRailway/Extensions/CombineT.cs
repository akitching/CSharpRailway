using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultCombineTExtensions
    {
        /// <summary>
        ///	Combine two Results into an aggregate Result.
        /// </summary>
        /// <param name="t">The first Result to combine.</param>
        /// <param name="u">The seccond Result to combine.</param>
        /// <param name="aggregateSuccess">The aggregation function if both <see cref="t"/> and <see cref="u"/> are successful.</param>
        /// <param name="aggregateFailure">The aggregation function if both <see creef="t"/> and <see cref="u"/> are failures. </param>
        /// <returns>A Result with the combined value. </returns>
        public static Result<V> Combine<T, U, V>(this Result<T> t, Result<U> u, Func<T, U, V> aggregateSuccess, Func<Exception, Exception, Exception> aggregateFailure)
        {
            if (t.IsFailure && u.IsFailure)
                return Result.Fail<V>(aggregateFailure(t.Error, u.Error));

            if (t.IsFailure)
                return Result.Fail<V>(t.Error);

            if (u.IsFailure)
                return Result.Fail<V>(u.Error);

            return Result.Ok(aggregateSuccess(t.Value, u.Value));
        }

        /// <summary>
        ///	Combine two Results into an aggregate Result.
        /// </summary>
        /// <param name="t">The first Result to combine.</param>
        /// <param name="uTask">The seccond Result to combine.</param>
        /// <param name="aggregateSuccess">The aggregation function if both <see cref="t"/> and <see cref="u"/> are successful.</param>
        /// <param name="aggregateFailure">The aggregation function if both <see creef="t"/> and <see cref="uTask"/> are failures. </param>
        /// <returns>A Result with the combined value. </returns>
        public static async Task<Result<V>> Combine<T, U, V>(this Result<T> t, Task<Result<U>> uTask, Func<T, U, V> aggregateSuccess, Func<Exception, Exception, Exception> aggregateFailure)
        {
            var u = await uTask;
            return t.Combine(u, aggregateSuccess, aggregateFailure);
        }

        /// <summary>
        ///	Combine two Results into an aggregate Result.
        /// </summary>
        /// <param name="t">The first Result to combine.</param>
        /// <param name="u">The seccond Result to combine.</param>
        /// <param name="aggregateSuccess">The aggregation function if both <see cref="t"/> and <see cref="u"/> are successful.</param>
        /// <returns>A Result with the combined value. </returns>
        public static Result<V> Combine<T, U, V>(this Result<T> t, Result<U> u, Func<T, U, V> aggregateSuccess)
        {
            return t.Combine(u, aggregateSuccess, (te, ue) => new AggregateException(te, ue));
        }

        /// <summary>
        ///	Combine two Results into an aggregate Result.
        /// </summary>
        /// <param name="t">The first Result to combine.</param>
        /// <param name="uTask">The seccond Result to combine.</param>
        /// <param name="aggregateSuccess">The aggregation function if both <see cref="t"/> and <see cref="uTask"/> are successful.</param>
        /// <returns>A Result with the combined value. </returns>
        public static Task<Result<V>> Combine<T, U, V>(this Result<T> t, Task<Result<U>> uTask, Func<T, U, V> aggregateSuccess)
        {
            return t.Combine(uTask, aggregateSuccess, (te, ue) => new AggregateException(te, ue));
        }
    }
}
