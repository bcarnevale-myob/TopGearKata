namespace GearBox
{
    public class GearBox
    {
        private const int Neutral = 0;
        private const int MaxGear = 6;
        private const int MinGear = 1;
        private const int ChangeGearUpThreshold = 2000;
        private const int ChangeGearDownThreshold = 500;
        private int _gear = Neutral;
        
        public int GetGear()
        {
            return _gear;
        }
        public void ChangeGears(int rpm)
        {
            if (_gear == Neutral)
            {
                _gear = 1;
            }
            else if (ShouldShiftUp(rpm))
            {
                _gear++;
            }
            else if (ShouldShiftDown(rpm))
            {
                _gear--;
            }
        }

        private bool ShouldShiftUp(int rpm) => rpm > ChangeGearUpThreshold && _gear < MaxGear;

        private bool ShouldShiftDown(int rpm) => rpm < ChangeGearDownThreshold && _gear > MinGear;
    }
}

