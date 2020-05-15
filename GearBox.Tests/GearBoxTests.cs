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

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        [InlineData(0)]
        public void ShiftsFromNeutralToFirstWithAnyRpm(int rpm)
        {
            var gearbox = new GearBox();
            gearbox.DoIt(rpm);

            Assert.Equal(1, gearbox.GetGear());
        }

        [Theory]
        [InlineData(1999, 1)]
        [InlineData(2000, 1)]
        [InlineData(2001, 2)]
        public void ShouldShiftUpAtRpmGreaterThan2000(int rpm, int expectedGear)
        {
            var gearbox = new GearBox();
            //gearbox.DoIt(0);
            gearbox.DoIt(int.MaxValue);
            gearbox.DoIt(rpm);

            Assert.Equal(expectedGear, gearbox.GetGear());
        }

        //tests for second to third, third to fourth, etc.

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

        [Theory]
        [InlineData(1, 2001)]
        [InlineData(2, 2001)]
        [InlineData(3, 2001)]
        [InlineData(4, 2001)]
        [InlineData(5, 2001)]
        [InlineData(6, 2001)]
        [InlineData(7, 2001)]
        public void Experiment(int shiftUpGears, int rmpToTest)
        {
            var gearbox = new GearBox();

            ChangeUpGears(gearbox, shiftUpGears);
            gearbox.DoIt(rmpToTest);
            var expected = shiftUpGears + 1;

            Assert.Equal(expected, gearbox.GetGear());
        }

        private void ChangeUpGears(GearBox gearbox, int numberOfGearsShifts)
        {
            for (var i = 0; i < numberOfGearsShifts; i++)
            {
                gearbox.DoIt(2001);
            }
        }
    }
}
