namespace FacioRatio.CSharpRailway
{
    [System.Diagnostics.DebuggerStepThrough]
    public static class ResultEmptyTExtensions
    {
        /// <summary>
        /// Transform a Result into an Empty Result.
        /// </summary>
        /// <param name="t">The Result to convert.</param>
        /// <returns>
        /// An empty Result.
        /// </returns>
        public static Result<Empty> Empty<T>(this Result<T> t)
        {
            if (t.IsFailure)
                return Result.Fail<Empty>(t.Error);

            return Result.Ok();
        }
    }
}
