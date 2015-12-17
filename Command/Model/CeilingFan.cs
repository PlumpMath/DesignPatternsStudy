/*作者：Jackson
 * 设计模式-命令模式
 * 博客地址：http://www.cnblogs.com/jackson0714/p/5049803.html
 */
using System;

namespace Command
{
    class CeilingFan
    {
        public static readonly int HighSpeed = 3;
        public static readonly int  MediumSpeed = 2;
        public static readonly int LowSpeed = 1;
        public static readonly int OffSpeed = 0;
        private string _location;
        private int _speed;

        public CeilingFan(string location)
        {
            _location = location;
            _speed = OffSpeed;
        }

        public void SetHighSpeed()
        {
            _speed = HighSpeed;
            Console.WriteLine("\n"+_location+" ceiling fan is on High");
        }
        public void SetMediumSpeed()
        {
            _speed = MediumSpeed;
            Console.WriteLine("\n" + _location + " ceiling fan is on Medium");
        }
        public void SetLowSpeed()
        {
            _speed = LowSpeed;
            Console.WriteLine("\n" + _location + " ceiling fan is on Low");
        }

        public void SetOffSpeed()
        {
            _speed = OffSpeed;
            Console.WriteLine("\n" + _location + " ceiling fan is on Off");
        }
        public int GetSpeed()
        {
            return _speed;
        }
    }
}
