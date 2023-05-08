using System;
using System.Collections;
using System.Collections.Generic;
using QuarterDefense.InGame.Interface;
using UnityEngine;

namespace QuarterDefense.InGame.Bullet
{
    // Scripted by Raycast
    // 2023.04.26
    // Bullet Base 클래스입니다.
    
    public class BaseBullet : MonoBehaviour, IPoolableObject
    {
        private float _speed = 5.0f;

        private bool _isMovable = false;
        
        private void FixedUpdate()
        {
            Move();
        }
        
        public void Spawned()
        {
            gameObject.SetActive(true);
        }

        public void Despawned()
        {
            gameObject.SetActive(false);
            transform.Translate(new Vector3());
        }
        
        private void Move()
        {
           // if(!_isMovable) return;

            Vector3 pos = new Vector3(Time.deltaTime * _speed, 0, 0);
            
            transform.Translate(pos);
        }
    }
}