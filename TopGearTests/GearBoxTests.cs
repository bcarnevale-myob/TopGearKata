using Xunit;

namespace TopGear
{
    public class GearBoxTests
    {
        [Fact]
        public void TestNothing() {
            Assert.True(true);
        }

        [Fact]
        public void ShouldInitialiseWithGearZero()
        {
            var gearbox = new GearBox();
            var gear = gearbox.GetS();
            Assert.Equal(0, gear);
        }
    }
}