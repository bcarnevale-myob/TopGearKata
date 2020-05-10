using Xunit;

namespace GearBox.Tests
{
    public class GearBoxTests
    {
        const int neutral = 0;

        [Fact]
        public void StartsInNeutral()
        {
            var gearbox = new GearBox();

            Assert.Equal(neutral, gearbox.GetGear());
        }

        [Fact]
        public void ShiftsToFirstFromNeutralUponFirstDoIt()
        {
            var gearbox = new GearBox();
            gearbox.DoIt(0);

            Assert.Equal(1, gearbox.GetGear());
        }

        [Theory]
        [InlineData(1999, 1)]
        [InlineData(2000, 1)]
        [InlineData(2001, 2)]
        public void ShouldShiftUpAtRpmGreaterThan2000(int i, int expectedGear)
        {
            var gearbox = new GearBox();
            gearbox.DoIt(0);
            gearbox.DoIt(i);

            Assert.Equal(expectedGear, gearbox.GetGear());
        }



        [Fact]
        public void HasMaximumSixGears()
        {
            var gearbox = new GearBox();
            gearbox.DoIt(0);
            gearbox.DoIt(2001);
            gearbox.DoIt(2001);
            gearbox.DoIt(2001);
            gearbox.DoIt(2001);
            gearbox.DoIt(2001);
            gearbox.DoIt(2001);
            gearbox.DoIt(2001);

            Assert.Equal(6, gearbox.GetGear());
        }

        [Fact]
        public void Experiment()
        {
            var gearbox = new GearBox();
            gearbox.DoIt(0);
            gearbox.DoIt(2001);
            gearbox.DoIt(2001);
            gearbox.DoIt(2001);
            gearbox.DoIt(2001);
            gearbox.DoIt(2001);
            gearbox.DoIt(2001);
            gearbox.DoIt(2001);

            Assert.Equal(6, gearbox.GetGear());
        }
    }
}
