using System.Collections;
using System.Collections.Generic;
namespace GearBox
{
    public class Gear
    {
        public int ChangeUpThreshold { get; }
        public int ChangeDownThreshold { get; }

        private Gear(int changeDownThreshold, int changeUpThreshold)
        {
            ChangeDownThreshold = changeDownThreshold;
            ChangeUpThreshold = changeUpThreshold;
        }

        public static Gear CreateTop(int changeDownThreshold)
        {
            return new Gear(changeDownThreshold,int.MaxValue);
        }

        public static Gear Create(int changeDownThreshold, int changeUpThreshold)
        {
            return new Gear(changeDownThreshold,changeUpThreshold);
        }

        public static Gear CreateFirst(int changeUpThreshold)
        {
            return new Gear(int.MinValue, changeUpThreshold);
        }
    }
}