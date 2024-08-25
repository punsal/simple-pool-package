using System;
using System.Collections.Generic;
using Common.Runtime.Abstract;
using Pool.Runtime.Args;
using Pool.Runtime.Interface;
using Pool.Runtime.Object.Interface;

namespace Pool.Runtime.Abstract
{
    public abstract class ASingletonPool<TSingleton, TObject> : AMonoSingleton<TSingleton>, IPool where TSingleton : UnityEngine.Object where TObject : IPoolObject
    {
        private readonly Queue<TObject> _objects = new();
        
        /// <summary>
        /// Initialize on Awake call.
        /// </summary>
        public override void Initialize()
        {
            // Empty;
        }

        public void Initialize(IPoolArgs args)
        {
            throw new NotImplementedException();
        }

        public Action OnDestroy { get; set; }
        
        public void Pool(IPoolObject @object)
        {
            _objects.Enqueue((TObject) @object);
        }

        public bool TryGet(out IPoolObject @object)
        {
            @object = null;
            if (!_objects.TryDequeue(out var result))
            {
                return false;
            }

            @object = result;
            return true;
        }

        public void Destroy()
        {
            while (true)
            {
                if (_objects.TryDequeue(out var result))
                {
                    result.Destroy();
                }
                else
                {
                    break;
                }
            }
            
            OnDestroy?.Invoke();
        }
    }
}