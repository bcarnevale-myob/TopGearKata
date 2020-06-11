namespace GearBox
{
    public class GearBox
    {
        private int _gear = 0;

        public int GetGear()
        {
            return _gear;
        }
        public void ChangeGears(int rpm)
        {
            if (_gear == 0)
            {
                _gear = 1;
            }
            else if (rpm > 2000)
            {
                _gear++;
            }
            
            
        }
    }
}