using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.InGame.Bullet
{
    // Scripted by Raycast
    // 2023.04.26
    // Bullet Base 클래스입니다.
    
    public class Bullet : MonoBehaviour
    {
        private float _speed = 5.0f;

        public float SetSpeed
        {
            set
            {
                Init();
                _speed = value;
            }
        }

        private void FixedUpdate()
        {
            Move();
        }
        
        public void Fire()
        {
            
        }

        private void Init()
        {
            gameObject.SetActive(false);
            transform.Translate(new Vector3());
        }
        
        private void Move()
        {
            Vector3 pos = new Vector3(Time.deltaTime * _speed, 0, 0);
            
            transform.Translate(pos);
        }
        
    }
}