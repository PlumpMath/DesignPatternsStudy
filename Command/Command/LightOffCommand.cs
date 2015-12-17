/*作者：Jackson
 * 设计模式-命令模式
 * 博客地址：http://www.cnblogs.com/jackson0714/p/5049803.html
 */
namespace Command
{
    public class LightOffCommand : ICommand
    {
        private Light _light = null;
        
        public LightOffCommand(Light light)
        {
            this._light = light;
        }

        public void Execute()
        {
            _light.Off();
        }


        public void Undo()
        {
            _light.On();
        }
    }
}
