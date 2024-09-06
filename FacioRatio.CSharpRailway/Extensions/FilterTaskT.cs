using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultFilterTaskTExtensions
    {
        /// <summary>
        /// Filter a list Result into a smaller-sized list Result of the same type.
        /// </summary>
        /// <param name="tListTask">The list Result to filter.</param>
        /// <param name="func">The filter function.</param>
        /// <returns>
        /// A list Result of the same type with fewer elements.
        /// </returns>
        public static Task<Result<List<T>>> Filter<T>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, Result<bool>> func)
        {
            return tListTask.Bind(list => list.Filter(func));
        }

        /// <summary>
        /// Filter a list Result into a smaller-sized list Result of the same type.
        /// </summary>
        /// <param name="tListTask">The list Result to filter.</param>
        /// <param name="func">The filter function.</param>
        /// <returns>
        /// A list Result of the same type with fewer elements.
        /// </returns>
        public static Task<Result<List<T>>> Filter<T>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, Task<Result<bool>>> func)
        {
            return tListTask.Bind(list => list.Filter(func));
        }

        /// <summary>
        /// Filter a list Result into a smaller-sized list Result of the same type.
        /// </summary>
        /// <param name="tListTask">The list Result to filter.</param>
        /// <param name="func">The filter function.</param>
        /// <returns>
        /// A list Result of the same type with fewer elements.
        /// </returns>
        public static Task<Result<List<T>>> Filter<T>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, bool> func)
        {
            return tListTask.Bind(list => list.Filter(x => Result.Ok(func(x))));
        }

        /// <summary>
        /// Filter a list Result into a smaller-sized list Result of the same type.
        /// </summary>
        /// <param name="tListTask">The list Result to filter.</param>
        /// <param name="func">The filter function.</param>
        /// <returns>
        /// A list Result of the same type with fewer elements.
        /// </returns>
        public static Task<Result<List<T>>> Filter<T>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, Task<bool>> func)
        {
            return tListTask.Bind(list => list.Filter(async x => Result.Ok(await func(x))));
        }

        /// <summary>
        /// Filter a list Result into a smaller-sized list Result of the same type.
        /// </summary>
        /// <param name="tListTask">The list Result to filter.</param>
        /// <param name="func">The filter function.</param>
        /// <returns>
        /// A list Result of the same type with fewer elements.
        /// </returns>
        public static Task<Result<List<T>>> Filter<T>(this Task<Result<List<T>>> tListTask, Func<T, Result<bool>> func)
        {
            return tListTask.Bind(list => list.Filter(func));
        }

        /// <summary>
        /// Filter a list Result into a smaller-sized list Result of the same type.
        /// </summary>
        /// <param name="tListTask">The list Result to filter.</param>
        /// <param name="func">The filter function.</param>
        /// <returns>
        /// A list Result of the same type with fewer elements.
        /// </returns>
        public static Task<Result<List<T>>> Filter<T>(this Task<Result<List<T>>> tListTask, Func<T, Task<Result<bool>>> func)
        {
            return tListTask.Bind(list => list.Filter(func));
        }

        /// <summary>
        /// Filter a list Result into a smaller-sized list Result of the same type.
        /// </summary>
        /// <param name="tListTask">The list Result to filter.</param>
        /// <param name="func">The filter function.</param>
        /// <returns>
        /// A list Result of the same type with fewer elements.
        /// </returns>
        public static Task<Result<List<T>>> Filter<T>(this Task<Result<List<T>>> tListTask, Func<T, bool> func)
        {
            return tListTask.Bind(list => list.Filter(x => Result.Ok(func(x))));
        }

        /// <summary>
        /// Filter a list Result into a smaller-sized list Result of the same type.
        /// </summary>
        /// <param name="tListTask">The list Result to filter.</param>
        /// <param name="func">The filter function.</param>
        /// <returns>
        /// A list Result of the same type with fewer elements.
        /// </returns>
        public static Task<Result<List<T>>> Filter<T>(this Task<Result<List<T>>> tListTask, Func<T, Task<bool>> func)
        {
            return tListTask.Bind(list => list.Filter(async x => Result.Ok(await func(x))));
        }
    }
}
