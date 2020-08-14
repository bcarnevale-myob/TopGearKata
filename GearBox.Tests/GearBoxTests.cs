using Xunit;
using System.Collections.Generic;

namespace GearBox.Tests
{
    public class GearBoxTests
    {

        // LAST WEEK: seperated default and custom in test class, discussed if we understood all tests
        // NEXT WEEK: Custom tests to be discussed, how to prevent first gear and top gear being used incorrectly
        // checks, throw exceptions
        // FIRST DRIVER: Adam
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
        [InlineData(500)]
        public void ShiftsFromNeutralToFirstWithAnyRpmValue(int rpm)
        {
            var gearbox = new GearBox();

            gearbox.ChangeGears(rpm);
            Assert.Equal(1, gearbox.GetGear());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(int.MinValue)]
        public void DoesNotShiftFromFirstToNeutral(int rpm)
        {
            var gearbox = CreateGearboxInGear(1);
            gearbox.ChangeGears(rpm);
            Assert.Equal(1, gearbox.GetGear());
        }
        //---------------------------------------------------------------------------------------------------------
        #region DefaultTests 
        public class DefaultBehaviourTests
        {

            [Fact]
            public void HasMaximumSixGears()
            {
                GearBox gearbox = CreateGearboxInGear(1);
                ChangeUpGears(gearbox, 5);
                Assert.Equal(6, gearbox.GetGear());
                ChangeUpGears(gearbox, 1);
                Assert.NotEqual(7, gearbox.GetGear());
            }

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

        }
        #endregion
//---------------------------------------------------------------------------------------------------------
        public class CustomBehaviourTests
        {
            [Fact]
            public void CanShiftUpWithCustomThresholds()
            {
                var gears = new List<Gear>() { Gear.CreateFirst(1000), Gear.CreateTop(300) };
                var gearbox = new GearBox(gears);
                gearbox.ChangeGears(0); 
                gearbox.ChangeGears(3001); 

                Assert.Equal(2, gearbox.GetGear());
            }

            [Fact]
            public void CanHaveGearsWithDifferentThresholds()
            {
                var gear1 = Gear.CreateFirst(1000);
                var gear2 = Gear.Create(500, 2000);
                var gear3 = Gear.CreateTop(300);

                var gears = new List<Gear>() { gear1, gear2, gear3};
                var gearBox = new GearBox(gears);

                gearBox.ChangeGears(1);   
                gearBox.ChangeGears(1001);
                gearBox.ChangeGears(1001);  
                gearBox.ChangeGears(2001);  

                Assert.Equal(3, gearBox.GetGear());
            }
        }       

        private static void ChangeUpGears(GearBox gearbox, int numberOfGearsShifts)
        {
            for (var i = 0; i < numberOfGearsShifts; i++)
            {
                gearbox.ChangeGears(2001);
            }
        }

        private static GearBox CreateGearboxInGear(int gear)
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
