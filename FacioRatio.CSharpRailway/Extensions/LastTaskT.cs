﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultLastTaskTExtensions
    {
        /// <summary>
        /// Retrieve the last item in a list Result.
        /// </summary>
        /// <param name="tTask">The list Result to retrieve the last item from.</param>
        /// <returns>
        /// A Result with the first ist tem in the list if the list is not empty,
        /// otherwise a failed Result with a NotFoundException.
        /// </returns>
        public static async Task<Result<T>> Last<T>(this Task<Result<IEnumerable<T>>> tTask)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            try
            {
                var value = t.Value.Last();
                return Result.Ok(value);
            }
            catch (InvalidOperationException)
            {
                return Result.Fail<T>(new NotFoundException(typeof(T).Name));
            }
        }

        /// <summary>
        /// Retrieve the last item in a list Result.
        /// </summary>
        /// <param name="tTask">The list Result to retrieve the last item from.</param>
        /// <returns>
        /// A Result with the first ist tem in the list if the list is not empty,
        /// otherwise a failed Result with a NotFoundException.
        /// </returns>
        public static async Task<Result<T>> Last<T>(this Task<Result<List<T>>> tTask)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<T>(t.Error);

            if (t.Value.Count == 0)
                return Result.Fail<T>(new NotFoundException(typeof(T).Name));

            return Result.Ok(t.Value[^1]);
        }
    }
}
