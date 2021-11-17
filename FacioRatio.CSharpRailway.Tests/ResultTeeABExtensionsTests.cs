﻿using System.Threading.Tasks;
using Xunit;

namespace FacioRatio.CSharpRailway.Tests
{
    public class ResultTeeABExtensionsTests
    {
        [Fact]
        public void Tee_Action_Success()
        {
            var sut = Result.Ok<(int, int)>((1, 2));

            var i = 0;
            var result = sut.Tee((a, b) => i = a * b);
            Assert.True(result.IsSuccess);
            Assert.Equal((1, 2), result.ValueOrFallback());
            Assert.Equal(2, i);
        }

        [Fact]
        public void Tee_Action_Failure()
        {
            var sut = Result.Fail<(int, int)>("fail");

            var i = 0;
            var result = sut.Tee((a, b) => i = a * b);
            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(int, int)>(result.ValueOrFallback());
            Assert.Equal(0, i);
        }

        [Fact]
        public async Task Tee_FuncTask_Success()
        {
            var sut = Result.Ok<(int, int)>((1, 2));

            var i = 0;
            var result = await sut.Tee((a, b) => Task.FromResult(i = a * b));
            Assert.True(result.IsSuccess);
            Assert.Equal((1, 2), result.ValueOrFallback());
            Assert.Equal(2, i);
        }

        [Fact]
        public async Task Tee_FuncTask_Failure()
        {
            var sut = Result.Fail<(int, int)>("fail");

            var i = 0;
            var result = await sut.Tee((a, b) => Task.FromResult(i = a * b));
            Assert.True(result.IsFailure);
            Assert.IsAssignableFrom<(int, int)>(result.ValueOrFallback());
            Assert.Equal(0, i);
        }
    }
}
