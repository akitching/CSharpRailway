using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultValueOrFallbackTaskTExtensions
    {
        /// <summary>
        /// Returns the value if the result is a success, otherwise
        /// returns tthe provided fallback value.
        /// </summary>
        /// <param name="tTask">The Result from which to extract the value.</param>
        /// <param name="fallbackValue">The value to return if the result is a failure.</param>
        /// <returns>The value if the result is a success, otherwise the fallback value.</returns>
        public static async Task<T> ValueOrFallback<T>(this Task<Result<T>> tTask, T fallbackValue = default)
        {
            var t = await tTask;
            if (t.IsFailure)
                return fallbackValue;

            return t.Value;
        }
    }
}
