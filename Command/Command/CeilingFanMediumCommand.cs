/*作者：Jackson
 * 设计模式-命令模式
 * 博客地址：http://www.cnblogs.com/jackson0714/p/5049803.html
 */
namespace Command
{
    class CeilingFanMediumCommand : ICommand
    {
        private CeilingFan _ceilingFan;
        private int _prevSpeed;

        public CeilingFanMediumCommand(CeilingFan ceilingFan)
        {
            _ceilingFan = ceilingFan;
        }
        public void Execute()
        {
            _prevSpeed = _ceilingFan.GetSpeed();//在改变吊扇速度之前，需要先将它之前的状态记录起来，以便需要撤销时使用。
            _ceilingFan.SetMediumSpeed();
        }

        public void Undo()
        {
            if (_prevSpeed == CeilingFan.HighSpeed)
            {
                _ceilingFan.SetHighSpeed();
            }
            else if (_prevSpeed == CeilingFan.MediumSpeed)
            {
                _ceilingFan.SetMediumSpeed();
            }
            if (_prevSpeed == CeilingFan.LowSpeed)
            {
                _ceilingFan.SetLowSpeed();
            }
            if (_prevSpeed == CeilingFan.OffSpeed)
            {
                _ceilingFan.SetOffSpeed();
            }
        }
    }
}
