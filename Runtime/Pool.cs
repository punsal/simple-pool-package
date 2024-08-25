using Pool.Runtime.Abstract;
using Pool.Runtime.Args;
using Pool.Runtime.Object.Interface;

namespace Pool.Runtime
{
    /// <summary>
    /// A MonoBehaviour class that implements IPool interface for any IPoolObject types. 
    /// </summary>
    public class Pool : APool<IPoolObject>
    {
        public override void Initialize(IPoolArgs args)
        {
            // Empty
        }
    }
}