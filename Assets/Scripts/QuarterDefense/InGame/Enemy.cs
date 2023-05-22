using System;
using System.Collections;
using QuarterDefense.Common;
using UnityEngine;

namespace QuarterDefense.InGame
{
    public class Enemy : MonoBehaviour
    {
        private const float MinDistance = 0.0f;
        
        public event Action<Enemy> OnDestroyed = delegate(Enemy enemy) {  };
        
        [SerializeField] private float speed = 5.0f;
        [SerializeField] private Transform spriteTransform = null;

        private int _targetIndex = 0;
        private Transform[] _wayPoints = null;

        private Transform CurrentTransform => _wayPoints[_targetIndex];

        public void SetEnemy(WayPoint wayPoint)
        {
            gameObject.SetActive(true);
            
            _wayPoints = wayPoint.GetWayPoints;
            transform.position =_wayPoints[0].position;
            
            Move();
        }


        private int _maxHp = 2;
        private int _hp = 2;
        public void Damage(int damage)
        {
            _hp -= damage;
            
            if (_hp > 0) return;
            
            OnDestroyed.Invoke(this);
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }

        public void SetPos(float x, float y)
        {
            transform.position = new Vector3(x, y, 0);

            gameObject.SetActive(false);
        }

        public void Move()
        {
            StartCoroutine(OnMove());
        }
        
        private IEnumerator OnMove()
        {
            while (true)
            {
                RotateTowardsTarget(CurrentTransform);
                MoveToTarget(CurrentTransform);

                if (CheckDistanceToTarget(CurrentTransform))
                {
                    Util.ClampCount(ref _targetIndex, 1, 0, _wayPoints.Length - 1);
                }
                
                yield return null;
            }
        }

        /// <summary>
        /// 타겟의 방향에 따라 회전합니다.
        /// </summary>
        private void RotateTowardsTarget(Transform target)
        {
            float angle = Mathf.Atan2(GetDistanceToTarget(target).y, GetDistanceToTarget(target).x) * Mathf.Rad2Deg;
            spriteTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        /// <summary>
        /// 타겟의 위치로 이동시킵니다.
        /// </summary>
        private void MoveToTarget(Transform target)
        {
            transform.position = 
                Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        /// <summary>
        /// 타겟과의 거리를 반환합니다.
        /// </summary>
        /// <returns></returns>
        private Vector3 GetDistanceToTarget(Transform target)
        {
            return target.position - transform.position;
        }
        
        /// <summary>
        /// 일정 거리 안에 타겟이 존재해는지 체크합니다.
        /// </summary>
        /// <returns></returns>
        private bool CheckDistanceToTarget(Transform target)
        {
            return Vector3.Distance(target.position, transform.position) <= MinDistance;
        }
    }
}