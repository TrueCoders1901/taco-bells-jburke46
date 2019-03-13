using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {

        }

        [Theory]
        [InlineData("34.073638, -84.677017, TacoBellAcwort")]
        public void ShouldParse(string str)
        {
            var tacoBellTest = new TacoParser();

            ITrackable actual = tacoBellTest.Parse(str);

            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            // TODO: Complete Should Fail Parse
        }
    }
}
