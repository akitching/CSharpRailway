using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultUnfailIfTaskEmptyExtensions
    {
        /// <summary>
        /// Specify a condition to convert a failure Result into a success Result.
        /// </summary>
        /// <param name="tTask">The Result to verify.</param>
        /// <param name="func">The condition function.</param>
        /// <returns>
        /// The original Result if the condition is false, otherwise a successful emmpty Result.
        /// </returns>
        public static async Task<Result<Empty>> UnFailIf(this Task<Result<Empty>> tTask, Func<Exception, bool> func)
        {
            var t = await tTask;
            if (t.IsSuccess)
                return t;

            if (func(t.Error))
                return Result.Ok();
            return t;
        }

        /// <summary>
        /// Specify a condition to convert a failure Result into a success Result.
        /// </summary>
        /// <param name="tTask">The Result to verify.</param>
        /// <param name="func">The condition function.</param>
        /// <returns>
        /// The original Result if the condition is false, otherwise a successful emmpty Result.
        /// </returns>
        public static async Task<Result<Empty>> UnFailIf(this Task<Result<Empty>> tTask, Func<Exception, Task<bool>> func)
        {
            var t = await tTask;
            if (t.IsSuccess)
                return t;

            if (await func(t.Error))
                return Result.Ok();
            return t;
        }
    }
}
