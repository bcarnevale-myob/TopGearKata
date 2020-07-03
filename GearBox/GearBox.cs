using System.Collections;
using System.Collections.Generic;
namespace GearBox
{
    public class GearBox
    {
        private const int Neutral = 0;

        private const int MinGear = 1;

        private int _maxGear = 6;
        private int _changeGearUpThreshold = 2000;
        private int _changeGearDownThreshold = 500;

        private int _gear = Neutral;

        public GearBox() { }
        public GearBox(int maxGear, int changeGearDownThreshold, int changeGearUpThreshold)
        {
            _maxGear = maxGear;
            _changeGearDownThreshold = changeGearDownThreshold;
            _changeGearUpThreshold = changeGearUpThreshold;
        }

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

        private bool ShouldShiftUp(int rpm) => rpm > _changeGearUpThreshold && _gear < _maxGear;

        private bool ShouldShiftDown(int rpm) => rpm < _changeGearDownThreshold && _gear > MinGear;
    }
}

