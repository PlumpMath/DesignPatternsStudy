/*作者：Jackson
 * 设计模式-命令模式
 * 博客地址：http://www.cnblogs.com/jackson0714/p/5049803.html
 */
namespace Command
{
    class GarageDoorOpenCommand:ICommand
    {
        private GarageDoor _garageDoor = null;

        public GarageDoorOpenCommand(GarageDoor garageDoor)
        {
            _garageDoor = garageDoor;
        }

        public void Execute()
        {
            _garageDoor.Up();
        }


        public void Undo()
        {
            _garageDoor.Down();
        }
    }
}
