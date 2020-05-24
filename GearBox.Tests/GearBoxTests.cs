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
        public void ShiftsUpAtRpmGreaterThan2000(int rpm, int expectedGear)
        {
            var gearbox = new GearBox();
            gearbox.DoIt(0);
            gearbox.DoIt(rpm);

            Assert.Equal(expectedGear, gearbox.GetGear());
        }

        //tests for second to third, third to fourth, etc.

        [Fact]
        public void HasMaximumSixGears()
        {
            var gearbox = new GearBox();
            gearbox.DoIt(0);

            ChangeUpGears(gearbox, 5);
            Assert.Equal(6, gearbox.GetGear());

            ChangeUpGears(gearbox, 1);
            Assert.NotEqual(7, gearbox.GetGear());
        }

        [Fact]
        public void ShiftsUpAtRpmGreaterThan2000ForEveryGear()
        {
            var gearbox = new GearBox();
            gearbox.DoIt(0);

            for (var gear = 1; gear <= 5; gear++)
            {
                gearbox.DoIt(2000);
                Assert.Equal(gear, gearbox.GetGear());
                gearbox.DoIt(2001);
                Assert.Equal(gear + 1, gearbox.GetGear());
            }
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
