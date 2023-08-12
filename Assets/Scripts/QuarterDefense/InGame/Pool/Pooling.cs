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
        
        /// <summary>
        /// 풀링을 초기화합니다.
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="capacity"></param>
        /// <param name="layer"></param>
        public Pooling(T prefab, int capacity, Transform layer)
        {
            _prefab = prefab;
            _capacity = capacity;
            _layer = layer;
        }
        
        /// <summary>
        /// 풀링을 실행합니다.
        /// </summary>
        public void Pool()
        {
            _queue = new Queue<T>();

            for (int i = 0; i < _capacity; i++)
            {
                Return(Create());
            }
        }

        // 인스턴스를 반환합니다.
        public T Get()
        {
            T instance = InstanceExist
                ? _queue.Dequeue()
                : Create();

            return instance;
        }

        /// <summary>
        /// 오브젝트를 반환합니다.
        /// </summary>
        /// <param name="toTarget"></param>
        public void Return(T toTarget)
        {
            toTarget.gameObject.SetActive(false);

            _queue.Enqueue(toTarget);

            Debug.Log($"Character Pool Return... {toTarget.transform.GetSiblingIndex()} / {toTarget.name}");
        }

        /// <summary>
        /// 오브젝트를 제거합니다.
        /// </summary>
        public void Dispose()
        {
            while (InstanceExist)
            {
                UnityEngine.Object.Destroy(_queue.Dequeue());
            }
            
            _queue.Clear();
        }
        
        /// <summary>
        /// 오브젝트를 생성합니다.
        /// </summary>
        /// <returns></returns>
        private T Create()
        {
            T createObject = UnityEngine.Object.Instantiate(_prefab, _layer);

            // createObject.name = _prefab.name + _queue.Count;
            
            return createObject;
        }
    }
}