using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultCombineTaskTExtensions
    {
        /// <summary>
        ///	Combine two Results into an aggregate Result.
        /// </summary>
        /// <param name="tTask">The first Result to combine.</param>
        /// <param name="u">The seccond Result to combine.</param>
        /// <param name="aggregateSuccess">The aggregation function if both <see cref="tTask"/> and <see cref="u"/> are successful.</param>
        /// <param name="aggregateFailure">The aggregation function to merge the <see cref="Empty"/> results.</param>
        /// <param name="aggregateFailure">The aggregation function if both <see creef="tTask"/> and <see cref="u"/> are failures. </param>
        /// <returns>A Result with the combined value. </returns>
        public static async Task<Result<V>> Combine<T, U, V>(this Task<Result<T>> tTask, Result<U> u, Func<T, U, V> aggregateSuccess, Func<Exception, Exception, Exception> aggregateFailure)
        {
            var t = await tTask;
            return t.Combine(u, aggregateSuccess, aggregateFailure);
        }

        /// <summary>
        ///	Combine two Results into an aggregate Result.
        /// </summary>
        /// <param name="tTask">The first Result to combine.</param>
        /// <param name="uTask">The seccond Result to combine.</param>
        /// <param name="aggregateSuccess">The aggregation function if both <see cref="tTask"/> and <see cref="uTask"/> are successful.</param>
        /// <param name="aggregateFailure">The aggregation function if both <see creef="tTask"/> and <see cref="uTask"/> are failures. </param>
        /// <returns>A Result with the combined value. </returns>
        public static async Task<Result<V>> Combine<T, U, V>(this Task<Result<T>> tTask, Task<Result<U>> uTask, Func<T, U, V> aggregateSuccess, Func<Exception, Exception, Exception> aggregateFailure)
        {
            var t = await tTask;
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
        public static Task<Result<V>> Combine<T, U, V>(this Task<Result<T>> t, Result<U> u, Func<T, U, V> aggregateSuccess)
        {
            return t.Combine(u, aggregateSuccess, (te, ue) => new AggregateException(te, ue));
        }

        /// <summary>
        ///	Combine two Results into an aggregate Result.
        /// </summary>
        /// <param name="tTask">The first Result to combine.</param>
        /// <param name="uTask">The seccond Result to combine.</param>
        /// <param name="aggregateSuccess">The aggregation function if both <see cref="tTask"/> and <see cref="uTask"/> are successful.</param>
        /// <returns>A Result with the combined value. </returns>
        public static Task<Result<V>> Combine<T, U, V>(this Task<Result<T>> tTask, Task<Result<U>> uTask, Func<T, U, V> aggregateSuccess)
        {
            return tTask.Combine(uTask, aggregateSuccess, (te, ue) => new AggregateException(te, ue));
        }
    }
}
