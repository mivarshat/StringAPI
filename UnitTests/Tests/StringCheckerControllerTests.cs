using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using StringAPI.Controllers;

namespace UnitTests.Tests
{
    public class StringCheckerControllerTests
    {
        private readonly IFixture fixture;
        private readonly StringCheckerController _sut;

        public StringCheckerControllerTests()
        {
            fixture = new Fixture();
            _sut = new StringCheckerController();
        }

        [Theory]
        [InlineData("abCd")]
        [InlineData("xYz")]
        [InlineData("xtpdY23z")]
        public void CheckAlphabets_InvalidInput_ValidOutput(string input)
        {
            var output = _sut.CheckAlphabets(input);
            output.Should().Be(StatusCodes.Status400BadRequest);
        }


        [Fact]
        public void CheckAlphabets_ValidInput_ValidOutput()
        {
            string input = "abcdefghijklmnopqrstuvwxyz";
            var output = _sut.CheckAlphabets(input);
            output.Should().Be(StatusCodes.Status200OK);
        }
    }
}
