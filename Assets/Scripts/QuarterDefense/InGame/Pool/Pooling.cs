using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace QuarterDefense.InGame.Pool
{
    // Scripted by Raycast
    // 2023. 06. 12
    // Object Pool Base 클래스입니다.
    
    public class Pooling<T> : IDisposable where T : Component
    {
        private readonly T _prefab;
        private readonly int _capacity;
        private readonly Transform _layer;
        
        private Queue<T> _queue;

        private bool InstanceExist => _queue != null && _queue.Any();

        public Pooling(T prefab, int capacity, Transform layer)
        {
            _prefab = prefab;
            _capacity = capacity;
            _layer = layer;
        }
        
        public void Pool()
        {
            _queue = new Queue<T>();

            for (int i = 0; i < _capacity; i++)
            {
                Return(Create());
            }
        }

        public T Get()
        {
            T instance = InstanceExist
                ? _queue.Dequeue()
                : Create();

            return instance;
        }

        public void Return(T toTarget)
        {
            toTarget.gameObject.SetActive(false);

            _queue.Enqueue(toTarget);

            Debug.Log($"Character Pool Return... {toTarget.transform.GetSiblingIndex()} / {toTarget.name}");
        }

        public void Dispose()
        {
            while (InstanceExist)
            {
                UnityEngine.Object.Destroy(_queue.Dequeue());
            }
            
            _queue.Clear();
        }
        
        private T Create()
        {
            T createObject = UnityEngine.Object.Instantiate(_prefab, _layer);

            createObject.name = _prefab.name + _queue.Count;
            
            return createObject;
        }
    }
}