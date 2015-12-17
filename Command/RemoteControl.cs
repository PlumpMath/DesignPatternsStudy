/*作者：Jackson
 * 设计模式-命令模式
 * 博客地址：http://www.cnblogs.com/jackson0714/p/5049803.html
 */

using System.Text;

namespace Command
{
    class RemoteControl
    {
        ICommand[] onCommands;
        ICommand[] offCommands;

        public RemoteControl()
        {
            onCommands = new ICommand[7];
            offCommands = new ICommand[7];

            ICommand noCommand = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                onCommands[i] = noCommand;
                offCommands[i] = noCommand;
            }
        }

        public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }

        public void OnButtonWasPushed(int slot)
        {
            onCommands[slot].Execute();
        }

        public void OffButtonWasPushed(int slot)
        {
            offCommands[slot].Execute();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n-----Remote Control-----\n");
            for (int i = 0; i < onCommands.Length; i++)
            {
                stringBuilder.Append("\r\n[slot " + i + "]");
                stringBuilder.Append(onCommands[i].GetType());
                stringBuilder.Append("    ");
                stringBuilder.Append(offCommands[i].GetType());
            }
            return stringBuilder.ToString();
        }
    }
}
