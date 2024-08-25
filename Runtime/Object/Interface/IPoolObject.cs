using Common.Runtime.Interface;
using Pool.Runtime.Object.Abstract;
using Pool.Runtime.Object.Args.Interface;

namespace Pool.Runtime.Object.Interface
{
    /// <summary>
    /// Implement this class to create custom PoolElements.
    /// </summary>
    /// <seealso cref="AMonoPoolObject">MonoBehaviour implementation</seealso>
    public interface IPoolObject : IInitialize<IPoolObjectArgs>
    {
        void Enable();
        void Disable();
        void Destroy();
    }
}