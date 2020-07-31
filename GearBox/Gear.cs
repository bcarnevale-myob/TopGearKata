using System.Collections;
using System.Collections.Generic;
namespace GearBox
{
    public class GearThreshold
    {
        public int ChangeUpThreshold { get; }
        public int ChangeDownThreshold { get; }

        public GearThreshold(int changeDownThreshold, int changeUpThreshold)
        {
            ChangeDownThreshold = changeDownThreshold;
            ChangeUpThreshold = changeUpThreshold;
        }
    }
}