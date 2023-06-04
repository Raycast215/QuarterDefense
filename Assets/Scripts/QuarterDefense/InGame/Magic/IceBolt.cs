using System;
using QuarterDefense.InGame.Character.Enemy;
using UnityEngine;

namespace QuarterDefense.InGame.Magic
{
    public class IceBolt : Magic
    {
        [SerializeField] private Enemy _targetEnemy;

        private void Start()
        {
            Init();
        }

        private void FixedUpdate()
        {
            Move();
            RotateTowardsTarget(_targetEnemy.transform);
            Attack();
        }

        public void SetPos(Vector3 pos)
        {
            transform.position = pos;
        }
        
        public void SetEnemy(Enemy targetEnemy)
        {
            _targetEnemy = targetEnemy;
        }
        
        protected override void Move()
        {
            if (CheckTarget())
            {
                Destroy(gameObject);
                return;
            }
            
            transform.position = Vector3.MoveTowards(transform.position, _targetEnemy.transform.position, data.Speed * Time.deltaTime);
            
           
        }

        private void Attack()
        {
            float dist = Vector3.Distance(transform.position, _targetEnemy.transform.position);

            if (dist <= 0.5f)
            {
                _targetEnemy.Damage(data.Damage);
                Destroy(gameObject);
            }

        }

        private void RotateTowardsTarget(Transform target)
        {
            if(CheckTarget()) return;
            
            float angle = Mathf.Atan2(GetDistanceToTarget(target).y, GetDistanceToTarget(target).x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
        private Vector3 GetDistanceToTarget(Transform target)
        {
            return target.position - transform.position;
        }

        private bool CheckTarget()
        {
            return !_targetEnemy.gameObject.activeInHierarchy || _targetEnemy == null;
        }
    }
}