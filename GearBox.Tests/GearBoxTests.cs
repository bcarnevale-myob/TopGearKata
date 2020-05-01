using Xunit;

namespace GearBox.Tests
{
    public class GearBoxTests
    {
        [Fact]
        public void StartsInNeutral()
        {
            var gearbox = new GearBox();
            Assert.Equal(0, gearbox.S());

            decimal d  = 0m;
            Assert.Equal(0, d);

// float f = 0.0F; <- these 0s generally need the F or m  so their type is well known
// Assert.Equal(0,f);

            
        }

        [Fact]
        public void ShiftsToFirstFromNeutralUponFirstDoIt()
        {
            var gearbox = new GearBox();
            gearbox.DoIt(0);

            // feel free to slack/teams me any quetions any time,
            // So I'm not sure what this is:
            // public int S() => s;
            // and because of that I didn't understand any of the tests :(
                
                

            //     ahh it is the same as 
            
//             Wait so this:
//             //     public int S() { get; }
//             Is the same as:
//             //  public int S() => s;
//             ???
//             WHAT!??
// it is also the same as:
//public int S() {
//
//    return s;
//}

//             sort of, internally slightly different but it's the same in this case
// Ok do you think we can look at that part of the code together in the next session? 

so I will give you an exclusive insight, when we finish the tests, we will refactor the code by deleting it all and starting again. what is in that code, is better off not existing than trying to understand. the idea is tests give you confidence that the code works, and then safety to change it

last session of this, the group before yours, when they had finished their tests, they refactored the code using the tests biancas group wrote! to see if they could understand her groups tests and be confident they would allow them to refactor and the code still solve the problem

// Also...aren't you in a very important meeting? hehe :)
// This is fun
            //     it is just a way to get S, as it is a private variable 
            //     I'm not sure that I follow. So the first test asserts that gearbox.S() (which I'm assuming is a method) Will return something...and integer probably because we want to compare it to 0. exactly
            // in fact, we know it must be an integer, if it was a different number type, it requires you to specify
            Assert.Equal(1, gearbox.S());
        }

        [Fact]
        public void Experiment()
        {
            var gearbox = new GearBox();
            gearbox.DoIt(0);
            gearbox.DoIt(2001);
            gearbox.DoIt(2001);
            gearbox.DoIt(499);
            gearbox.DoIt(499);
            gearbox.DoIt(499);
            gearbox.DoIt(499);

            Assert.Equal(1,gearbox.S());
        }
    }
}
