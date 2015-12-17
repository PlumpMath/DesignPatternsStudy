/*作者：Jackson
 * 设计模式-命令模式
 * 博客地址：http://www.cnblogs.com/jackson0714/p/5049803.html
 */
namespace Command
{
    public interface ICommand
    {
        void Execute();

        void Undo();
    }
}
