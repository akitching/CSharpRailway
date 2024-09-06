﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultAnyTaskTExtensions
    {
        /// <summary>
        /// Verify a list Result is not empty.
        /// </summary>
        /// <param name="t">The list Result to verify.</param>
        /// <returns>
        /// A successful Result with the same value if the list is not empty,
        /// otherwise a failed Result with a NotFoundException.
        /// </returns>
        public static async Task<Result<IEnumerable<T>>> Any<T>(this Task<Result<IEnumerable<T>>> tTask)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<IEnumerable<T>>(t.Error);

            if (!t.Value.Any())
                return Result.Fail<IEnumerable<T>>(new NotFoundException(typeof(T).Name));

            return t;
        }

        /// <summary>
        /// Verify a list Result is not empty.
        /// </summary>
        /// <param name="t">The list Result to verify.</param>
        /// <returns>
        /// A successful Result with the same value if the list is not empty,
        /// otherwise a failed Result with a NotFoundException.
        /// </returns>
        public static async Task<Result<List<T>>> Any<T>(this Task<Result<List<T>>> tTask)
        {
            var t = await tTask;
            if (t.IsFailure)
                return Result.Fail<List<T>>(t.Error);

            if (t.Value.Count == 0)
                return Result.Fail<List<T>>(new NotFoundException(typeof(T).Name));

            return t;
        }
    }
}
