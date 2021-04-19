using MercadoEletronico.Challenge.Util.Extensions;
using Xunit;

namespace MercadoEletronico.Challenge.UnitTests
{
    public class ObjectExtensionsTests
    {
        [Theory]
        [InlineData("A")]
        [InlineData("B")]
        [InlineData("C")]
        public void In_MustReturnTrueWhenTheValueIsActuallyIn(string seekedValue)
        {
            // Arrange and act
            var present = seekedValue.In("A", "B", "C");

            // Assert
            Assert.True(present);
        }

        [Theory]
        [InlineData("à")]
        [InlineData("b")]
        [InlineData("c")]
        [InlineData("DD")]
        [InlineData("")]
        [InlineData("Y")]
        public void NotIn_MustReturnTrueWhenTheValueIsActuallyNotIn(string seekedValue)
        {
            // Arrange and act
            var present = seekedValue.NotIn("A", "B", "C");

            // Assert
            Assert.True(present);
        }
    }
}
