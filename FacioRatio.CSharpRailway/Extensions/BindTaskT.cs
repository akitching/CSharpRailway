using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultBindTaskTExtensions
    {
        /// <summary>
        /// Transform a Result to another Result type.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static async Task<Result<U>> Bind<T, U>(this Task<Result<T>> tTask, Func<T, Result<U>> func)
        {
            return (await tTask).Bind(func);
        }

        /// <summary>
        /// Transform a Result to another Result type.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static async Task<Result<U>> Bind<T, U>(this Task<Result<T>> tTask, Func<T, Task<Result<U>>> func)
        {
            return await (await tTask).Bind(func);
        }

        /// <summary>
        /// Transform a Result to another Result type.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static async Task<Result<U>> Bind<T, U>(this Task<Result<T>> tTask, Func<T, U> func)
        {
            return (await tTask).Bind(func);
        }

        /// <summary>
        /// Transform a Result to another Result type.
        /// </summary>
        /// <param name="tTask">The Result to bind.</param>
        /// <param name="func">The transformation function.</param>
        /// <returns>
        /// A successful Result with the result of the passed function.
        /// </returns>
        public static async Task<Result<U>> Bind<T, U>(this Task<Result<T>> tTask, Func<T, Task<U>> func)
        {
            return await (await tTask).Bind(func);
        }
    }
}
