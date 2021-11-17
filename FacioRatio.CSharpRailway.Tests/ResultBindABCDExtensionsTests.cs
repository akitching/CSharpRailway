﻿using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultBindABCDExtensionsTests
    {
        [Fact]
        public void Bind_ResultU_Fails()
        {
            var sut = Result.Fail<(string, int, short, long)>("fail");

            var result = sut.Bind((s, i, h, l) => Result.Ok($"{s}{i}{h}{l}"));

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<string>(result.ValueOrFallback(""));
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public void Bind_ResultU_Succeeds()
        {
            var sut = Result.Ok(("success", 1, (short)2, (long)3));

            var result = sut.Bind((s, i, h, l) => Result.Ok($"{s}{i}{h}{l}"));

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<string>(result.ValueOrFallback(""));
            Assert.Equal("success123", result.ValueOrFallback());
        }

        [Fact]
        public async Task Bind_TaskResultU_Fails()
        {
            var sut = Result.Fail<(string, int, short, long)>("fail");

            var result = await sut.Bind((s, i, h, l) => Task.FromResult(Result.Ok($"{s}{i}{h}{l}")));

            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<string>(result.ValueOrFallback(""));
            Assert.Equal("fail", result.Error.Message);
        }

        [Fact]
        public async Task Bind_TaskResultU_Succeeds()
        {
            var sut = Result.Ok(("success", 1, (short)2, (long)3));

            var result = await sut.Bind((s, i, h, l) => Task.FromResult(Result.Ok($"{s}{i}{h}{l}")));

            Assert.True(result.IsSuccess);
            Assert.IsAssignableFrom<string>(result.ValueOrFallback(""));
            Assert.Equal("success123", result.ValueOrFallback());
        }
    }
}
