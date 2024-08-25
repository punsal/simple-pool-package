using Pool.Runtime.Interface;
using Pool.Runtime.Object.Args.Interface;
using Pool.Runtime.Object.Interface;
using UnityEngine;

namespace Pool.Runtime.Object.Abstract
{
    /// <summary>
    /// An abstract class to simply implement IPoolObject interface to a GameObject.
    /// Please override any necessary methods.
    /// </summary>
    /// <seealso cref="IPoolObject"/>
    public abstract class AMonoPoolObject : MonoBehaviour, IPoolObject
    {
        private IPool _pool;
        
        public void Initialize(IPoolObjectArgs args)
        {
            _pool = args.GetPool();    
        }

        public void Enable()
        {
            gameObject.SetActive(true);
            _pool.OnDestroy += Destroy;
        }

        public void Disable()
        {
            gameObject.SetActive(false);
            _pool.OnDestroy -= Destroy;
            _pool.Pool(this);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}