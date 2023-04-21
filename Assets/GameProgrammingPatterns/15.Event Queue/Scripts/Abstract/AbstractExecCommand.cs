using System;
namespace WenQu.EventQueue
{
    public abstract class AbstractExecCommand<T> where T : class
    {
        public Action<T> onExecuted;
        public abstract void Execute();

    }
}