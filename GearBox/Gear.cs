using System.Collections;
using System.Collections.Generic;
namespace GearBox
{
    public class Gear
    {
        public int ChangeUpThreshold {get;}
        public int ChangeDownThreshold {get;}

        public Gear (int changeDownThreshold, int changeUpThreshold)
        {
            ChangeDownThreshold = changeDownThreshold;
            ChangeUpThreshold = changeUpThreshold;
        
        }
    }
}