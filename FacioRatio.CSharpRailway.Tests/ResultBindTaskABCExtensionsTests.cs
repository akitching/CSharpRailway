﻿using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultBindTaskABCExtensionsTests
    {
        [Fact]
        public async Task Bind_ResultU_Fails()
        {
            var sut = Task.FromResult(Result.Fail<(string, int, short)>("fail"));

            var result = await sut.Bind((s, i, h) => Result.Ok($"{s}{i}{h}"));

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<string>(result.ValueOrFallback(""));
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task Bind_ResultU_Succeeds()
        {
            var sut = Task.FromResult(Result.Ok(("success", 1, (short)2)));

            var result = await sut.Bind((s, i, h) => Result.Ok($"{s}{i}{h}"));

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<string>(result.ValueOrFallback(""));
            Assert.Equal("success12", result.ValueOrFallback());
        }

        [Fact]
        public async Task Bind_TaskResultU_Fails()
        {
            var sut = Task.FromResult(Result.Fail<(string, int, short)>("fail"));

            var result = await sut.Bind((s, i, h) => Task.FromResult(Result.Ok($"{s}{i}{h}")));

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<string>(result.ValueOrFallback(""));
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task Bind_TaskResultU_Succeeds()
        {
            var sut = Task.FromResult(Result.Ok(("success", 1, (short)2)));

            var result = await sut.Bind((s, i, h) => Task.FromResult(Result.Ok($"{s}{i}{h}")));

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<string>(result.ValueOrFallback(""));
            Assert.Equal("success12", result.ValueOrFallback());
        }
    }
}
