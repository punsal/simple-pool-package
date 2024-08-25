using Common.Runtime.Args.Interface;
using Pool.Runtime.Interface;

namespace Pool.Runtime.Object.Args.Interface
{
    public interface IPoolObjectArgs : IInitializeArgs
    {
        IPool GetPool();
    }
}