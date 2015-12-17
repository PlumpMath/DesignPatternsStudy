/*作者：Jackson
 * 设计模式-命令模式
 * 博客地址：http://www.cnblogs.com/jackson0714/p/5049803.html
 */
using System;

namespace Command
{
    public class Light
    {
        public void On()
        {
            Console.WriteLine("Light is On");
        }

        public void Off()
        {
            Console.WriteLine("Light is Off");

        }
    }
}
