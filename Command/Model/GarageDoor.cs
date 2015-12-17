/*作者：Jackson
 * 设计模式-命令模式
 * 博客地址：http://www.cnblogs.com/jackson0714/p/5049803.html
 */
using System;

namespace Command
{
    public class GarageDoor
    {
        public void Up()
        { Console.WriteLine("Garage door is Open"); }

        public void Down()
        { Console.WriteLine("Garage door is Close"); }

        public void Stop()
        { Console.WriteLine("Garage door is Stop"); }

        public void LightOn()
        { Console.WriteLine("Garage door light is On"); }

        public void LightOff()
        { Console.WriteLine("Garage door light is Off"); }
    }
}
