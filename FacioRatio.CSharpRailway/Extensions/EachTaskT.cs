using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultEachTaskTExtensions
    {
        /// <summary>
        /// Act on each element in a list and return an aggregate Empty Result.
        /// </summary>
        /// <param name="listTask">The list to act on.</param>
        /// <param name="func">The action to perform on each element.</param>
        /// <returns>
        /// A successful Result with an Empty value.
        /// </returns>
        public static async Task<Result<Empty>> Each<T>(this Task<IEnumerable<T>> listTask, Action<T> func)
        {
            var list = await listTask;
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
        public static async Task<Result<Empty>> Each<T>(this Task<IEnumerable<T>> listTask, Func<T, Result<Empty>> func)
        {
            var list = await listTask;
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
        public static async Task<Result<Empty>> Each<T>(this Task<IEnumerable<T>> listTask, Func<T, Task> func)
        {
            var list = await listTask;
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
        public static async Task<Result<Empty>> Each<T>(this Task<IEnumerable<T>> listTask, Func<T, Task<Result<Empty>>> func)
        {
            var list = await listTask;
            return await list.Aggregate(Task.FromResult(Result.Ok()), (lst, el) => lst.Combine(func(el)));
        }

        /// <summary>
        /// Act on each element in a list and return an aggregate Empty Result.
        /// </summary>
        /// <param name="list">The list to act on.</param>
        /// <param name="func">The action to perform on each element.</param>
        /// <returns>
        /// A successful Result with an Empty value.
        /// </returns>
        public static async Task<Result<Empty>> Each<T>(this Task<List<T>> listTask, Action<T> func)
        {
            var list = await listTask;
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
        public static async Task<Result<Empty>> Each<T>(this Task<List<T>> listTask, Func<T, Result<Empty>> func)
        {
            var list = await listTask;
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
        public static async Task<Result<Empty>> Each<T>(this Task<List<T>> listTask, Func<T, Task> func)
        {
            var list = await listTask;
            await Task.WhenAll(list.Select(x => func (x)));
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
        public static async Task<Result<Empty>> Each<T>(this Task<List<T>> listTask, Func<T, Task<Result<Empty>>> func)
        {
            var list = await listTask;
            return await list.Aggregate(Task.FromResult(Result.Ok()), (lst, el) => lst.Combine(func(el)));
        }
    }
}
