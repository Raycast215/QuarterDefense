using System;
using System.Collections;
using QuarterDefense.Common;
using UnityEngine;

namespace QuarterDefense.InGame
{
    public class Enemy : MonoBehaviour
    {
        private const float MinDistance = 1.0f;
        
        public event Action<Enemy> OnDestroyed = delegate(Enemy enemy) {  };
        
        [SerializeField] private float speed = 5.0f;
        [SerializeField] private Transform spriteTransform = null;
        [SerializeField] private GameObject selectedTag = null;

        private int _targetIndex = 0;
        private Transform[] _wayPoints = null;

        private Transform CurrentTransform => _wayPoints[_targetIndex];

        public bool SetSelect { set => selectedTag.SetActive(value); }

        public long GetTimestamp { get; private set; } = 0;

        public void SetEnemy(WayPoint wayPoint)
        {
            _wayPoints = wayPoint.GetWayPoints;
            transform.position = wayPoint.GetStartPoint.position;
            GetTimestamp = Util.GetTimeStamp();
            
            gameObject.SetActive(true);

            StartCoroutine(Move());
        }


        private int _maxHp = 3;
        private int _hp = 3;
        public void Damage(int damage)
        {
            _hp -= damage;

            float scale = (float)_hp / _maxHp;
            transform.localScale = new Vector3(scale, scale, scale);

            if (_hp <= 0)
            {
                OnDestroyed.Invoke(this);
                Destroy(gameObject);
            }
        }
        
        private IEnumerator Move()
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