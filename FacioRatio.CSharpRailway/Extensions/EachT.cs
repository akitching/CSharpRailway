using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultEachTExtensions
    {
        /// <summary>
        /// Act on each element in a list and return an aggregate Empty Result.
        /// </summary>
        /// <param name="list">The list to act on.</param>
        /// <param name="func">The action to perform on each element.</param>
        /// <returns>
        /// A successful Result with an Empty value.
        /// </returns>
        public static Result<Empty> Each<T>(this IEnumerable<T> list, Action<T> func)
        {
            foreach (var x in list)
            {
                func(x);
            }
            return Result.Ok();
        }

        /// <summary>
        /// Act on each element in a list and return an aggregate Empty Result.
        /// </summary>
        /// <param name="list">The list to act on.</param>
        /// <param name="func">The action to perform on each element.</param>
        /// <returns>
        /// A successful Result with an Empty value.
        /// </returns>
        public static Result<Empty> Each<T>(this IEnumerable<T> list, Func<T, Result<Empty>> func)
        {
            return list.Aggregate(Result.Ok(), (lst, el) => lst.Combine(func(el)));
        }

        /// <summary>
        /// Act on each element in a list and return an aggregate Empty Result.
        /// </summary>
        /// <param name="list">The list to act on.</param>
        /// <param name="func">The action to perform on each element.</param>
        /// <returns>
        /// A successful Result with an Empty value.
        /// </returns>
        public static async Task<Result<Empty>> Each<T>(this IEnumerable<T> list, Func<T, Task> func)
        {
            await Task.WhenAll(list.Select(x => func(x)));
            return Result.Ok();
        }

        /// <summary>
        /// Act on each element in a list and return an aggregate Empty Result.
        /// </summary>
        /// <param name="list">The list to act on.</param>
        /// <param name="func">The action to perform on each element.</param>
        /// <returns>
        /// A successful Result with an Empty value.
        /// </returns>
        public static Task<Result<Empty>> Each<T>(this IEnumerable<T> list, Func<T, Task<Result<Empty>>> func)
        {
            return list.Aggregate(Task.FromResult(Result.Ok()), (lst, el) => lst.Combine(func(el)));
        }

        /// <summary>
        /// Act on each element in a list and return an aggregate Empty Result.
        /// </summary>
        /// <param name="list">The list to act on.</param>
        /// <param name="func">The action to perform on each element.</param>
        /// <returns>
        /// A successful Result with an Empty value.
        /// </returns>
        public static Result<Empty> Each<T>(this List<T> list, Action<T> func)
        {
            foreach (var x in list)
            {
                func(x);
            }
            return Result.Ok();
        }

        /// <summary>
        /// Act on each element in a list and return an aggregate Empty Result.
        /// </summary>
        /// <param name="list">The list to act on.</param>
        /// <param name="func">The action to perform on each element.</param>
        /// <returns>
        /// A successful Result with an Empty value.
        /// </returns>
        public static Result<Empty> Each<T>(this List<T> list, Func<T, Result<Empty>> func)
        {
            return list.Aggregate(Result.Ok(), (lst, el) => lst.Combine(func(el)));
        }

        /// <summary>
        /// Act on each element in a list and return an aggregate Empty Result.
        /// </summary>
        /// <param name="list">The list to act on.</param>
        /// <param name="func">The action to perform on each element.</param>
        /// <returns>
        /// A successful Result with an Empty value.
        /// </returns>
        public static async Task<Result<Empty>> Each<T>(this List<T> list, Func<T, Task> func)
        {
            await Task.WhenAll(list.Select(x => func(x)));
            return Result.Ok();
        }

        /// <summary>
        /// Act on each element in a list and return an aggregate Empty Result.
        /// </summary>
        /// <param name="list">The list to act on.</param>
        /// <param name="func">The action to perform on each element.</param>
        /// <returns>
        /// A successful Result with an Empty value.
        /// </returns>
        public static Task<Result<Empty>> Each<T>(this List<T> list, Func<T, Task<Result<Empty>>> func)
        {
            return list.Aggregate(Task.FromResult(Result.Ok()), (lst, el) => lst.Combine(func(el)));
        }
    }
}
