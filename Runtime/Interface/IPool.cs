using System;
using Common.Runtime.Interface;
using Pool.Runtime.Args;
using Pool.Runtime.Object.Interface;

namespace Pool.Runtime.Interface
{
    /// <summary>
    /// Implement this class to create custom Pools.
    /// </summary>
    public interface IPool : IInitialize<IPoolArgs>
    {
        Action OnDestroy { get; set; }
        void Pool(IPoolObject @object);
        bool TryGet(out IPoolObject @object);
        void Destroy();
    }
}