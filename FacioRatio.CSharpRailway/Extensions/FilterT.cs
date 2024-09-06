using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultFilterTExtensions
    {
        /// <summary>
        /// Filter a list Result into a smaller-sized list Result of the same type.
        /// </summary>
        /// <param name="tList">The list Result to filter.</param>
        /// <param name="func">The filter function.</param>
        /// <returns>
        /// A list Result of the same type with fewer elements.
        /// </returns>
        public static Result<List<T>> Filter<T>(this Result<IEnumerable<T>> tList, Func<T, Result<bool>> func)
        {
            return tList.Bind(list => list.Filter(func));
        }

        /// <summary>
        /// Filter a list Result into a smaller-sized list Result of the same type.
        /// </summary>
        /// <param name="tList">The list Result to filter.</param>
        /// <param name="func">The filter function.</param>
        /// <returns>
        /// A list Result of the same type with fewer elements.
        /// </returns>
        public static Task<Result<List<T>>> Filter<T>(this Result<IEnumerable<T>> tList, Func<T, Task<Result<bool>>> func)
        {
            return tList.Bind(list => list.Filter(func));
        }

        /// <summary>
        /// Filter a list Result into a smaller-sized list Result of the same type.
        /// </summary>
        /// <param name="tList">The list Result to filter.</param>
        /// <param name="func">The filter function.</param>
        /// <returns>
        /// A list Result of the same type with fewer elements.
        /// </returns>
        public static Result<List<T>> Filter<T>(this Result<IEnumerable<T>> tList, Func<T, bool> func)
        {
            return tList.Bind(list => list.Filter(x => Result.Ok(func(x))));
        }

        /// <summary>
        /// Filter a list Result into a smaller-sized list Result of the same type.
        /// </summary>
        /// <param name="tList">The list Result to filter.</param>
        /// <param name="func">The filter function.</param>
        /// <returns>
        /// A list Result of the same type with fewer elements.
        /// </returns>
        public static Task<Result<List<T>>> Filter<T>(this Result<IEnumerable<T>> tList, Func<T, Task<bool>> func)
        {
            return tList.Bind(list => list.Filter(async x => Result.Ok(await func(x))));
        }

        /// <summary>
        /// Filter a list Result into a smaller-sized list Result of the same type.
        /// </summary>
        /// <param name="tList">The list Result to filter.</param>
        /// <param name="func">The filter function.</param>
        /// <returns>
        /// A list Result of the same type with fewer elements.
        /// </returns>
        public static Result<List<T>> Filter<T>(this Result<List<T>> tList, Func<T, Result<bool>> func)
        {
            return tList.Bind(list => list.Filter(func));
        }

        /// <summary>
        /// Filter a list Result into a smaller-sized list Result of the same type.
        /// </summary>
        /// <param name="tList">The list Result to filter.</param>
        /// <param name="func">The filter function.</param>
        /// <returns>
        /// A list Result of the same type with fewer elements.
        /// </returns>
        public static Task<Result<List<T>>> Filter<T>(this Result<List<T>> tList, Func<T, Task<Result<bool>>> func)
        {
            return tList.Bind(list => list.Filter(func));
        }

        /// <summary>
        /// Filter a list Result into a smaller-sized list Result of the same type.
        /// </summary>
        /// <param name="tList">The list Result to filter.</param>
        /// <param name="func">The filter function.</param>
        /// <returns>
        /// A list Result of the same type with fewer elements.
        /// </returns>
        public static Result<List<T>> Filter<T>(this Result<List<T>> tList, Func<T, bool> func)
        {
            return tList.Bind(list => list.Filter(x => Result.Ok(func(x))));
        }

        /// <summary>
        /// Filter a list Result into a smaller-sized list Result of the same type.
        /// </summary>
        /// <param name="tList">The list Result to filter.</param>
        /// <param name="func">The filter function.</param>
        /// <returns>
        /// A list Result of the same type with fewer elements.
        /// </returns>
        public static Task<Result<List<T>>> Filter<T>(this Result<List<T>> tList, Func<T, Task<bool>> func)
        {
            return tList.Bind(list => list.Filter(async x => Result.Ok(await func(x))));
        }

        /// <summary>
        /// Filter a list Result into a smaller-sized list Result of the same type.
        /// </summary>
        /// <param name="tList">The list Result to filter.</param>
        /// <param name="func">The filter function.</param>
        /// <returns>
        /// A list Result of the same type with fewer elements.
        /// </returns>
        public static Result<List<T>> Filter<T>(this IEnumerable<T> list, Func<T, Result<bool>> func)
        {
            var results = new List<T>();
            var fails = Result.Ok<bool>(default);
            foreach (var item in list)
            {
                var result = func(item);
                if (result.IsSuccess)
                {
                    var passesFilter = result.ValueOrFallback(false);
                    if (passesFilter)
                    {
                        results.Add(item);
                    }
                }
                else
                {
                    fails = fails.Combine(result, (_, u) => u); //aggregateSuccess has no meaning here
                }
            }
            return fails.IsFailure
                ? Result.Fail<List<T>>(fails.Error)
                : Result.Ok(results);
        }

        /// <summary>
        /// Filter a list Result into a smaller-sized list Result of the same type.
        /// </summary>
        /// <param name="tList">The list Result to filter.</param>
        /// <param name="func">The filter function.</param>
        /// <returns>
        /// A list Result of the same type with fewer elements.
        /// </returns>
        public static async Task<Result<List<T>>> Filter<T>(this IEnumerable<T> list, Func<T, Task<Result<bool>>> func)
        {
            var results = new List<T>();
            var fails = Result.Ok<bool>(default);
            foreach (var item in list)
            {
                var result = await func(item);
                if (result.IsSuccess)
                {
                    var passesFilter = result.ValueOrFallback(false);
                    if (passesFilter)
                    {
                        results.Add(item);
                    }
                }
                else
                {
                    fails = fails.Combine(result, (_, u) => u); //aggregateSuccess has no meaning here
                }
            }
            return fails.IsFailure
                ? Result.Fail<List<T>>(fails.Error)
                : Result.Ok(results);
        }
    }
}
