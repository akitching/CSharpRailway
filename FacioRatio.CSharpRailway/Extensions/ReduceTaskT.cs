using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultReduceTaskTExtensions
    {
        /// <summary>
        /// Reduce a list Result into a single Result of another type.
        /// </summary>
        /// <param name="tListTask">The list Result to reduce.</param>
        /// <param name="func">The reduction function.</param>
        /// <param name="initial">The initial value of tthe new Result.</param>
        /// <returns>
        /// A single Result of type <typeparamref name="U"/>.
        /// </returns>
        public static Task<Result<U>> Reduce<T, U>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, U, Result<U>> func, U initial = default)
        {
            return tListTask.Bind(list => list.Reduce(func, initial));
        }

        /// <summary>
        /// Reduce a list Result into a single Result of another type.
        /// </summary>
        /// <param name="tListTask">The list Result to reduce.</param>
        /// <param name="func">The reduction function.</param>
        /// <param name="initial">The initial value of tthe new Result.</param>
        /// <returns>
        /// A single Result of type <typeparamref name="U"/>.
        /// </returns>
        public static Task<Result<U>> Reduce<T, U>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, U, Task<Result<U>>> func, U initial = default)
        {
            return tListTask.Bind(list => list.Reduce(func, initial));
        }

        /// <summary>
        /// Reduce a list Result into a single Result of another type.
        /// </summary>
        /// <param name="tListTask">The list Result to reduce.</param>
        /// <param name="func">The reduction function.</param>
        /// <param name="initial">The initial value of tthe new Result.</param>
        /// <returns>
        /// A single Result of type <typeparamref name="U"/>.
        /// </returns>
        public static Task<Result<U>> Reduce<T, U>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, U, U> func, U initial = default)
        {
            return tListTask.Bind(list => list.Reduce(func, initial));
        }

        /// <summary>
        /// Reduce a list Result into a single Result of another type.
        /// </summary>
        /// <param name="tListTask">The list Result to reduce.</param>
        /// <param name="func">The reduction function.</param>
        /// <param name="initial">The initial value of tthe new Result.</param>
        /// <returns>
        /// A single Result of type <typeparamref name="U"/>.
        /// </returns>
        public static Task<Result<U>> Reduce<T, U>(this Task<Result<IEnumerable<T>>> tListTask, Func<T, U, Task<U>> func, U initial = default)
        {
            return tListTask.Bind(list => list.Reduce(func, initial));
        }

        /// <summary>
        /// Reduce a list Result into a single Result of another type.
        /// </summary>
        /// <param name="tListTask">The list Result to reduce.</param>
        /// <param name="func">The reduction function.</param>
        /// <param name="initial">The initial value of tthe new Result.</param>
        /// <returns>
        /// A single Result of type <typeparamref name="U"/>.
        /// </returns>
        public static Task<Result<U>> Reduce<T, U>(this Task<Result<List<T>>> tListTask, Func<T, U, Result<U>> func, U initial = default)
        {
            return tListTask.Bind(list => list.Reduce(func, initial));
        }

        /// <summary>
        /// Reduce a list Result into a single Result of another type.
        /// </summary>
        /// <param name="tListTask">The list Result to reduce.</param>
        /// <param name="func">The reduction function.</param>
        /// <param name="initial">The initial value of tthe new Result.</param>
        /// <returns>
        /// A single Result of type <typeparamref name="U"/>.
        /// </returns>
        public static Task<Result<U>> Reduce<T, U>(this Task<Result<List<T>>> tListTask, Func<T, U, Task<Result<U>>> func, U initial = default)
        {
            return tListTask.Bind(list => list.Reduce(func, initial));
        }

        /// <summary>
        /// Reduce a list Result into a single Result of another type.
        /// </summary>
        /// <param name="tListTask">The list Result to reduce.</param>
        /// <param name="func">The reduction function.</param>
        /// <param name="initial">The initial value of tthe new Result.</param>
        /// <returns>
        /// A single Result of type <typeparamref name="U"/>.
        /// </returns>
        public static Task<Result<U>> Reduce<T, U>(this Task<Result<List<T>>> tListTask, Func<T, U, U> func, U initial = default)
        {
            return tListTask.Bind(list => list.Reduce(func, initial));
        }

        /// <summary>
        /// Reduce a list Result into a single Result of another type.
        /// </summary>
        /// <param name="tListTask">The list Result to reduce.</param>
        /// <param name="func">The reduction function.</param>
        /// <param name="initial">The initial value of tthe new Result.</param>
        /// <returns>
        /// A single Result of type <typeparamref name="U"/>.
        /// </returns>
        public static Task<Result<U>> Reduce<T, U>(this Task<Result<List<T>>> tListTask, Func<T, U, Task<U>> func, U initial = default)
        {
            return tListTask.Bind(list => list.Reduce(func, initial));
        }
    }
}
