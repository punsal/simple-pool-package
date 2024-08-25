using System;
using System.Collections.Generic;
using Pool.Runtime.Args;
using Pool.Runtime.Interface;
using Pool.Runtime.Object.Interface;
using UnityEngine;

namespace Pool.Runtime.Abstract
{
    /// <summary>
    /// A Queue based template implementation of IPool interface
    /// </summary>
    /// <seealso cref="IPool"/>
    public abstract class APool<TObject> : MonoBehaviour, IPool where TObject : IPoolObject
    {
        private readonly Queue<TObject> _objects = new();

        public abstract void Initialize(IPoolArgs args);

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