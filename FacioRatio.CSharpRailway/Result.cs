using System;
using System.Threading.Tasks;

namespace FacioRatio.CSharpRailway
{
    /// <summary>
    /// Represents a completed operation that either succeeded and returned a
    /// <see cref="T"/> or failed and returned an error string or exception.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    [System.Diagnostics.DebuggerStepThrough]
    public class Result<T>
    {
        internal readonly T Value;
        public readonly Exception Error;

        public bool IsSuccess => Error == default;
        public bool IsFailure => !IsSuccess;

        internal Result(T value, Exception error = default)
        {
            Error = error;
            Value = value;
        }

        /// <summary>
        /// Returns the value if the result is a success, otherwise
        /// returns tthe provided fallback value.
        /// </summary>
        /// <param name="fallbackValue">The value to return if the result is a failure.</param>
        /// <returns>The value if the result is a success, otherwise the fallback value.</returns>
        public T ValueOrFallback(T fallbackValue = default)
        {
            if (this.IsFailure)
                return fallbackValue;

            return Value;
        }
    }

    /// <summary>
    /// Helper class to create Result instances.
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public static class Result
    {
        /// <summary>
        /// Creates a new successful Result instance with the provided value.
        /// </summary>
        /// <param name="value">The value to store in the result.</param>
        /// <returns>A new Result instance with the provided value.</returns>
        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, default);
        }

        /// <summary>
        /// Creates a new successful Result with an empty value.
        /// </summary>
        /// <returns>A new Result instance with an empty value.</returns>
        public static Result<Empty> Ok()
        {
            return new Result<Empty>(default);
        }

        /// <summary>
        /// Creates a new successful Result instance with the provided value,
        /// wrapped in a <see cref="Task"/>.
        /// </summary>
        /// <param name="value">The value to store in the result.</param>
        /// <returns>A new Result instance with the provided value.</returns>
        public static Task<Result<T>> OkTask<T>(T value)
        {
            return Task.FromResult(Result.Ok(value));
        }

        /// <summary>
        /// Creates a new successful Result with an empty value, wrapped in
        /// a <see cref="Task"/>.
        /// </summary>
        /// <returns>A new Result instance with an empty value.</returns>
        public static Task<Result<Empty>> OkTask()
        {
            return Task.FromResult(Result.Ok());
        }

        /// <summary>
        /// Creates a new failed Result instance with the provided error.
        /// </summary>
        /// <param name="error">The error to store in the result.</param>
        /// <returns>A new Result instance with the provided error.</returns>
        /// <exception cref="ArgumentNullException">If the error is null.</exception>
        public static Result<T> Fail<T>(Exception error)
        {
            if (error == default)
                throw new ArgumentNullException(nameof(error));
            return new Result<T>(default, error);
        }

        /// <summary>
        /// Creates a new failed Result with an empty value and the provided error.
        /// </summary>
        /// <param name="error">The error to store in the result.</param>
        public static Result<Empty> Fail(Exception error)
        {
            return Fail<Empty>(error);
        }

        /// <summary>
        /// Creates a new failed Result instance with the provided error message.
        /// </summary>
        /// <param name="error">The error message to store in the result.</param>
        /// <returns>A new Result instance with the provided error message.</returns>
        /// <exception cref="ArgumentNullException">If the error is null.</exception>
        public static Result<T> Fail<T>(string error)
        {
            if (error == default)
                throw new ArgumentNullException(nameof(error));
            return Fail<T>(new Exception(error));
        }

        /// <summary>
        /// Creates a new failed Result with an empty value and the provided error message.
        /// </summary>
        /// <param name="error">The error message to store in the result.</param>
        public static Result<Empty> Fail(string error)
        {
            return Fail<Empty>(error);
        }

        /// <summary>
        /// Creates a new failed Result instance with the provided error,
        /// wrapped in a <see cref="Task"/>.
        /// </summary>
        /// <param name="error">The error to store in the result.</param>
        /// <returns>A new Result instance with the provided error.</returns>
        public static Task<Result<T>> FailTask<T>(Exception error)
        {
            return Task.FromResult(Fail<T>(error));
        }

        /// <summary>
        /// Creates a new failed Result with an empty value and the provided error,
        /// wrapped in a <see cref="Task"/>.
        /// </summary>
        /// <param name="error">The error to store in the result.</param>
        /// <returns>A new Result instance with the provided error.</returns>
        public static Task<Result<Empty>> FailTask(Exception error)
        {
            return FailTask<Empty>(error);
        }

        /// <summary>
        /// Creates a new failed Result instance with the provided error message,
        /// wrapped in a <see cref="Task"/>.
        /// </summary>
        /// <param name="error">The error message to store in the result.</param>
        /// <returns>A new Result instance with the provided error message.</returns>
        public static Task<Result<T>> FailTask<T>(string error)
        {
            return Task.FromResult(Fail<T>(error));
        }

        /// <summary>
        /// Creates a new failed Result with an empty value and the provided error message,
        /// wrapped in a <see cref="Task"/>.
        /// </summary>
        /// <param name="error">The error message to store in the result.</param>
        /// <returns>A new Result instance with the provided error message.</returns>
        public static Task<Result<Empty>> FailTask(string error)
        {
            return FailTask<Empty>(error);
        }
    }
}
