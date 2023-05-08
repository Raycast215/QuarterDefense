using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.InGame.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float speed = 5.0f;
        
        private float _minDistance = 5.0f;
        
        
        private Transform _targetTransform = null;

        private void Start()
        {
            _targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
        private void FixedUpdate()
        {
            RotateTowardsTarget();
            MoveToTarget();
        }

        private void RotateTowardsTarget()
        {
            float angle = Mathf.Atan2(GetDistanceToTarget().y, GetDistanceToTarget().x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        private void MoveToTarget()
        {
            if(!CheckDistanceToTarget()) return;
            
            transform.position = 
                Vector3.MoveTowards(transform.position, _targetTransform.position, speed * Time.deltaTime);
        }

        /// <summary>
        /// 타겟과의 거리를 반환합니다.
        /// </summary>
        /// <returns></returns>
        private Vector3 GetDistanceToTarget()
        {
            return _targetTransform.position - transform.position;
        }

        /// <summary>
        /// 일정 거리 안에 타겟이 존재해는지 체크합니다.
        /// </summary>
        /// <returns></returns>
        private bool CheckDistanceToTarget()
        {
            return Vector3.Distance(_targetTransform.position, transform.position) >= _minDistance;
        }
    }
}