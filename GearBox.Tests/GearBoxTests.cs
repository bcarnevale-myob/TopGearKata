using Xunit;

namespace GearBox.Tests
{
    public class GearBoxTests
    {
        [Fact]
        public void StartsInNeutral()
        {
            var gearbox = new GearBox();

            Assert.Equal(0, gearbox.S());
        }

        [Fact]
        public void ShiftsToFirstFromNeutralUponFirstDoIt()
        {
            var gearbox = new GearBox();
            gearbox.DoIt(0);

            Assert.Equal(1, gearbox.S());
        }

        [Fact]
        public void Experiment()
        {
            var gearbox = new GearBox();
            gearbox.DoIt(0);
            gearbox.DoIt(2001);
            gearbox.DoIt(2001);
            gearbox.DoIt(499);
            gearbox.DoIt(499);
            gearbox.DoIt(499);
            gearbox.DoIt(499);

            Assert.Equal(1,gearbox.S());
        }
    }
}
