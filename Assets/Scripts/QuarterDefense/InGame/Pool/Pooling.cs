using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace QuarterDefense.InGame.Pool
{
    // Scripted by Raycast
    // 2023. 06. 12
    // Object Pool Base 클래스입니다.
    
    public abstract class Pooling<T> : MonoBehaviour, IDisposable where T : Component
    {
        [SerializeField] private T prefab;
        [SerializeField] private int capacity;
        
        private Queue<T> _queue;

        private bool InstanceExist => _queue != null && _queue.Any();

        private void Awake()
        {
            Pool();
        }

        public T Get()
        {
            T instance = InstanceExist
                ? _queue.Dequeue()
                : Create();
            
            instance.gameObject.SetActive(true);
            
            return instance;
        }

        public void Return(T toTarget)
        {
            toTarget.gameObject.SetActive(false);

            _queue.Enqueue(toTarget);
        }

        public void Dispose()
        {
            while (InstanceExist)
            {
                Destroy(_queue.Dequeue());
            }
            
            _queue.Clear();
        }

        private void Pool()
        {
            _queue = new Queue<T>();

            for (int i = 0; i < capacity; i++)
            {
                Return(Create());
            }
        }
        
        private T Create()
        {
            T createObject = Instantiate(prefab, transform);

            return createObject;
        }
    }
}