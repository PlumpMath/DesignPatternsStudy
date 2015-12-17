using System;

namespace Strategy
{
    public class MallarDuck : Duck
    {
        public MallarDuck()
        {
            base.iFlyBehavior = new FlyWithWings();
        }

        public override void Display()
        {
            Console.WriteLine("I'm a real Mallard duck");
        }
    }
}
