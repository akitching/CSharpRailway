﻿using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultCombineEmptyExtensions
    {
        /// <summary>
        ///	Combine two Results into an aggregate Result.
        /// </summary>
        /// <param name="t">The first Result to combine.</param>
        /// <param name="u">The seccond Result to combine.</param>
        /// <param name="aggregateFailure">The aggregation function to merge the <see cref="Empty"/> results.</param>
        /// <returns>A Result with the combined value. </returns>
        public static Result<Empty> Combine(this Result<Empty> t, Result<Empty> u, Func<Exception, Exception, Exception> aggregateFailure)
        {
            return t.Combine(u, (u, v) => new Empty(), aggregateFailure);
        }

        /// <summary>
        ///	Combine two Results into an aggregate Result.
        /// </summary>
        /// <param name="t">The first Result to combine.</param>
        /// <param name="u">The seccond Result to combine.</param>
        /// <param name="aggregateFailure">The aggregation function to merge the <see cref="Empty"/> results.</param>
        /// <returns>A Result with the combined value. </returns>
        public static Result<Empty> Combine(this Result<Empty> t, Result<Empty> u)
        {
            return t.Combine(u, (te, ue) => new AggregateException(te, ue));
        }

        /// <summary>
        ///	Combine two Results into an aggregate Result.
        /// </summary>
        /// <param name="t">The first Result to combine.</param>
        /// <param name="uTask">The seccond Result to combine.</param>
        /// <param name="aggregateFailure">The aggregation function to merge the <see cref="Empty"/> results.</param>
        /// <returns>A Result with the combined value. </returns>
        public static async Task<Result<Empty>> Combine(this Result<Empty> t, Task<Result<Empty>> uTask, Func<Exception, Exception, Exception> aggregateFailure)
        {
            var u = await uTask;
            return t.Combine(u, aggregateFailure);
        }

        /// <summary>
        ///	Combine two Results into an aggregate Result.
        /// </summary>
        /// <param name="t">The first Result to combine.</param>
        /// <param name="uTask">The seccond Result to combine.</param>
        /// <returns>A Result containingg an <see cref="AggregateException"/>.</returns>
        public static Task<Result<Empty>> Combine(this Result<Empty> t, Task<Result<Empty>> uTask)
        {
            return t.Combine(uTask, (te, ue) => new AggregateException(te, ue));
        }
    }
}
