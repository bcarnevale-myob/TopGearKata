namespace GearBox
{
    public class GearBox
    {
        private int _gear = 0;
        private int e = 0;



        public void DoIt(int i)
        {

            if (_gear < 0)
            {
                // do nothing!
                e = i;
            }
            else
            {
                if (_gear > 0)
                {
                    if (i > 2000)
                    {
                        _gear++;
                    }
                    else if (i < 500)
                    {
                        _gear--;
                    }
                }
            }

            if (_gear > 6)
            {
                _gear--;
            }
            else if (_gear < 1)
            {
                _gear++;
            }

            e = i;
        }

        public int GetGear() => _gear;
        public int E() => e;
    }
}