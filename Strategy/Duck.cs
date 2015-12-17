
namespace Strategy
{
    public abstract class Duck
    {
        public IFlyBehavior iFlyBehavior;        

        public abstract void Display();

        public void PerformFly()
        {
            iFlyBehavior.Fly();
        }
    }
}
