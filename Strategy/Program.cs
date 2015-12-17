using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Duck mallarDuck = new MallarDuck();
            mallarDuck.PerformFly();
            Console.ReadKey();
        }
    }
}
