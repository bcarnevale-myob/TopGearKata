namespace GearBox
{
    public class GearBox
    {
        private const int Neutral = 0;

        private int _gear = Neutral;


        public int GetGear()
        {
            return _gear;
        }
        public void ChangeGears(int rpm)
        {
            const int maxGear = 6;
            const int minGear = 1;
            const int changeGearUpThreshold = 2000;
            const int changeGearDownThreshold = 500;

            bool shouldShiftUp() => rpm > changeGearUpThreshold && _gear < maxGear;
            bool shouldShiftDown() => rpm < changeGearDownThreshold && _gear > minGear;


            if (_gear == Neutral)
            {
                _gear = 1;
            }
            else if (shouldShiftUp())
            {
                _gear++;
            }
            else if (shouldShiftDown())
            {
                _gear--;
            }
        }
    }
}

