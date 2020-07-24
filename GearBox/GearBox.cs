using System.Collections;
using System.Collections.Generic;
namespace GearBox
{
    public class GearBox
    {
        private const int Neutral = 0;

        private const int MinGear = 1;


        private int _currentGear = Neutral;

        private readonly List<Gear> _gears = new List<Gear> { new Gear(int.MinValue, 0) };



        public GearBox(List<Gear> gears)
        {
            _gears.AddRange(gears);
        }

        public int GetGear()
        {
            return _currentGear;
        }
        public void ChangeGears(int rpm)
        {
            if (_currentGear == Neutral)
            {
                _currentGear = 1;
            }
            else if (ShouldShiftUp(rpm))
            {
                _currentGear++;
            }
            else if (ShouldShiftDown(rpm))
            {
                _currentGear--;
            }
        }

        private int _maxGear => _gears.Count;

        private bool ShouldShiftUp(int rpm) => rpm > _gears[_currentGear].ChangeUpThreshold && _currentGear < _maxGear;

        private bool ShouldShiftDown(int rpm) => rpm < _gears[_currentGear].ChangeDownThreshold && _currentGear > MinGear;
    }
}

