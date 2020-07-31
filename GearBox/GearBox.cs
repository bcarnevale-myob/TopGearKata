using System.Collections;
using System.Collections.Generic;
namespace GearBox
{
    public class GearBox
    {
        private const int Neutral = 0;

        private const int MinGear = 1;

        private int _currentGear = Neutral;

        private readonly List<GearThreshold> _gearThresholds = new List<GearThreshold> { new GearThreshold(int.MinValue, 0) };

        public GearBox(List<GearThreshold> gearThresholds)
        {
            _gearThresholds.AddRange(gearThresholds);
        }

         public GearBox()
        {
            var gearThresholds = new List<GearThreshold>() {
                new GearThreshold(500, 2000),
                new GearThreshold(500, 2000),
                new GearThreshold(500, 2000),
                new GearThreshold(500, 2000),
                new GearThreshold(500, 2000),
                new GearThreshold(500, 2000),
            };
            _gearThresholds.AddRange(gearThresholds);
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

        private int _maxGear => _gearThresholds.Count - 1;

        private bool ShouldShiftUp(int rpm) => rpm > _gearThresholds[_currentGear].ChangeUpThreshold && _currentGear < _maxGear;

        private bool ShouldShiftDown(int rpm) => rpm < _gearThresholds[_currentGear].ChangeDownThreshold && _currentGear > MinGear;
    }
}

