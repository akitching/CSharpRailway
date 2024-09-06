using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultMapTExtensions
    {
        /// <summary>
        /// Transform a list Result into a same-sized list Result of another type.
        /// </summary>
        /// <param name="tList">The list Result to transform.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A list Result of another type with the same number of elements.
        /// </returns>
        public static Result<List<U>> Map<T, U>(this Result<IEnumerable<T>> tList, Func<T, Result<U>> func)
        {
            return tList.Bind(list => list.Map(func));
        }

        /// <summary>
        /// Transform a list Result into a same-sized list Result of another type.
        /// </summary>
        /// <param name="tList">The list Result to transform.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A list Result of another type with the same number of elements.
        /// </returns>
        public static Task<Result<List<U>>> Map<T, U>(this Result<IEnumerable<T>> tList, Func<T, Task<Result<U>>> func)
        {
            return tList.Bind(list => list.Map(func));
        }

        /// <summary>
        /// Transform a list Result into a same-sized list Result of another type.
        /// </summary>
        /// <param name="tList">The list Result to transform.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A list Result of another type with the same number of elements.
        /// </returns>
        public static Result<List<U>> Map<T, U>(this Result<IEnumerable<T>> tList, Func<T, U> func)
        {
            return tList.Bind(list => list.Map(x => Result.Ok(func(x))));
        }

        /// <summary>
        /// Transform a list Result into a same-sized list Result of another type.
        /// </summary>
        /// <param name="tList">The list Result to transform.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A list Result of another type with the same number of elements.
        /// </returns>
        public static Task<Result<List<U>>> Map<T, U>(this Result<IEnumerable<T>> tList, Func<T, Task<U>> func)
        {
            return tList.Bind(list => list.Map(async x => Result.Ok(await func(x))));
        }

        /// <summary>
        /// Transform a list Result into a same-sized list Result of another type.
        /// </summary>
        /// <param name="tList">The list Result to transform.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A list Result of another type with the same number of elements.
        /// </returns>
        public static Result<List<U>> Map<T, U>(this Result<List<T>> tList, Func<T, Result<U>> func)
        {
            return tList.Bind(list => list.Map(func));
        }

        /// <summary>
        /// Transform a list Result into a same-sized list Result of another type.
        /// </summary>
        /// <param name="tList">The list Result to transform.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A list Result of another type with the same number of elements.
        /// </returns>
        public static Task<Result<List<U>>> Map<T, U>(this Result<List<T>> tList, Func<T, Task<Result<U>>> func)
        {
            return tList.Bind(list => list.Map(func));
        }

        /// <summary>
        /// Transform a list Result into a same-sized list Result of another type.
        /// </summary>
        /// <param name="tList">The list Result to transform.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A list Result of another type with the same number of elements.
        /// </returns>
        public static Result<List<U>> Map<T, U>(this Result<List<T>> tList, Func<T, U> func)
        {
            return tList.Bind(list => list.Map(x => Result.Ok(func(x))));
        }

        /// <summary>
        /// Transform a list Result into a same-sized list Result of another type.
        /// </summary>
        /// <param name="tList">The list Result to transform.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A list Result of another type with the same number of elements.
        /// </returns>
        public static Task<Result<List<U>>> Map<T, U>(this Result<List<T>> tList, Func<T, Task<U>> func)
        {
            return tList.Bind(list => list.Map(async x => Result.Ok(await func(x))));
        }

        /// <summary>
        /// Transform a list Result into a same-sized list Result of another type.
        /// </summary>
        /// <param name="list">The list Result to transform.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A list Result of another type with the same number of elements.
        /// </returns>
        public static Result<List<U>> Map<T, U>(this IEnumerable<T> list, Func<T, Result<U>> func)
        {
            var results = new List<U>();
            var fails = Result.Ok<U>(default);
            foreach (var item in list)
            {
                var result = func(item);
                if (result.IsSuccess)
                {
                    results.Add(result.Value);
                }
                else
                {
                    fails = fails.Combine(result, (_, u) => u); //aggregateSuccess has no meaning here
                }
            }
            return fails.IsFailure
                ? Result.Fail<List<U>>(fails.Error)
                : Result.Ok(results);
        }

        /// <summary>
        /// Transform a list Result into a same-sized list Result of another type.
        /// </summary>
        /// <param name="list">The list Result to transform.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A list Result of another type with the same number of elements.
        /// </returns>
        public static async Task<Result<List<U>>> Map<T, U>(this IEnumerable<T> list, Func<T, Task<Result<U>>> func)
        {
            var results = new List<U>();
            var fails = Result.Ok<U>(default);
            foreach (var item in list)
            {
                var result = await func(item);
                if (result.IsSuccess)
                {
                    results.Add(result.Value);
                }
                else
                {
                    fails = fails.Combine(result, (_, u) => u); //aggregateSuccess has no meaning here
                }
            }
            return fails.IsFailure
                ? Result.Fail<List<U>>(fails.Error)
                : Result.Ok(results);
        }
    }
}
