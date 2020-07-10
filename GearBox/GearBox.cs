using System.Collections;
using System.Collections.Generic;
namespace GearBox
{
    public class GearBox
    {
        private const int Neutral = 0;

        private const int MinGear = 1;

        const int _maxGear = 6;

        private int _gear = Neutral;

        private Gear _gearThreshold;

       
        public GearBox(Gear gearThreshold)
        {
           _gearThreshold = gearThreshold;
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

        private bool ShouldShiftUp(int rpm) => rpm > _gearThreshold.ChangeUpThreshold && _gear < _maxGear;

        private bool ShouldShiftDown(int rpm) => rpm < _gearThreshold.ChangeDownThreshold && _gear > MinGear;
    }
}

