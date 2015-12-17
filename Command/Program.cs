/*作者：Jackson
 * 设计模式-命令模式
 * 博客地址：http://www.cnblogs.com/jackson0714/p/5049803.html
 */

using System;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {

            Light light = new Light();
            GarageDoor garageDoor = new GarageDoor();
            LightOnCommand lightOn = new LightOnCommand(light);
            LightOffCommand lightOff = new LightOffCommand(light);
            GarageDoorOpenCommand garageDoorOpen = new GarageDoorOpenCommand(garageDoor);
            GarageDoorDownCommand garageDoorDown = new GarageDoorDownCommand(garageDoor);

            //01.简单控制器--------------------------
            Console.WriteLine("\n-----01.简单控制器-----\n");
            SimpleRemoteControl remote = new SimpleRemoteControl();
            remote.SetCommand(lightOn);
            remote.ButtonWasPressed();
            remote.SetCommand(garageDoorOpen);
            remote.ButtonWasPressed();

            //02.复杂控制器--------------------------------------
            Console.WriteLine("\n-----02.复杂控制器-----\n");
            RemoteControl remoteControl = new RemoteControl();
            remoteControl.SetCommand(0, lightOn, lightOff);
            remoteControl.SetCommand(1, garageDoorOpen, garageDoorDown);
            Console.WriteLine(remoteControl.ToString());
            remoteControl.OnButtonWasPushed(0);
            remoteControl.OffButtonWasPushed(0);
            remoteControl.OnButtonWasPushed(1);
            remoteControl.OffButtonWasPushed(1);

            //03.复杂控制器，撤销功能--------------------------------------
            Console.WriteLine("\n-----03.复杂控制器，撤销功能-----\n");
            RemoteControlWithUndo remoteControlWithUndo = new RemoteControlWithUndo();
            remoteControlWithUndo.SetCommand(0, lightOn, lightOff);
            remoteControlWithUndo.OnButtonWasPushed(0);
            remoteControlWithUndo.OffButtonWasPushed(0);
            Console.WriteLine(remoteControlWithUndo.ToString());
            remoteControlWithUndo.UndoButtonWasPushed();
            remoteControlWithUndo.OffButtonWasPushed(0);
            remoteControlWithUndo.OnButtonWasPushed(0);
            Console.WriteLine(remoteControlWithUndo.ToString());
            remoteControlWithUndo.UndoButtonWasPushed();

            //04.复杂撤销功能-天花板吊扇
            Console.WriteLine("\n-----04.复杂撤销功能-天花板吊扇-----\n");
            remoteControlWithUndo = new RemoteControlWithUndo();
            CeilingFan ceilingFan = new CeilingFan("Living Room");
            CeilingFanHighCommand ceilingFanHighCommand = new CeilingFanHighCommand(ceilingFan);
            CeilingFanMediumCommand ceilingFanMediumCommand = new CeilingFanMediumCommand(ceilingFan);
            CeilingFanOffCommand ceilingFanOffCommand = new CeilingFanOffCommand(ceilingFan);

            remoteControlWithUndo.SetCommand(0,ceilingFanHighCommand,ceilingFanOffCommand);//0号插槽的On键设置为高速，Off键设置为关闭
            remoteControlWithUndo.SetCommand(1,ceilingFanMediumCommand,ceilingFanOffCommand);//1号插槽的On键设置为中速，Off键设置为关闭

            remoteControlWithUndo.OnButtonWasPushed(0);//首先以高速开启吊扇
            remoteControlWithUndo.OffButtonWasPushed(0);//然后关闭
            Console.WriteLine(remoteControlWithUndo.ToString());
            remoteControlWithUndo.UndoButtonWasPushed();//撤销，回到中速

            remoteControlWithUndo.OnButtonWasPushed(1);//开启中速
            remoteControlWithUndo.OffButtonWasPushed(1);//关闭
            Console.WriteLine(remoteControlWithUndo.ToString());//撤销，回到中速
            remoteControlWithUndo.UndoButtonWasPushed();

            //05.Party模式
            Console.WriteLine("\n-----05.Party模式-----\n");
            ICommand[] partyOn = {lightOn, garageDoorOpen, ceilingFanHighCommand};//一个数组用来记录开启命令
            ICommand[] partyOff = {lightOff, garageDoorDown, ceilingFanOffCommand};//另一个数组用来记录关闭命令
            MacroCommand partyOnMacroCommand = new MacroCommand(partyOn);//创建对应的宏持有开启命令数组
            MacroCommand partyOffMacroCommand = new MacroCommand(partyOff);//创建对应的宏持有关闭命令数组
            remoteControlWithUndo = new RemoteControlWithUndo();
            remoteControlWithUndo.SetCommand(0,partyOnMacroCommand,partyOffMacroCommand);//将宏命令指定一个按钮
            Console.WriteLine(remoteControlWithUndo);
            Console.WriteLine("----Pushing Macro On----");
            remoteControlWithUndo.OnButtonWasPushed(0);
            Console.WriteLine("----Pushing Macro Off----");
            remoteControlWithUndo.OffButtonWasPushed(0);
            Console.WriteLine("----Pushing Macro Undo----");
            remoteControlWithUndo.UndoButtonWasPushed();

            Console.ReadKey();
        }
    }
}
