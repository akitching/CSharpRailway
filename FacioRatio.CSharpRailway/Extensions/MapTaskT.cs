using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultMapTaskTExtensions
    {
        /// <summary>
        /// Transform a list Result into a same-sized list Result of another type.
        /// </summary>
        /// <param name="tListTask">The list Result to transform.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A list Result of another type with the same number of elements.
        /// </returns>
        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, Result<U>> func)
        {
            return tListTask.Bind(list => list.Map(func));
        }

        /// <summary>
        /// Transform a list Result into a same-sized list Result of another type.
        /// </summary>
        /// <param name="tListTask">The list Result to transform.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A list Result of another type with the same number of elements.
        /// </returns>
        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, Task<Result<U>>> func)
        {
            return tListTask.Bind(list => list.Map(func));
        }

        /// <summary>
        /// Transform a list Result into a same-sized list Result of another type.
        /// </summary>
        /// <param name="tListTask">The list Result to transform.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A list Result of another type with the same number of elements.
        /// </returns>
        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, U> func)
        {
            return tListTask.Bind(list => list.Map(x => Result.Ok(func(x))));
        }

        /// <summary>
        /// Transform a list Result into a same-sized list Result of another type.
        /// </summary>
        /// <param name="tListTask">The list Result to transform.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A list Result of another type with the same number of elements.
        /// </returns>
        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, Task<U>> func)
        {
            return tListTask.Bind(list => list.Map(async x => Result.Ok(await func(x))));
        }

        /// <summary>
        /// Transform a list Result into a same-sized list Result of another type.
        /// </summary>
        /// <param name="tListTask">The list Result to transform.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A list Result of another type with the same number of elements.
        /// </returns>
        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<List<T>>> tListTask, Func<T, Result<U>> func)
        {
            return tListTask.Bind(list => list.Map(func));
        }

        /// <summary>
        /// Transform a list Result into a same-sized list Result of another type.
        /// </summary>
        /// <param name="tListTask">The list Result to transform.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A list Result of another type with the same number of elements.
        /// </returns>
        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<List<T>>> tListTask, Func<T, Task<Result<U>>> func)
        {
            return tListTask.Bind(list => list.Map(func));
        }

        /// <summary>
        /// Transform a list Result into a same-sized list Result of another type.
        /// </summary>
        /// <param name="tListTask">The list Result to transform.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A list Result of another type with the same number of elements.
        /// </returns>
        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<List<T>>> tListTask, Func<T, U> func)
        {
            return tListTask.Bind(list => list.Map(x => Result.Ok(func(x))));
        }

        /// <summary>
        /// Transform a list Result into a same-sized list Result of another type.
        /// </summary>
        /// <param name="tListTask">The list Result to transform.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A list Result of another type with the same number of elements.
        /// </returns>
        public static Task<Result<List<U>>> Map<T, U>(this Task<Result<List<T>>> tListTask, Func<T, Task<U>> func)
        {
            return tListTask.Bind(list => list.Map(async x => Result.Ok(await func(x))));
        }
    }
}
