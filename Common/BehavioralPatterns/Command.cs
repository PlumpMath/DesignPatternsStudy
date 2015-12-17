using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Common.BehavioralPatterns
{
    /// <summary>
    /// 抽象命令对象
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// 提供给调用者的统一操作方法
        /// </summary>
        void Execute();

        Task ExecuteAsync();
    }

    public class NoCommand : ICommand
    {
        public void Execute()
        {
        }

        public Task ExecuteAsync()
        {
            return Task.Factory.StartNew(Execute);
        }
    }

    public class BaseCommand<T> : ICommand where T : class, IInput
    {
        private Action<T> action;
        protected T ParamObject { get; set; }

        public BaseCommand(Action<T> action)
             : this(action, null)
        {
        }

        public BaseCommand(Action<T> action, T obj)
        {
            this.action = action;
            var result = CheckParamObject();
            if (result == false)
            {
                throw new ArgumentException("result.Message");
            }
            this.ParamObject = obj;
        }

        protected virtual bool CheckParamObject()
        {
            return true;
        }

        public virtual void Execute()
        {
            action.Invoke(ParamObject);
        }

        public Task ExecuteAsync()
        {
            return Task.Factory.StartNew(Execute);
        }
    }

    public class Receiver
    {
        public void Action(Input obj)
        {
            Console.WriteLine(obj.Name);
        }
    }

    /// <summary>
    /// 要执行的命令，如果带参数，则统一采用一个参数对象，此对象需要继承此接口
    /// </summary>
    public class Input : IInput
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// 保存Command的队列
    /// </summary>
    public class CommandQueue : ConcurrentQueue<ICommand>
    {
    }

    /// <summary>
    /// 调用者（队列）
    /// </summary>
    public class CommandQueueInvoker
    {
        /// <summary>
        /// 管理相关命令对象
        /// </summary>
        private static CommandQueue queue = new CommandQueue();

        /// <summary>
        /// 开启數據同步任务
        /// </summary>
        private static readonly Task QueueMonitorTask = Task.Factory.StartNew(() =>
        {
            while (true)
            {
                RunQueue();
            }
        }, TaskCreationOptions.LongRunning);

        /// <summary>
        /// 按照队列方式执行排队的命令。相对而言，这时候Invoker
        /// 具有执行的主动性，此处可以嵌入很多其他控制逻辑
        /// </summary>
        private static void RunQueue()
        {
            ICommand command;
            if (queue.TryDequeue(out command))
            {
                try
                {
                    command.Execute();
                }
                catch (Exception ex)
                {
                    throw ex;
                    //LogHelper.WriteException(ex);
                }
            }
            Thread.Sleep(100);
        }

        public CommandQueueInvoker()
        {
        }

        public CommandQueueInvoker(ICommand command)
        {
            AddCommand(command);
        }

        public void AddCommand(ICommand command)
        {
            StoreCommand(command);
            queue.Enqueue(command);
        }

        private void StoreCommand(ICommand command)
        {
            //Store to db
        }
    }

    /// <summary>
    /// 调用者（普通）
    /// </summary>
    public class Invoker
    {
        ICommand[] commands;

        public Invoker()
        {
            commands = new ICommand[7];

            var noCommand = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                commands[i] = noCommand;
            }
        }

        public void SetCommand(int slot, ICommand command)
        {
            StoreCommand(command);
            commands[slot] = command;
        }

        public void DoCommand(int slot)
        {
           commands[slot].Execute();
        }

        private void StoreCommand(ICommand command)
        {
            //Store to db
        }
    }


    public class ConcreteCommand : BaseCommand<Input>
    {
        private Receiver receiver;

        public ConcreteCommand(Receiver receiver, Input input)
            : base(receiver.Action, input)
        {
            this.receiver = receiver;
        }

        protected override bool CheckParamObject()
        {
            //Do somthing
            return true;
        }

        public override void Execute()
        {
            PreExecute();
            base.Execute();
            Ececuted();
        }

        private void Ececuted()
        {
            throw new NotImplementedException();
        }

        private void PreExecute()
        {
            throw new NotImplementedException();
        }
    }

    public class CommandClient
    {
        public void Test()
        {
            Receiver receiver = new Receiver();
            var input = new Input { Name = "Hello World" };
            var cmd = new ConcreteCommand(receiver, input);
            Invoker invoker = new Invoker();
            invoker.SetCommand(1, cmd);
            invoker.DoCommand(1);
        }
    }
}
