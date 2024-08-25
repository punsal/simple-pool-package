using Common.Runtime.Args.Interface;

namespace Pool.Runtime.Args
{
    public interface IPoolArgs : IInitializeArgs
    {
        int GetSize();
    }
}