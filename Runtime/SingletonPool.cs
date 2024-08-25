using Pool.Runtime.Abstract;
using Pool.Runtime.Object.Interface;

namespace Pool.Runtime
{
    /// <summary>
    /// A MonoSingleton class for any IPoolObject types.
    /// </summary>
    public class SingletonPool : ASingletonPool<SingletonPool, IPoolObject>
    {
        
    }
}