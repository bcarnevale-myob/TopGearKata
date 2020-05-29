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

        [Theory]
        [InlineData(499, 1)]
        [InlineData(500, 2)]
        [InlineData(501, 2)]
        public void ShiftsDownAtRpmLessThan500(int rpm, int expectedGear)
        {
            var gearbox = CreateGearboxInGear(2);

            gearbox.DoIt(rpm);

            Assert.Equal(expectedGear, gearbox.GetGear());
        }

        [Theory]
        [InlineData(499)]
        [InlineData(2000)]
        [InlineData(0)]
        [InlineData(int.MinValue)]
        public void DoesNotShiftFromFirstToNeutral(int rpm)
        {
            var gearbox = CreateGearboxInGear(1);
            gearbox.DoIt(rpm);

            Assert.Equal(1, gearbox.GetGear());
        }

        [Fact]
        public void ShiftsDownAtRpmLessThan500ForEveryGear()
        {
            var gearbox = CreateGearboxInGear(6);

            for (var gear = 6; gear > 1; gear--)
            {
                gearbox.DoIt(500);
                Assert.Equal(gear, gearbox.GetGear());
                gearbox.DoIt(499);
                Assert.Equal(gear - 1, gearbox.GetGear());
            }
        }

        private void ChangeUpGears(GearBox gearbox, int numberOfGearsShifts)
        {
            for (var i = 0; i < numberOfGearsShifts; i++)
            {
                gearbox.DoIt(2001);
            }
        }

        private GearBox CreateGearboxInGear(int gear)
        {
            var gearbox = new GearBox();
            for (var i = 0; i < gear; i++)
            {
                gearbox.DoIt(2001);
            }

            return gearbox;
        }
    }
}
