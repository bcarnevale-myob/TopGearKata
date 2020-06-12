using Xunit;
namespace GearBox.Tests
{
    public class GearBoxTests
    {
        // 1. New gearbox starts in neutral
        // 2. Gearbox shifts from neutral to first gear with any RPM
        // 3. From first gear onwards, shifts up with RPM greater than 2000
        // 4. Maximum gear is 6
        // 5. Shifts down at RPM less than 500 until gear 1
        // 6. Never shifts from gear 1 back to neutral
        const int neutral = 0;

        // 1. New gearbox starts in neutral
        [Fact]
        public void StartsInNeutral()
        {
            var gearbox = new GearBox();
            Assert.Equal(neutral, gearbox.GetGear());
        }

        // 2. Gearbox shifts from neutral to first gear with any RPM
        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        [InlineData(0)]
        [InlineData(500)]
        public void ShiftsFromNeutralToFirstWithAnyRpm(int rpm)
        {
            var gearbox = new GearBox();
            gearbox.ChangeGears(rpm);
            Assert.Equal(1, gearbox.GetGear());
        }

        // 3. From first gear onwards, shifts up with RPM greater than 2000
        [Theory]
        [InlineData(1999, 1)]
        [InlineData(2000, 1)]
        [InlineData(2001, 2)]
        public void ShiftsUpAtRpmGreaterThan2000(int rpm, int expectedGear)
        {
            GearBox gearbox = CreateGearboxInGear(1);
            gearbox.ChangeGears(rpm);
            Assert.Equal(expectedGear, gearbox.GetGear());
        }

        // 3. From first gear onwards, shifts up with RPM greater than 2000
        [Fact]
        public void ShiftsUpAtRpmGreaterThan2000ForEveryGear()
        {
            GearBox gearbox = CreateGearboxInGear(1);
            for (var gear = 1; gear <= 5; gear++)
            {
                gearbox.ChangeGears(2000);
                Assert.Equal(gear, gearbox.GetGear());
                gearbox.ChangeGears(2001);
                Assert.Equal(gear + 1, gearbox.GetGear());
            }
        }

        // 4. Maximum gear is 6
        [Fact]
        public void HasMaximumSixGears()
        {
            GearBox gearbox = CreateGearboxInGear(1);
            ChangeUpGears(gearbox, 5);
            Assert.Equal(6, gearbox.GetGear());
            ChangeUpGears(gearbox, 1);
            Assert.NotEqual(7, gearbox.GetGear());
        }

        // 5. Shifts down at RPM less than 500 until gear 1
        [Theory]
        [InlineData(499, 1)]
        [InlineData(500, 2)]
        [InlineData(501, 2)]
        public void ShiftsDownAtRpmLessThan500(int rpm, int expectedGear)
        {
            var gearbox = CreateGearboxInGear(2);
            gearbox.ChangeGears(rpm);
            Assert.Equal(expectedGear, gearbox.GetGear());
        }

        // 5. Shifts down at RPM less than 500 until gear 1
        [Fact]
        public void ShiftsDownAtRpmLessThan500ForEveryGear()
        {
            var gearbox = CreateGearboxInGear(6);
            for (var gear = 6; gear > 1; gear--)
            {
                gearbox.ChangeGears(500);
                Assert.Equal(gear, gearbox.GetGear());
                gearbox.ChangeGears(499);
                Assert.Equal(gear - 1, gearbox.GetGear());
            }
        }

        // 6. Never shifts from gear 1 back to neutral
        [Theory]
        [InlineData(499)]
        [InlineData(0)]
        [InlineData(int.MinValue)]
        public void DoesNotShiftFromFirstToNeutral(int rpm)
        {
            var gearbox = CreateGearboxInGear(1);
            gearbox.ChangeGears(rpm);
            Assert.Equal(1, gearbox.GetGear());
        }

        // Helper method: changes up gears
        private void ChangeUpGears(GearBox gearbox, int numberOfGearsShifts)
        {
            for (var i = 0; i < numberOfGearsShifts; i++)
            {
                gearbox.ChangeGears(2001);
            }
        }

        private GearBox CreateGearboxInGear(int gear)
        {
            var gearbox = new GearBox();
            for (var i = 0; i < gear; i++)
            {
                gearbox.ChangeGears(2001);
            }
            return gearbox;
        }
    }
}
